using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace TestLog4Net
{
    class Program
    {
        private static readonly ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        static void Main(string[] args)
        {
            Logger.InfoFormat("Running as {0}", WindowsIdentity.GetCurrent().Name);
            Logger.Error("This will appear in red in the console and still be written to file!");
            Logger.Warn("Attention, il y a un problème non bloquant! ");
            Console.Read();
        }
    }
}
