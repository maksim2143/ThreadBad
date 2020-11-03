using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ConsoleStart
{
    class Program
    {
        public readonly List<int> block = new List<int>();
        private void Log(int value)
        {
            Console.WriteLine(value);
            block.Add(value);
        }
        public void Start()
        {
            for (int i = 0; i < 10; i++)
            {
                block.Add(i);
            }
        }
        public void StartThread()
        {
            for (int i = 0; i < 3; i++)
            {
                var thread = new Thread(() =>
                {
                    try
                    {
                        Start();
                    }
                    catch (Exception ex) { Console.WriteLine(ex.ToString()); }
                });
                thread.Start();
            }
        }
        static void Main(string[] args)
        {
            var program = new Program();
            program.StartThread();
            Thread.Sleep(2000);
            program.block.ForEach(x =>
            {
                Console.WriteLine(x);
            });
            Console.WriteLine("OK");
            Console.ReadKey();
        }
    }
}
