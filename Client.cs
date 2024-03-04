using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Data_Collector_CSharp
{
    /// <summary>
    /// Client class to send and receive data from a server
    /// </summary>
    class Client
    {
        private string IP_ADDRESS;
        private int PORT;
        private UdpClient udpClient;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="IP_ADDRESS"></param>
        /// <param name="PORT"></param>
        public Client(string IP_ADDRESS = "127.0.0.1", int PORT = 0)
        {
            this.IP_ADDRESS = IP_ADDRESS;
            this.PORT = PORT;
            udpClient = new UdpClient();
        }

        /// <summary>
        /// Send a request to the server and receive a response
        /// </summary>
        /// <param name="requestString"></param>
        /// <returns></returns>
        public string RequestDatafromServer(string requestString)
        {
            // Check if udpClient is null or disposed
            if (udpClient == null || udpClient.Client == null || udpClient.Client.Connected == false)
            {
                // Create a new UdpClient
                udpClient = new UdpClient();
            }

            try
            {
                // Connect to the server
                udpClient.Connect(this.IP_ADDRESS, this.PORT);

                // Send request
                Byte[] sendBytes = Encoding.ASCII.GetBytes(requestString);
                udpClient.Send(sendBytes, sendBytes.Length);

                // Set receive timeout
                udpClient.Client.ReceiveTimeout = 5000;

                // Receive response
                IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Parse(this.IP_ADDRESS), this.PORT);
                Byte[] receiveBytes = udpClient.Receive(ref RemoteIpEndPoint);
                string returnData = Encoding.ASCII.GetString(receiveBytes);

                return returnData;
            }
            catch (SocketException er)
            {
                return "Socket Error: " + er.Message;
            }
            catch (Exception e)
            {
                return "Error: " + e.Message;
            }
        }

        /// <summary>
        /// Close the client
        /// </summary>
        public void CloseClient()
        {
            if (udpClient != null)
            {
                udpClient.Close();
                udpClient.Dispose();
                udpClient = null;
            }
        }


        public string IP
        {
            get { return IP_ADDRESS; }
            set { IP_ADDRESS = value; }
        }

        public int Port
        {
            get { return PORT; }
            set { PORT = value; }
        }
    }
}
