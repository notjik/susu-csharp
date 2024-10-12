using System;

namespace Lab2
{
    internal abstract class Program
    {
        private static string ChinaAnimal(int year)
        {
            string[] animals =
            {
                "Крыса", "Бык", "Тигр", "Кролик", "Дракон", "Змея", "Лошадь", "Коза", "Обезьяна", "Петух", "Собака",
                "Свинья" // 12 животных
            };
            string[] colors =
            {
                "Зелёный", "Красный", "Жёлтый", "Белый", "Чёрный" // 5 цветов повторяются
            };
            try
            {
                return colors[(year - 4) % 10 / 2] + " " + animals[(year - 4) % 12]; // Китайский год = наш - 4
            }
            catch (IndexOutOfRangeException _)
            {
                return "";
            }
        }

        private static string WestZodiac(int month, int day)
        {
            string[] zodiacSigns =
            {
                "Козерог", // 0 (январь с нуля)
                "Водолей", // 1
                "Рыбы", // 2
                "Овен", // 3
                "Телец", // 4
                "Близнецы", // 5
                "Рак", // 6
                "Лев", // 7
                "Дева", // 8
                "Весы", // 9
                "Скорпион", // 10
                "Стрелец", // 11
                "Козерог" // 12 (для конца декабря)
            };
            return month switch
            {
                1 => day < 20 ? zodiacSigns[12] : zodiacSigns[1] // Козерог или Водолей
                ,
                2 => day < 19 ? zodiacSigns[1] : zodiacSigns[2] // Водолей или Рыбы
                ,
                3 => day < 21 ? zodiacSigns[2] : zodiacSigns[3] // Рыбы или Овен
                ,
                4 => day < 20 ? zodiacSigns[3] : zodiacSigns[4] // Овен или Телец
                ,
                5 => day < 21 ? zodiacSigns[4] : zodiacSigns[5] // Телец или Близнецы
                ,
                6 => day < 21 ? zodiacSigns[5] : zodiacSigns[6] // Близнецы или Рак
                ,
                7 => day < 23 ? zodiacSigns[6] : zodiacSigns[7] // Рак или Лев
                ,
                8 => day < 23 ? zodiacSigns[7] : zodiacSigns[8] // Лев или Дева
                ,
                9 => day < 23 ? zodiacSigns[8] : zodiacSigns[9] // Дева или Весы
                ,
                10 => day < 23 ? zodiacSigns[9] : zodiacSigns[10] // Весы или Скорпион
                ,
                11 => day < 22 ? zodiacSigns[10] : zodiacSigns[11] // Скорпион или Стрелец
                ,
                12 => day < 22 ? zodiacSigns[11] : zodiacSigns[12] // Стрелец или Козерог
                ,
                _ => ""
            };
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Введите дату в формате \"год-месяц-день\"");
            var numbers = Console.ReadLine()?.Split('-');
            if (numbers is not { Length: 3 })
            {
                return; // Проверяем на количество
            }
            int year = int.Parse(numbers[0]);
            int month = int.Parse(numbers[1]);
            int day = int.Parse(numbers[2]);
            Console.WriteLine(ChinaAnimal(year));
            Console.WriteLine(WestZodiac(month, day));
        }
    }
}