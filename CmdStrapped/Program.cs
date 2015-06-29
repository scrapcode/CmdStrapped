using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CmdStrapped.Models;
using CmdStrapped.Controllers;

namespace CmdStrapped
{
    class Program
    {
        // configure the available commands as a list of Command objects
        private List<Command> commands = new List<Command>
        {
            new Command { CommandId = 0, Hook = "help", Method = BasicCommands.ShowHelp, Description = "Shows the help screen." },
            new Command { CommandId = 1, Hook = "exit", Method = BasicCommands.Exit, Description = "Exits the application." }
        };

        //
        // MAIN METHOD, Starting point.
        //
        static void Main(string[] args)
        {
            // declarizations
            Program cTMSCli = new Program();
            string command;

            // display the startup information
            CmdStrapped.Program.DisplaySplash();

            // "infinite" loop. ensure there is an "exit" command to exit this program.
            while (true)
            {
                command = cTMSCli.ReceiveCommand();

                if (!cTMSCli.ParseCommand(command))
                {
                    Console.WriteLine(Environment.NewLine + "Sorry, no such command. Please try again or type \"help\".");
                }
            }
        }

        public List<Command> GetCommands()
        {
            return this.commands;
        }

        //
        // Splash screen containing generic application information.
        //
        private static void DisplaySplash()
        {
            Console.WriteLine(Environment.NewLine + "----------------------------------------------------------");
            Console.WriteLine("CmdStrapped - Bootstrapped C# Command Line Application");
            Console.WriteLine("Enter command below or use \"help\" for more information.");
            Console.WriteLine("----------------------------------------------------------" + Environment.NewLine);
        }

        //
        // Formats how the application with prompt the user for input.
        //
        private string ReceiveCommand()
        {
            Console.Write("> ");
            return Console.ReadLine();
        }

        //
        // Parse the user entered command.
        //
        private bool ParseCommand(string cmd)
        {
            int indexOfWhitespace = cmd.IndexOf(" "); // find the first occurrance of whitespace (if any)
            string commandArguments = ""; // declare an initialize the argument string

            if(indexOfWhitespace > 0)
            {
                // breaks the command into 2 parts: the command, and the argument string.
                commandArguments = cmd.Substring( ( indexOfWhitespace + 1 ), ( cmd.Length - indexOfWhitespace - 1 ) );
                cmd = cmd.Substring(0, cmd.IndexOf(" "));
            }

            // check if the command exists in our Command list
            if (this.commands.Exists(c => c.Hook.Equals(cmd)))
            {
                var theCmd = this.commands.Where(c => c.Hook.Equals(cmd)).First();  // the command
                theCmd.Method(commandArguments); // runs the command
                return true;
            }
            else
            {
                return false;   // command doesn't exist
            }
        }
    }
}