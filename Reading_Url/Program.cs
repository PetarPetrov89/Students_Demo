using System;
using System.Linq;

namespace Reading_Url
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = @"http://www.devbg.org/forum/data/folder/dest/bin/index.php";

            string[] parts = url.Split(new char[] { ':', '/' }, StringSplitOptions.RemoveEmptyEntries);

            string protocol = parts[0];
            string server = parts[1];

            string[] resource = parts.Skip(2).ToArray();

            Console.WriteLine(protocol);
            Console.WriteLine(server);
            Console.WriteLine("/" + string.Join('/', resource));
        }
    }
}
