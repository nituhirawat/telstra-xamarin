using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CD
{
    public class Path
    {
        public string CurrentPath { get; private set; }

        //constructor
        public Path(string path)
        {
            this.CurrentPath = path;
        }

        //functions like change directory function for a file system
        public Path Cd(string currentPath, string newPath)
        {
            Path changedPath = null;
            try
            {

                if (!newPath.Contains(".."))
                {

                    if (Directory.GetDirectoryRoot(newPath) == Directory.GetDirectoryRoot(currentPath))
                    {
                        if (Directory.Exists(currentPath + newPath))
                             changedPath = new Path(currentPath + newPath);
                    }

                    else
                    {
                        if (Directory.Exists(newPath))
                            changedPath = new Path(newPath);
                    }


                }

                else
                {
                    //if new path contains ..
                    string[] arr = newPath.Split('\\');
                    for (int i = 0; i < arr.Length; i++)
                    {
                        if (arr[i].ToString() == "..")
                        {
                            changedPath = new Path(Directory.GetParent(currentPath).ToString()); // move to the parent
                            currentPath = changedPath.CurrentPath;
                        }
                        else
                            changedPath = new Path(changedPath.CurrentPath + "\\" + arr[i]);
                    }
                }

                if (changedPath != null)
                {
                    if (Directory.Exists(changedPath.CurrentPath))
                         changedPath.CurrentPath = changedPath.CurrentPath.Replace("\\\\", "\\");
                  
                }
                return changedPath;

              
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

        }

        public static void Main(string[] args)
        {
            Path finalPath = null;

            //input the current path
            Console.WriteLine("Please enter the current path:");
            Path path = new Path(Console.ReadLine().ToString());
            while (!Directory.Exists(path.CurrentPath))
            {
                Console.WriteLine("The entered directory does not exist, please reenter the current path");
                path = new Path(Console.ReadLine().ToString());

            }

            //input the new path 
            Console.WriteLine("Please enter the new path:");
            Path newPath = new Path(Console.ReadLine().ToString());
            finalPath = path.Cd(path.CurrentPath, newPath.CurrentPath);
            if (finalPath != null)
                Console.WriteLine("The changed path is " + finalPath.CurrentPath);
            else
                Console.WriteLine("The entered new path does not exist");
            Console.ReadLine();
        }
    }
}
