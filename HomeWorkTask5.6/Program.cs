namespace HomeWorkTask5._6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var userInfo = UserInfo();
            ShowInfo(userInfo);
        }

        static (string name, string secondName, int age, string[] pets,
            string[] favColors) UserInfo()
        {
            (string name, string secondName, int age, string[] pets,
                string[] favColors) User;

            Console.Write("Введите своё имя: ");
            User.name = Console.ReadLine();

            Console.Write("Введите свою фамилию: ");
            User.secondName = Console.ReadLine();

            string age;
            int intage;
            do
            {
                Console.Write("Введите свой возраст цифрами: ");
                age = Console.ReadLine();
            } while (CheckNum(age, out intage));

            User.age = intage;

            Console.Write("У Вас есть домашний питомец? Введите Да или Нет: ");
            string countPet = "Нет";
            int countIntPet;

            if (Console.ReadLine() == "Да")
            {
                Console.Write("Введите количество цифрами: ");
                countPet = Console.ReadLine();
                CheckNum(countPet, out countIntPet);
                User.pets = CreateArray(countIntPet);
            }
            else 
            { 
                User.pets = new string[] { "Домашних животных нет." };
            }

            Console.Write("Введите количесто любимых цветов: ");
            string countColors = Console.ReadLine();
            int countIntColors;
            CheckNum(countColors, out countIntColors);
            User.favColors = CreateArray(countIntColors);

            return (User.name, User.secondName, User.age, User.pets, User.favColors);

        } 

        static bool CheckNum(string number, out int corrnumber)
        {
            corrnumber = 0;

            if(int.TryParse(number, out int intnum))
            {
                if (intnum > 0)
                {
                    corrnumber = intnum;
                    return false;
                }

            }
            else
            {
                corrnumber = 0;
                return true;
            }

            return true;
        }

        static string[] CreateArray(int num)
        {
            var result = new string[num];

            for(int i = 0; i < num; i++)
            {
                Console.Write("Введите название и нажмите Enter: ");
                result[i] = Console.ReadLine();
            }
            
            
            return result;
        }

        static (string name, string secondName, int age, string[] pets,
            string[] favColors) ShowInfo((string name, string secondN, int age,
            string[] pets, string[] favColors) User)
        {
            string petFor = string.Join(", ", User.pets);
            string colorFor = string.Join(", ", User.favColors);
            Console.WriteLine("\tВаши данные: {0} {1}, {2}, {3} {4}.", User.name, User.secondN, User.age, petFor, colorFor);

            return User;
        }
    }
}