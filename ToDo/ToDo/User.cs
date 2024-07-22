using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo
{
    class User
    {
        private static string Tasks = "tasks.txt";

        
        public static int numOfTasks()
        {
            String[] line = File.ReadAllLines(Tasks);
            return line.Length;
        }
        
        public static bool IsThereTask()
        {
            if (!File.Exists(Tasks))
            {
                return false;
            }
            return true;
        }
        public static bool IsThereInfo()
        {
            if (!File.Exists(Tasks))
            {
                File.Create(Tasks);
                //File.AppendAllText(Tasks,"");
            }
            String[] line = File.ReadAllLines(Tasks);
            if (line.Length == 0)
            {
                return false;
            }
            return true;
        }
        public static void AddTask(String task)
        {
            if(!File.Exists(Tasks))
            {
                File.WriteAllText(Tasks, task+"\n");
            }
            else
            {
                File.AppendAllText(Tasks, task+"\n");
            }
        }
        public static void DeleteTask(String task)
        {
            if (!File.Exists(Tasks))
            {
                Console.WriteLine("There is no tasks to be deleted");
            }
            else
            {
                String result = "";
                List<String> list = new List<String>();
                using (StreamReader reader = new StreamReader(Tasks))
                {
                    String line;

                    while ((line = reader.ReadLine()) != null)
                    {
                        if (line != task)
                        {
                            result += line + "\n";
                        }
                    }
                }
                File.WriteAllText(Tasks, result);
                
            }
        }
        public static String[] ShowTasks()
        {
            String[] line = File.ReadAllLines(Tasks);
            return line;
        }
        public static void MarkTask(String task)
        {
            if (!File.Exists(Tasks))
            {
                Console.WriteLine("There is no tasks to be marked");
            }
            else
            {
                String result = "";
                List<String> list = new List<String>();
                using (StreamReader reader = new StreamReader(Tasks))
                {
                    String line;
                    
                    while((line = reader.ReadLine()) != null)
                    {
                        if (line != task)
                        {
                            result += line + "\n";
                        }
                    }
                }
                File.WriteAllText(Tasks, result);
                File.AppendAllText(Tasks, task + "    [Done]\n");
            }
        }
    
    }
}
