using System;
using System.Diagnostics;
using System.Reflection;
using McMaster.Extensions.CommandLineUtils;

namespace DotNetTools.Tpl
{
    [Command(Name = "tpl", Description = "Manage dotnet new templates.")]
    class Program
    {
        [Option(Description = "Display the version of this tool and then exit")]
        public bool Print { get; }

        [HelpOption(Description = "Lists templates containing the specified name. If no name is specified, lists all templates.")]
        public bool List { get; }

        static void Main(string[] args) => CommandLineApplication.Execute<Program>(args);

        private int OnExecute()
        {
            try
            {
                if (Print)
                {
                    var assembly = Assembly.GetEntryAssembly();
                    var v = assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>();
                    Console.WriteLine($"version:\t{v.InformationalVersion}");
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
                return 1;
            }

            return 0;
        }
    }
}
