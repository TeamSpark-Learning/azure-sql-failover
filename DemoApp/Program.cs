using System;
using System.Threading;
using DemoApp.Activities;

namespace DemoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();

            ParseArgs(args, out var mode, out var timeout);

            Console.WriteLine($"Mode: {mode}; Timeout: {timeout} seconds");
            
            var mutex = new Mutex();
            switch (mode)
            {
                case "read":
                    HeaderRead(0);
                    new Thread(() => { new ReadData(Configs.Server01, mutex, 3, 0, timeout).Start(); }).Start();
                    new Thread(() => { new ReadData(Configs.Server02, mutex, 3, 5, timeout).Start(); }).Start();
                    new Thread(() => { new ReadData(Configs.ServerPrimary, mutex, 3, 10, timeout).Start(); }).Start();
                    new Thread(() => { new ReadData(Configs.ServerSecondary, mutex, 3, 15, timeout).Start(); }).Start();
                    new Thread(() => { new ReadData(Configs.Server03, mutex, 3, 20, timeout).Start(); }).Start();
                    break;
                case "write":
                    HeaderWrite(0);
                    new Thread(() => { new WriteData(Configs.Server01, mutex, 3, 0, timeout).Start(); }).Start();
                    new Thread(() => { new WriteData(Configs.Server02, mutex, 3, 5, timeout).Start(); }).Start();
                    new Thread(() => { new WriteData(Configs.ServerPrimary, mutex, 3, 10, timeout).Start(); }).Start();
                    new Thread(() => { new WriteData(Configs.ServerSecondary, mutex, 3, 15, timeout).Start(); }).Start();
                    new Thread(() => { new WriteData(Configs.Server03, mutex, 3, 20, timeout).Start(); }).Start();
                    break;
                case "delete":
                    HeaderDelete(0);
                    new Thread(() => { new DeleteData(Configs.Server01, mutex, 3, 0, timeout).Start(); }).Start();
                    new Thread(() => { new DeleteData(Configs.Server02, mutex, 3, 5, timeout).Start(); }).Start();
                    new Thread(() => { new DeleteData(Configs.ServerPrimary, mutex, 3, 10, timeout).Start(); }).Start();
                    new Thread(() => { new DeleteData(Configs.ServerSecondary, mutex, 3, 15, timeout).Start(); }).Start();
                    new Thread(() => { new DeleteData(Configs.Server02, mutex, 3, 20, timeout).Start(); }).Start();
                    break;
            }
        }

        private static void ParseArgs(string[] args, out string mode, out int timeout)
        {
            mode = null;
            timeout = -1;

            foreach (var arg in args)
            {
                if (arg.StartsWith("--mode=", StringComparison.InvariantCultureIgnoreCase))
                {
                    mode = arg.Substring(7).ToLowerInvariant();

                    switch (mode)
                    {
                        case "read":
                        case "write":
                        case "delete":
                            break;
                        default:
                            throw new ArgumentException(nameof(mode));
                    }
                }

                if (arg.StartsWith("--timeout=", StringComparison.InvariantCultureIgnoreCase))
                {
                    if (!int.TryParse(arg.Substring(10), out timeout))
                    {
                        throw new ArgumentException(nameof(timeout));
                    }
                }
            }

            if (string.IsNullOrEmpty(mode))
            {
                throw new ArgumentException(nameof(mode));
            }

            if (timeout < 0)
            {
                throw new ArgumentException(nameof(timeout));
            }
        }

        private static void HeaderRead(int leftOffset)
        {
            Console.CursorLeft = leftOffset;
            Console.CursorTop = 1;
            Console.Write("Read COUNT (Address)");
            
            HeaderGeneral(leftOffset);
        }
        
        private static void HeaderWrite(int leftOffset)
        {
            Console.CursorLeft = leftOffset;
            Console.CursorTop = 1;
            Console.Write("Insert Address");
            
            HeaderGeneral(leftOffset);
        }
        
        private static void HeaderDelete(int leftOffset)
        {
            Console.CursorLeft = leftOffset;
            Console.CursorTop = 1;
            Console.Write("Delete old Addresses");

            HeaderGeneral(leftOffset);
        }
        
        private static void HeaderGeneral(int leftOffset)
        {
            Console.CursorLeft = leftOffset;
            Console.CursorTop = 2;
            Console.Write("01");
            
            Console.CursorLeft = leftOffset + 5;
            Console.CursorTop = 2;
            Console.Write("02");
            
            Console.CursorLeft = leftOffset + 10;
            Console.CursorTop = 2;
            Console.Write("P");
            
            Console.CursorLeft = leftOffset + 15;
            Console.CursorTop = 2;
            Console.Write("S");
            
            Console.CursorLeft = leftOffset + 20;
            Console.CursorTop = 2;
            Console.Write("03");
        }
    }
}