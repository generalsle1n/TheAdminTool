using System.CommandLine;
using System.Net;
using TheAdminTool.Tester;
using TheAdminTool.Tester.Interface;
using TheAdminTool.Tester.Model;

RootCommand Root = new RootCommand(description: "The Admin Tool for youre easier life");

Command TCPTestCommand = new Command(name: "--TCPTest", description: "Test if an remote TCP Port is reachable");
Option<string> TCPTestIPAddressOption = new Option<string>(name: "--IP", description: "Enter the remote IP")
{
	IsRequired = true
};
Option<int> TCPTestPortOption = new Option<int>(name: "--Port", description: "Enter the port to test")
{
	IsRequired = true
};

TCPTestCommand.AddOption(TCPTestIPAddressOption);
TCPTestCommand.AddOption(TCPTestPortOption);

TCPTestCommand.SetHandler((InputTCPTestIPAddressOption, InputTCPTestPortOption) =>
{
	ITester TCPTester = new TCPTester()
	{
		TestItems = new List<object>()
		{
			InputTCPTestIPAddressOption,
			InputTCPTestPortOption
		}
	};

	if (TCPTester.Test() == TestResult.Success)
	{
        Console.WriteLine("Port is open");
	}
	else
	{
        Console.WriteLine("Port is not reachable");
    }

}, TCPTestIPAddressOption, TCPTestPortOption);

Root.AddCommand(TCPTestCommand);
Root.Invoke(args);