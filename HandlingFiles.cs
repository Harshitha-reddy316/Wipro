using System;
using System.IO;
namespace oops
{
    class HandlingFiles
    {
        static void Main()
        {
            try
            { 
                
                Console.Write("Enter file name (example: myfile.txt): ");
                string fileName = Console.ReadLine();

                
                Console.Write("Enter the content to write in the file: ");
                string content = Console.ReadLine();

                
                File.WriteAllText(fileName, content);

                
                Console.WriteLine("File created and content saved successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}

