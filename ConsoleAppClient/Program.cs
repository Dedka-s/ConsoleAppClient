using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppClient
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string allText = File.ReadAllText("E:\\text.txt");
            var client = new ServiceReference1.Service1Client("BasicHttpBinding_IService1");
            Dictionary<string, int> wordList = client.DoWork(allText);

            using (FileStream fs = new FileStream("E:\\textResalt.txt", FileMode.OpenOrCreate))
            {
                using (TextWriter tw = new StreamWriter(fs))

                    foreach (KeyValuePair<string, int> kvp in wordList)
                    {
                        tw.WriteLine(string.Format("{0};{1}", kvp.Key, kvp.Value));
                    }
            }
            
        }
    }
}
