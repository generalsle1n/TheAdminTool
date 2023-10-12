using System.Net;
using System.Net.Sockets;
using TheAdminTool.Tester.Interface;
using TheAdminTool.Tester.Model;

namespace TheAdminTool.Tester
{
	public class TCPTester : ITester
	{
		public List<object> TestItems { get; set; }

		public TestResult Test()
		{
			IPEndPoint Endpoint = new IPEndPoint((IPAddress)TestItems[0], (int)TestItems[1]);
			using(TcpClient Client = new TcpClient())
			{
				try
				{
					Client.Connect(Endpoint);
					return TestResult.Success;
				}catch (Exception ex)
				{
					return TestResult.Failed;
				}
			}
		}
	}
}
