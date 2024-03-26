using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
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
                client.Send(Serialize(tbSendMss.Text));
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
                        string message = (string)Deserialize(data);
                        addMessage(message);
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
    }
}
