using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ToDo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Menu();
            //String[] line = File.ReadAllLines("tasks.txt");
            //Console.WriteLine(line.Length);
            //Console.WriteLine(line[0]);
            Menu();

        }
        public static void Menu()
        {
            while (true)
            {
                Console.WriteLine("=================\n|     To-Do     |\n=================\n");
                Console.WriteLine("1] Show My Tasks\n\n2] Add New Task\n\n3] Mark Task As Acheived\n\n4] Delete Task\n\n5] Exit\n");
                int choice = 0;
                while (true)
                {
                    try
                    {
                        choice = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Unknown Choice");
                        continue;
                    }
                    if (choice > 5 || choice < 1)
                    {
                        Console.WriteLine("Unknown Choice");
                        continue;
                    }
                    else break;
                }
                if (choice == 1)
                {
                    Console.Clear();
                    if (User.IsThereInfo())
                    {
                        DisplayTasks();
                    }
                    else
                    {
                        Console.WriteLine("There is NO tasks yet");
                    }
                    
                    Console.WriteLine("\n\n< Click enter to back >");
                    String back = Console.ReadLine();
                    Console.Clear();
                }
                else if (choice == 2)
                {
                    Console.Clear();
                    if (User.IsThereTask())
                    {
                        Console.WriteLine("Task :\n-----");
                        String newTask = Console.ReadLine();
                        User.AddTask(newTask);
                        Console.WriteLine();
                        Console.Write("Adding your task");
                        Thread.Sleep(600); Console.Write("."); Thread.Sleep(600); Console.Write("."); Thread.Sleep(600); Console.Write("."); Thread.Sleep(400); Console.Write("."); Thread.Sleep(400); Console.Write("."); Thread.Sleep(400); Console.Write(".");
                        Console.WriteLine("\nNew Task is added");
                    }
                    else
                    {
                        Console.WriteLine("There is no task yet");
                    }
                    Console.WriteLine("\n\n< Click enter to back >");
                    String back = Console.ReadLine();
                    Console.Clear();
                }
                else if (choice == 3)
                {
                    Console.Clear();

                    if (User.IsThereInfo())
                    {
                        DisplayTasks();

                        Console.Write("Choose task to mark it as done :");
                        int c = 0;
                        while (true)
                        {
                            try
                            {
                                c = Convert.ToInt32(Console.ReadLine());
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Please choose between 1 to {User.numOfTasks()} task");
                                continue;
                            }
                            if (c < 1 || c > User.numOfTasks())
                            {
                                Console.WriteLine($"Please choose between 1 to {User.numOfTasks()} task");
                                continue;
                            }
                            else break;
                        }
                        String[] line = User.ShowTasks();
                        User.MarkTask(line[c - 1]);
                        Console.WriteLine("\nTask is Marked");
                    }
                    else
                    {
                        Console.WriteLine("There is NO tasks yet");
                    }

                    Console.WriteLine("\n\n< Click enter to back >");
                    String back = Console.ReadLine();


                    Console.Clear();
                }
                else if (choice == 4)
                {
                    Console.Clear();
                    if (User.IsThereInfo())
                    {
                        DisplayTasks();

                        Console.Write("Choose task to Delete it :");
                        int c = 0;
                        while (true)
                        {
                            try
                            {
                                c = Convert.ToInt32(Console.ReadLine());
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Please choose between 1 to {User.numOfTasks()} task");
                                continue;
                            }
                            if (c < 1 || c > User.numOfTasks())
                            {
                                Console.WriteLine($"Please choose between 1 to {User.numOfTasks()} task");
                                continue;
                            }
                            else break;
                        }
                        String[] line = User.ShowTasks();
                        User.DeleteTask(line[c - 1]);
                        Console.WriteLine("\nTask is Deleted");
                    }
                    else
                    {
                        Console.WriteLine("There is NO tasks yet");
                    }

                    Console.WriteLine("\n\n< Click enter to back >");
                    String back = Console.ReadLine();


                    Console.Clear();
                }
                else
                {
                    Console.Clear();
                    break;
                }
            }   
        }
    
        public static void DisplayTasks()
        {
            Console.WriteLine("Tasks\n------\n");
            String[] line = User.ShowTasks();
            for (int i = 0; i < line.Length; i++)
            {
                Console.WriteLine($"{i + 1}) {line[i]}\n");
            }
        }
    }
}
