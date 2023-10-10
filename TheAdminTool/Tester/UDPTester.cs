using System.Net;
using System.Net.Http.Headers;
using System.Net.Sockets;
using TheAdminTool.Tester.Interface;
using TheAdminTool.Tester.Model;

namespace TheAdminTool.Tester
{
	public class UDPTester : ITester
	{
		public List<object> TestItems { get; set; }

		public TestResult Test()
		{
			IPEndPoint Endpoint = new IPEndPoint((IPAddress)TestItems[0], (int)TestItems[1]);
			UdpClient Client = new UdpClient(Endpoint);
			return TestResult.Success;
		}
	}
}
