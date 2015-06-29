using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmdStrapped.Controllers
{
    class BasicCommands
    {
        //
        // Shows a short help documentation.
        //
        public static void ShowHelp(string args)
        {
            Program TempProg = new Program();

            Console.WriteLine(Environment.NewLine + "----------------------------------------------------------");
            Console.WriteLine("Command List:");
            Console.WriteLine("----------------------------------------------------------" + Environment.NewLine);

            foreach (var command in TempProg.GetCommands())
            {
                Console.WriteLine(command.Hook + " - " + command.Description);
            }

            Console.WriteLine(Environment.NewLine);
        }

        //
        // Exits the application.
        //
        public static void Exit(string args)
        {
            Console.WriteLine("Are you sure? Y/n");
            if(Console.ReadLine().ToString().Equals("Y"))
                Environment.Exit(0);
            else
                Console.WriteLine("Exit aborted, returning to application...");
        }
    }
}
