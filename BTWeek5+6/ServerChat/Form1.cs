using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Windows.Forms;

namespace ServerChat
{
    public partial class Form1 : Form
    {
        public const int BufferSize = 4096;
        private Socket server;
        private List<Socket> clientlist;

        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            connect();
        }

        delegate void AddMessageDelegate(string message);

        void connect()
        {
            clientlist = new List<Socket>();
            try
            {
                server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                server.Bind(new IPEndPoint(IPAddress.Any, 9999));
                server.Listen(100);

                Thread listen = new Thread(ListenForClients);
                listen.IsBackground = true;
                listen.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể khởi động server: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void close()
        {
            foreach (Socket client in clientlist)
            {
                client.Close();
            }
            clientlist.Clear();
            server.Close();
        }

        void ListenForClients()
        {
            try
            {
                while (true)
                {
                    Socket client = server.Accept();
                    clientlist.Add(client);

                    Thread receiveThread = new Thread(() => ReceiveFromClient(client));
                    receiveThread.IsBackground = true;
                    receiveThread.Start();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi chấp nhận kết nối: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void ReceiveFromClient(Socket client)
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
                            SendMessageToClients(message);
                            this.Invoke(new AddMessageDelegate(addmessage), new object[] { message });
                        }
                        else if (receivedData is byte[])
                        {
                            byte[] imageData = (byte[])receivedData;
                            SendMessageToClients(imageData);
                            DisplayImage(imageData);
                        }
                        else if (receivedData is DataType && (DataType)receivedData == DataType.Emoji)
                        {
                            string emoji = (string)receivedData;
                            SendMessageToClients(emoji);
                            addmessage(emoji);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kết nối với client đã đóng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                clientlist.Remove(client);
                client.Close();
            }
        }


        void SendMessageToClients(string message)
        {
            foreach (Socket client in clientlist)
            {
                client.Send(Serialize(message));
            }
        }

        void SendMessageToClients(byte[] imageData)
        {
            foreach (Socket client in clientlist)
            {
                client.Send(Serialize(imageData));
            }
        }

        void addmessage(string m)
        {
            lsvmessage.Items.Add(new ListViewItem() { Text = m });
        }

        byte[] Serialize(object obj)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, obj);
                return stream.ToArray();
            }
        }

        object Deserialize(byte[] data)
        {
            using (MemoryStream stream = new MemoryStream(data))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                return formatter.Deserialize(stream);
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        void DisplayImage(byte[] imageData)
        {
            try
            {
                using (MemoryStream ms = new MemoryStream(imageData))
                {
                    Image image = Image.FromStream(ms);
                    // Hiển thị hình ảnh tại đây nếu cần thiết
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
