using System;

namespace TZ_Solarlab
{
    internal class Program
    {
        /* 
        Уровень 2
         Консольное .NET-приложение, информация хранится в объектах, персистентность
        которых реализуется с помощью использования БД. Управление через меню, по умолчанию при
        запуске программа выдает список сегодняшних и ближайших ДР
         */
        static void Main(string[] args)
        {
            IControllable Person = new PersonDBControll();
            
            Person.Open();
            while (true)
            {
                Console.WriteLine(
                        "1 - Отображение всего списка ДР \n"
                    +   "2 - ближайшие ДР \n"
                    +   "3 - добавление ДР \n"
                    +   "4 - удаление ДР \n"
                    +   "5 - редактирование ДР \n");

                var n = int.Parse(Console.ReadLine());
                switch (n)
                {
                    case 1:
                        Person.OpenAll();
                        break;
                    case 2:
                        Person.Open();
                        break;
                    case 3:
                        Person.Create();
                        break;
                    case 4:
                        Person.Destroy();
                        break;
                    case 5:
                        Person.Update();   
                        break;
                    default: Console.WriteLine("Неправильный ввод данных"); 
                        break;
                }
            }
        }
    }
}
