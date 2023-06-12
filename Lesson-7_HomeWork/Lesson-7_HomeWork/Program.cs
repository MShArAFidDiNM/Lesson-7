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

            Console.WriteLine("[1] - Sign in            [2] - Login in\n" +
                "            [3] - Delete");
            int input = int.Parse(Console.ReadLine());

            if (!(input >= 1 && input <= 3))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please enter only numbers that are in the directory");

                Thread.Sleep(1000);
                Start();
            }

            if (input == 1)
            {
                SignIn();
            }
            else if (input == 2)
            {
                Login();
            }
            else if (input == 3)
            {
                Deleete();
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
            checkNumber:
            Console.Write("Enter Phone Number : +");
            bool check = int.TryParse(Console.ReadLine(), out  int inputNumber);
            if (!check)
            {
                Console.ForegroundColor= ConsoleColor.Red;
                Console.WriteLine("Please enter the correct phone number");
                
                Thread.Sleep(750);
                goto checkNumber;
            }
            Console.Write("Set your personal password: ");
            string passwordInput = Console.ReadLine();


            string path = Path.Combine("C:\\Tekshir\\Registratsiya", $"{usernameInput+passwordInput}.txt");

            if (File.Exists(path))
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("This account is already registered!");

                Thread.Sleep(750);
                Start();
            }
            else
            {
                File.Create(path).Close();
                using(StreamWriter sw = new StreamWriter(path))
                {
                    sw.WriteLine("Username : " +  usernameInput);
                    sw.WriteLine("Ful Name : " +  fulnameinput);
                    sw.WriteLine("Phone  : " +  inputNumber);
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
        public static void Deleete()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;

            Console.Write("Enter Username: ");
            string usernameInput = Console.ReadLine();

            Console.Write("Enter Password: ");
            string passwordInput = Console.ReadLine();

            string account = usernameInput + passwordInput;

            string path = $"C:\\Tekshir\\Registratsiya\\{account}.txt";

            if (File.Exists(path))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;

                Console.WriteLine("Deleted");
                File.Delete(path);
                Thread.Sleep(1000);

                Start() ;
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
