using Npgsql;
using System;


namespace TZ_Solarlab
{
    internal class DBControll
    {
        private NpgsqlConnection conn;// Подключение к БД
        private NpgsqlCommand comm;//Команда к БД
        private NpgsqlDataReader dr;//Считывание данных с бд

        public void Inintialize()
        {
            //Инициализация подключения, создание таблицы в случае её отсутствия
            conn = new NpgsqlConnection("Server=localhost;Port=5432;Database=Birthday;User Id=postgres;Password=admin;");
            comm = conn.CreateCommand();
            conn.Open();
            comm.CommandText = "CREATE TABLE IF NOT EXISTS bdaylist(tName TEXT PRIMARY KEY, BDate date)";
            comm.ExecuteNonQuery();
        }

        public void SelectAll()
        {
            //Вывод всех строк таблицы в консоль
            comm.CommandText = "SELECT * FROM public.bdaylist";
            dr = comm.ExecuteReader();
            while ( dr.Read())
            {
                Console.WriteLine($"Имя:{dr.GetValue(0)} День рождения:{dr.GetValue(1)}\n");
            }
            dr.Close();
        }

        public void Select()
        {
            //Вывод сегодняшних и ближайших ДР
            comm.CommandText = "SELECT * FROM public.bdaylist WHERE date_part('day',BDate) = date_part('day',CURRENT_DATE) OR date_part('day',CURRENT_DATE) - date_part('day',BDate) < 7";
            dr = comm.ExecuteReader();
            while (dr.Read())
            {
                Console.WriteLine($"Имя:{dr.GetValue(0)} День рождения:{dr.GetValue(1)}\n");
            }
            dr.Close();
        }

        public void Add(DateTime birthday, string name)
        {
            //Добавление записи в таблицу
            comm.CommandText = "INSERT INTO public.bdaylist (Name, BDate) VALUES (@Name, @BDate)";
            comm.Parameters.AddWithValue("Name", name);
            comm.Parameters.AddWithValue("BDate", birthday);
            comm.ExecuteNonQuery();
        }

        public void Delete(string name) 
        {
            //Удаление записи из таблицы
            comm.CommandText = $"DELETE FROM public.bdaylist WHERE Name = '{name}'";
            comm.ExecuteNonQuery();
        }

        public void DataUpdate(string name,DateTime birthday)
        {
            //Редактирование записи 
            comm.CommandText = $"UPDATE public.bdaylist SET BDate = '{birthday}' WHERE Name = '{name}'";
            comm.ExecuteNonQuery();
        }
    }
}
