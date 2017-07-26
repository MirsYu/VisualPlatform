using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

namespace VisualPlatform
{
	public class SocketComm
	{
		public byte[] MsgBuffer = new byte[0xa00000];
		public Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
		public void CreateSocket(string ipAdd, int port)
		{
			IPAddress ip = IPAddress.Parse(ipAdd);
			clientSocket.Connect(new IPEndPoint(ip, port));
		}
	}
}
