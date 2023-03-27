using System;
using System.Text;
using System.IO;




public class Program
{
    static long directorySize = 0;
    static void Main(string[] args)
    {
        string dirName = Console.ReadLine();
        string directory = dirName;
        directorySize = sizeOfFolder(directory);
        Console.WriteLine($" Size of directory {directory} - {directorySize}");







    }

    static long sizeOfFolder(string folder)
    {
        try
        {

            DirectoryInfo directory = new DirectoryInfo(folder);
            DirectoryInfo[] directories = directory.GetDirectories();
            FileInfo[] files = directory.GetFiles();

            foreach (FileInfo file in files)
            {

                directorySize = directorySize + file.Length;
            }

            foreach (DirectoryInfo fdirectory in directories)
            {

                sizeOfFolder(fdirectory.FullName);
            }

            return directorySize;
        }

        catch (DirectoryNotFoundException ex)
        {
            Console.WriteLine(ex.Message);
            return 0;
        }

        catch (UnauthorizedAccessException ex)
        {
            Console.WriteLine(ex.Message);
            return 0;
        }

        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return 0;
        }
    }
}

