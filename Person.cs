using System;

namespace TZ_Solarlab
{
    internal class PersonDBControll : DBControll, IControllable
    {
        private string Name;
        private string Birthday;

        public PersonDBControll()
        {
            Inintialize();
        }

        public void Open()
        {
            Console.WriteLine("Ближайшие дни рождения:\n");
            Select();
        }

        public void OpenAll()
        {
            Console.WriteLine("Список ДР:\n");
            SelectAll();
        }

        public void Create()
        {
            Console.WriteLine("Введите имя человека:\n");
            Name = Console.ReadLine();
            Console.WriteLine("Введите дату рождения в формате гг-мм-дд:\n");
            Birthday = Console.ReadLine();
            Add(DateTime.Parse(Birthday), Name);
            Console.WriteLine("Запись создана \n");
        }

        public void Destroy()
        {
            Console.WriteLine("Введите имя человека:\n");
            Name = Console.ReadLine();
            Delete(Name);
            Console.WriteLine("Запись удалена \n");
        }

        public void Update()
        {
            Console.WriteLine("Введите имя человека, дату рождения которого требуется изменить:\n");
            Name = Console.ReadLine();
            Console.WriteLine("Введите дату рождения в формате гг-мм-дд:\n");
            Birthday = Console.ReadLine();
            DataUpdate(Name, DateTime.Parse(Birthday));
            Console.WriteLine("Запись изменена \n");
        }
 
    }
}
