using System.CommandLine;
using System.Net;
using TheAdminTool.Tester;
using TheAdminTool.Tester.Interface;
using TheAdminTool.Tester.Model;

RootCommand Root = new RootCommand(description: "The Admin Tool for youre easier life");

Command UDPTestCommand = new Command(name: "--UDPTest", description: "Test if an remote UDP Port is reachable");
Option<IPAddress> UDPTestIPAddressOption = new Option<IPAddress>(name: "--IP", description: "Enter the remote IP")
{
	IsRequired = true
};
Option<int> UDPTestPortOption = new Option<int>(name: "--Port", description: "Enter the port to test")
{
	IsRequired = true
};

UDPTestCommand.SetHandler((InputUDPTestIPAddressOption, InputUDPTestPortOption) =>
{
	ITester UDPTester = new UDPTester()
	{
		TestItems = new List<object>()
		{
			InputUDPTestIPAddressOption,
			InputUDPTestPortOption
		}
	};

	if (UDPTester.Test() == TestResult.Success)
	{
        Console.WriteLine("Port is open");
	}
	else
	{
        Console.WriteLine("Port is not reachable");
    }

}, UDPTestIPAddressOption, UDPTestPortOption);

Root.AddCommand(UDPTestCommand);
Root.Invoke(args);