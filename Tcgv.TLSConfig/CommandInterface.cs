using System;

namespace Tcgv.TLSConfig
{
    public class CommandInterface
    {
        public void MainMenu()
        {
            WriteHeader();

            WriteLine("[1] Show current configuration");
            WriteLine("[2] Configure TLS 1.0");
            WriteLine("[3] Configure TLS 1.1");
            WriteLine("[a] About");
            WriteLine("[q] Quit\n");

            switch (ReadCommand())
            {
                case "":
                    MainMenu();
                    break;

                case "1":
                    ShowCurrentConfig();
                    break;

                case "2":
                    Modify(KeyNames.TLS_1_0);
                    break;

                case "3":
                    Modify(KeyNames.TLS_1_1);
                    break;

                case "a":
                    About();
                    break;

                case "q":
                    break;

                default:
                    InvalidCommand(MainMenu);
                    break;
            }
        }

        private string ReadCommand()
        {
            Write("command: ");
            var c = ReadLine().ToLower().Trim();
            return c;
        }

        private void ShowCurrentConfig()
        {
            WriteHeader();

            bool isFirst = true;
            foreach (var pName in new[] { KeyNames.TLS_1_0, KeyNames.TLS_1_1 })
            {
                WriteLine($"{(isFirst ? "" : "\n")}Protocol {pName}:");
                var client = new Protocol(pName).IsClientPartiallyOrFullyEnabled();
                WriteLine($" - Client {(client ? "partially or fully enabled" : "disabled")}");
                var server = new Protocol(pName).IsServerPartiallyOrFullyEnabled();
                WriteLine($" - Server {(server ? "partially or fully enabled" : "disabled")}");
                isFirst = false;
            }

            PressAnyKeyToReturn(MainMenu);
        }

        private void Modify(string protocolName)
        {
            WriteHeader();

            WriteLine($"Configure {protocolName}\n");
            WriteLine("[1] Disable all");
            WriteLine("[2] Disable Client");
            WriteLine("[3] Disable Server");
            WriteLine("[4] Enable all");
            WriteLine("[5] Enable Client");
            WriteLine("[6] Enable Server");
            WriteLine("[c] cancell\n");

            switch (ReadCommand())
            {
                case "":
                    Modify(protocolName);
                    break;

                case "1":
                    DisableAll(protocolName);
                    break;

                case "2":
                    DisableClient(protocolName);
                    break;

                case "3":
                    DisableServer(protocolName);
                    break;

                case "4":
                    EnableAll(protocolName);
                    break;

                case "5":
                    EnableClient(protocolName);
                    break;

                case "6":
                    EnableServer(protocolName);
                    break;

                case "c":
                    MainMenu();
                    break;

                default:
                    InvalidCommand(() => Modify(protocolName));
                    break;
            }
        }

        private void DisableAll(string protocolName)
        {
            WriteHeader();

            new Protocol(protocolName).DisableAll();
            WriteLine($"Protocol {protocolName} (all) successfully disabled");

            PressAnyKeyToReturn(MainMenu);
        }

        private void DisableClient(string protocolName)
        {
            WriteHeader();

            new Protocol(protocolName).DisableClient();
            WriteLine($"Protocol {protocolName} (client) successfully disabled");

            PressAnyKeyToReturn(MainMenu);
        }

        private void DisableServer(string protocolName)
        {
            WriteHeader();

            new Protocol(protocolName).DisableClient();
            WriteLine($"Protocol {protocolName} (server) successfully disabled");

            PressAnyKeyToReturn(MainMenu);
        }

        private void EnableAll(string protocolName)
        {
            WriteHeader();

            new Protocol(protocolName).EnableAll();
            WriteLine($"Protocol {protocolName} (all) successfully enabled");

            PressAnyKeyToReturn(MainMenu);
        }

        private void EnableClient(string protocolName)
        {
            WriteHeader();

            new Protocol(protocolName).EnableClient();
            WriteLine($"Protocol {protocolName} (client) successfully enabled");

            PressAnyKeyToReturn(MainMenu);
        }

        private void EnableServer(string protocolName)
        {
            WriteHeader();

            new Protocol(protocolName).EnableServer();
            WriteLine($"Protocol {protocolName} (server) successfully enabled");

            PressAnyKeyToReturn(MainMenu);
        }

        private void About()
        {
            WriteHeader();

            WriteLine("About\n");
            WriteLine(Resources.InformativeText);
            WriteLine();
            WriteLine(Resources.UsageInfo);
            WriteLine();
            WriteLine(Resources.RegistryReference);

            PressAnyKeyToReturn(MainMenu);
        }

        private void InvalidCommand(Action action)
        {
            WriteHeader();

            WriteLine("Invalid command!");

            PressAnyKeyToReturn(action);
        }

        private void WriteHeader()
        {
            Clear();
            WriteLine("## TLS Config ##\n");
        }

        private void PressAnyKeyToReturn(Action action)
        {
            Write("\npress any key to return... ");
            ReadKey();
            action();
        }

        private void Clear()
        {
            Console.Clear();
        }

        private void Write(string str)
        {
            Console.Write(str);
        }

        private void WriteLine(string line = "")
        {
            Console.WriteLine(line);
        }

        private ConsoleKeyInfo ReadKey()
        {
            return Console.ReadKey();
        }

        private string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
