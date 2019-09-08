using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAwaitExample
{
    class Program
    {
        static void Main(string[] args)
        {
            AsyncProcess process = new AsyncProcess();
            Task.Run(async () => { await process.RunProcessAsync("http://progressive.nikadevs.com/"); });
            process.RunProcess("http://progressive.nikadevs.com/");
            Console.ReadLine();
        }
    }
}
