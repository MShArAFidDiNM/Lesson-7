using System.Reflection.Metadata.Ecma335;

namespace Lesson_7_HomeWork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Start();
        }

        public static void Start()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine("[1] - Sign in\n[2] - Login in");
            int input = int.Parse(Console.ReadLine());

            if (input == 1)
            {
                SignIn();
            }
            else if (input == 2)
            {
                Login();
            }
            Console.ReadLine();
        }

        public static void SignIn()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;

            Console.Write("User name: ");
            string usernameInput = Console.ReadLine();
            Console.Write("Enter FulName : ");
            string fulnameinput = Console.ReadLine();
            Console.Write("Enter Phone Number : ");
            string numberinput = Console.ReadLine();
            Console.Write("Set your personal password: ");
            string passwordInput = Console.ReadLine();


            string path = Path.Combine("C:\\Tekshir\\Registratsiya", $"{usernameInput+passwordInput}.txt");

            if (File.Exists(path))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("This account is already registered!");
            }
            else
            {
                File.Create(path).Close();
                using(StreamWriter sw = new StreamWriter(path))
                {
                    sw.WriteLine("Username : " +  usernameInput);
                    sw.WriteLine("Ful Name : " +  fulnameinput);
                    sw.WriteLine("Phone  : " +  numberinput);
                    sw.WriteLine("Pasword : " +  passwordInput);
                }

                Start();
            }
        }

        public static void Login()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;

            Console.Write("Enter Username: ");
            string usernameInput = Console.ReadLine();
            
                Console.Write("Enter Password: ");
                string passwordInput = Console.ReadLine();

                string account = usernameInput + passwordInput;

            string path =$"C:\\Tekshir\\Registratsiya\\{account}.txt";

            if (File.Exists(path))
            {
                    string fileContents = File.ReadAllText(path);
                    Console.WriteLine(fileContents);
                    
            }
            else
            {
                Console.Clear();

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No such account exists");

                Thread.Sleep(1000);
                Start();
            }
        }
    }
}
