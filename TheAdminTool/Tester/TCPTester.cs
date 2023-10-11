using System.Net;
using System.Net.Http.Headers;
using System.Net.NetworkInformation;
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
			IPEndPoint Endpoint = new IPEndPoint(IPAddress.Parse((string)TestItems[0]), (int)TestItems[1]);
			
			return TestResult.Success;
		}
	}
}
