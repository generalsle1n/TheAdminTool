using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheAdminTool.Tester.Model;

namespace TheAdminTool.Tester.Interface
{
    public interface ITester
    {
        public List<object> TestItems { get; set; }
        public TestResult Test();
    }
}
