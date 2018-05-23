using System;
using System.Text;
using System.Text.RegularExpressions;

namespace TextValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Виправлення кодування консолі для правильного виведення символів кирилиці
            Console.OutputEncoding = Encoding.UTF8;

            // Паттерн для перевірки чи весь текст російською мовою
            string pattern1 = "^[\\Wа-я0-9]*([а-я]+)[\\Wа-я0-9]*$";
             // Паттерн для перевірки наявность російських символів
            // в тексті разом з іншими символами
            string pattern2 = "^[\\w\\W]*([а-я]+)[\\w\\W]*$";

            Console.Write("Введіть текст:\n > ");

            // Зчитування скроки з терміналу
            string input = Console.ReadLine();

            // Додаткові параиетри для регулярних виразів
            // (Кодування UTF-8 | Ігнорування реєстру символів)
            RegexOptions options = RegexOptions.CultureInvariant | RegexOptions.IgnoreCase;

            // Регулярні вирази
            Regex regex1 = new Regex(pattern1, options);    // Тільки російська
            Regex regex2 = new Regex(pattern2, options);    // Російська разом з іншими мовами

            if (regex1.IsMatch(input))  // Перевірка першого регулярного виразу
            {
                Console.WriteLine("Введена строка складається тільки з російських символів");
            }
            else if (regex2.IsMatch(input))     // Перевірка другого регулярного виразу
            {
                Console.WriteLine("Введена строка містить російські символи, та символи інших мов");
            }
            else
            {
                Console.WriteLine("Введена строка не містить російських символів");
            }

            // Закриття терміналу після натискання клавіши на клавіатурі
            Console.ReadKey();
        }
    }
}
