using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string userKeyPath = @"SOFTWARE\UserLastAccess";
            string valueName = "LastAccess";

            string lastAccessTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(userKeyPath))
            {
                    key.SetValue(valueName, lastAccessTime);

                    string lastAccessRecorded = key.GetValue(valueName).ToString();
                    Console.WriteLine(lastAccessRecorded);
            }
            Console.ReadLine();
        }
    }
}
