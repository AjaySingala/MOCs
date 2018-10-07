using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourthCoffee.LogProcessor
{
    class Program
    {
        static void Main(string[] args)
        {
            //var logLocator = new LogLocator("E:\\Mod06\\Democode\\Data\\Logs\\");
            var logLocator = new LogLocator(@"D:\Temp\MOC20483\Mod06\Democode\Data\Logs");
            var logCombiner = new LogCombiner(logLocator);

            //logCombiner.CombineLogs("E:\\Mod06\\Democode\\Data\\Logs\\CombinedLog.txt");
            logCombiner.CombineLogs(@"D:\Temp\MOC20483\Mod06\Democode\Data\Logs\CombinedLog.txt");

        }
    }
}
