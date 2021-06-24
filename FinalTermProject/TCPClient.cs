using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalTermProject
{
    public partial class TCPClient : Form
    {
        public TCPClient()
        {
            InitializeComponent();
        }

        public Dashboard dboard;
        IPEndPoint ipepServer;
        Socket serverSocket;
        bool isURLExist = true;

        private void TCPClient_Load(object sender, EventArgs e)
        {
            ipepServer = new IPEndPoint(dboard.ipServer, dboard.portServer);
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                serverSocket.Connect(ipepServer);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Can't connect to server\n Something went wrong\n" +
                   ex.InnerException.Message , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void requestBtn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(URLbox.Text))
            {
                if (!URLbox.Text.StartsWith("http://") && !URLbox.Text.StartsWith("https://"))
                {
                   URLbox.Text = URLbox.Text.Insert(0, "http://");
                }
                serverSocket.Send(SerializeMessage(URLbox.Text));
                isURLExist = CheckIfURLExist(URLbox.Text);
                if (!isURLExist)
                {
                    failResult.Visible = true;
                    succeedResult.Visible = false;
                }
                else
                {
                    failResult.Visible = false;
                    succeedResult.Visible = true;
                }
            }
            else
            {
                if (string.IsNullOrWhiteSpace(URLbox.Text) || URLbox.Text.Equals("about:blank"))
                {
                    MessageBox.Show("Enter a valid URL.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    URLbox.Focus();
                    return;
                }
            }
        }

        bool CheckIfURLExist(string url)
        {
            bool isExist = true;
            HttpWebRequest clientRequest = HttpWebRequest.Create(url) as HttpWebRequest;
            clientRequest.Timeout = 5000;
            clientRequest.Method = "HEAD";
            try
            {
                using (HttpWebResponse webResponse = clientRequest.GetResponse() as HttpWebResponse)
                {
                    int statusCode = (int)webResponse.StatusCode;
                    if (statusCode >= 100 && statusCode < 400)
                    {
                        isExist = true;
                    }
                    else isExist = false;
                }
            }
            catch(WebException ex)
            {
                MessageBox.Show("Something went wrong\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                isExist = false;
            }


            return isExist;
        }

        private byte[] SerializeMessage(object obj)
        {
            MemoryStream ms = new MemoryStream();
            BinaryFormatter binaryFormatter = new BinaryFormatter();

            binaryFormatter.Serialize(ms, obj);
            return ms.ToArray();
        }

        private void closeClient(object sender, FormClosedEventArgs e)
        {
            serverSocket.Close();
            dboard.client.Close();
        }
    }
}
