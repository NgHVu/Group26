using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace Client
{
    public partial class Form1 : Form
    {
        public const int BufferSize = 4096;
        private Socket client;

        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            connect();
        }

        void connect()
        {
            try
            {
                client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                client.Connect(IPAddress.Parse("127.0.0.1"), 9999);

                Thread listen = new Thread(receive);
                listen.IsBackground = true;
                listen.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể kết nối server: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void close()
        {
            client.Close();
        }

        void send()
        {
            if (!string.IsNullOrEmpty(tbSendMss.Text))
            {
                // Kiểm tra nếu là emoji
                if (IsEmoji(tbSendMss.Text))
                {
                    client.Send(Serialize(tbSendMss.Text, DataType.Emoji));
                }
                else
                {
                    // Nếu không phải là emoji, xem xét là hình ảnh hoặc văn bản
                    if (IsImage(tbSendMss.Text))
                    {
                        // Gửi dữ liệu hình ảnh
                        byte[] imageBytes = File.ReadAllBytes(tbSendMss.Text);
                        client.Send(Serialize(imageBytes, DataType.Image));
                    }
                    else
                    {
                        // Gửi dữ liệu văn bản
                        client.Send(Serialize(tbSendMss.Text, DataType.Text));
                    }
                }
            }
        }

        void receive()
        {
            try
            {
                while (true)
                {
                    byte[] data = new byte[BufferSize];
                    int bytesRead = client.Receive(data);
                    if (bytesRead > 0)
                    {
                        object receivedData = Deserialize(data);

                        if (receivedData is string)
                        {
                            // Nhận và hiển thị văn bản
                            string message = (string)receivedData;
                            addMessage(message);
                        }
                        else if (receivedData is byte[])
                        {
                            // Nhận và hiển thị hình ảnh
                            byte[] imageData = (byte[])receivedData;
                            DisplayImage(imageData);
                        }
                        else if (receivedData is DataType && (DataType)receivedData == DataType.Emoji)
                        {
                            // Nhận và hiển thị emoji
                            string emoji = (string)receivedData;
                            addMessage(emoji);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kết nối bị đóng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                close();
            }
        }

        void addMessage(string m)
        {
            lsvmessage.Items.Add(new ListViewItem() { Text = m });
            tbSendMss.Clear();
        }

        byte[] Serialize(object obj, DataType dataType)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, dataType);
                if (dataType == DataType.Image)
                {
                    // Nếu là hình ảnh, thêm dữ liệu hình ảnh vào luồng
                    byte[] imageBytes = (byte[])obj;
                    stream.Write(imageBytes, 0, imageBytes.Length);
                }
                else
                {
                    // Nếu là văn bản hoặc emoji, ghi chuỗi vào luồng
                    string textData = (string)obj;
                    StreamWriter writer = new StreamWriter(stream);
                    writer.Write(textData);
                    writer.Flush();
                }
                return stream.ToArray();
            }
        }

        object Deserialize(byte[] data)
        {
            using (MemoryStream stream = new MemoryStream(data))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                DataType dataType = (DataType)formatter.Deserialize(stream);
                if (dataType == DataType.Image)
                {
                    // Nếu là hình ảnh, trích xuất dữ liệu hình ảnh từ luồng
                    byte[] imageData = new byte[stream.Length - stream.Position];
                    stream.Read(imageData, 0, imageData.Length);
                    return imageData;
                }
                else
                {
                    // Nếu là văn bản hoặc emoji, trả về chuỗi
                    StreamReader reader = new StreamReader(stream);
                    return reader.ReadToEnd();
                }
            }
        }

        private void Send_Click(object sender, EventArgs e)
        {
            send();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private bool IsImage(string text)
        {
            string[] imageExtensions = { ".jpg", ".jpeg", ".png", ".gif" };
            return imageExtensions.Any(ext => text.EndsWith(ext, StringComparison.OrdinalIgnoreCase));
        }

        private bool IsEmoji(string text)
        {
            // Kiểm tra xem chuỗi có chứa Unicode emoji không
            return Regex.IsMatch(text, @"\p{Cs}");
        }

        void DisplayImage(byte[] imageData)
        {
            try
            {
                using (MemoryStream ms = new MemoryStream(imageData))
                {
                    Image img = Image.FromStream(ms);
                    pbReceived.Image = img;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi hiển thị hình ảnh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    enum DataType
    {
        Text,
        Image,
        Emoji
    }
} 
