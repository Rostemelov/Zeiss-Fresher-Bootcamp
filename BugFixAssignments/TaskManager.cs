using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugfix
{
    public interface IPrinter
    {
        void Print(string path);
    }

    public interface IScanner
    {
        void Scan(string path);
    }

    public class Printer: IPrinter
    {

        public void Print(string path)
        {
            System.Console.WriteLine($"Printing .....{path}");
        }
    }

    public class Scanner: IScanner
    {

        public void Scan(string path)
        {
            System.Console.WriteLine($"Scanning .....{path}");
        }
    }

    public class PrintScanner: IPrinter, IScanner
    {
        public void Scan(string path)
        {
            System.Console.WriteLine($"Scanning .....{path}");
        }

        public void Print(string path)
        {
            System.Console.WriteLine($"Printing .....{path}");
        }

    }
    public static class TaskManager
    {
        public static void ExecuctePrintTask(Printer printer, string documentPath)
        {
            printer.Print(documentPath);
        }
        public static void ExecucteScanTask(Scanner scanner, string documentPath)
        {
            scanner.Scan(documentPath);
        }

        public static void ExecuctePrintTask(PrintScanner printscanner, string documentPath)
        {
            printscanner.Print(documentPath);
        }
        public static void ExecucteScanTask(PrintScanner printscanner, string documentPath)
        {
            printscanner.Scan(documentPath);
        }
    }

    public class Program
    {
        static void Main()
        {
            Printer printerObj = new Printer();
            Scanner scannerObj = new Scanner();
            PrintScanner printScannerObj = new PrintScanner();

            TaskManager.ExecuctePrintTask(printerObj, "Test.doc");
            TaskManager.ExecucteScanTask(scannerObj, "MyImage.png");
            TaskManager.ExecuctePrintTask(printScannerObj, "NewDoc.doc");
            TaskManager.ExecucteScanTask(printScannerObj, "YourImage.png");
        }
    }
}
