using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L1_3_1
{
    public struct Subject
    {
        public string name;
        public string specialty;
        public int semestr;
        public int countLEChours;
        public int countLABhours;
        public Prepod prep;
        public Subject(int a, int b, int c)
        {
            name = " ";
            specialty = " ";
            semestr = 0;
            countLEChours = 0;
            countLABhours = 0;
            prep = new Prepod(" ", " ", " ");
        }
        public void Input()
        {
            Console.WriteLine("Введите название дисциплины");
            name = Console.ReadLine();
            Console.WriteLine("Введите специальность");
            specialty = Console.ReadLine();
            Console.WriteLine("Введите семестр");
            semestr = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите количество лекционных часов");
            countLEChours = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите количество лабараторных часов");
            countLABhours = Convert.ToInt32(Console.ReadLine());
            prep.InputPrepod();
        }
        public void Output()
        {
            Console.Write("Subj {0,8} | спец. {1} | семестр {2} | кол-во лекц {3} | кол-во лаб {4} |", name, specialty, semestr, countLEChours, countLABhours);
            prep.OutputPrepod();
        }
    }
    public struct Prepod
    {
        public string surnameNinitials;
        public string lector;
        public string LABTeacher;
        public Prepod(string a, string b, string c)
        {
            surnameNinitials = a;
            lector = b;
            LABTeacher = c;
        }
        public void InputPrepod()
        {
            Console.WriteLine("Введите фамилию и иницалы перподавателя");
            surnameNinitials = Console.ReadLine();
            Console.WriteLine("Преподаватель - лектор?");
            lector = Console.ReadLine();
            Console.WriteLine("Преподаватель - преподаватель для проведения лабораторных занятий?");
            LABTeacher = Console.ReadLine();
        }
        public void OutputPrepod()
        {
            Console.WriteLine(" Преподаватель {0,8} | Лектор? {1} | Преподаватель для проведения лабораторных занятий? {2} |", surnameNinitials, lector, LABTeacher);
        }
    }
    class Program
    {
        static void InputArraySub(Subject[] sub)
        {
            for (int i = 0; i < sub.Length; i++)
            {
                sub[i].Input();
            }
        }
        static Subject Search(Subject[] sub, int num)
        {
            for (int i = 0; i < sub.Length; i++)
            {
                if (sub[i].semestr == num)
                {
                    return sub[i];
                }
            }
            return sub[0];
        }
        static Subject Search2(Subject[] sub, string n)
        {
            for (int i = 0; i < sub.Length; i++)
            {
                if (String.Compare(sub[i].prep.lector, n, true) == 0)
                {
                    return sub[i];
                }
            }
            return sub[0];
        }
        static void OutputSearched(Subject stud)
        {
            int count = 0;
            if (count < 1)
            {
                stud.Output();
            }
        }
        static void OutputArraySub(Subject[] sub)
        {
            foreach (var item in sub)
            {
                item.Output();
            }
        }
        static void Menu()
        {
            Console.WriteLine("Для поиска по номеру семестра введите 1");
            Console.WriteLine("Для поиск должности преподавателя введите 2");
        }
        static void Switches(Subject[] subo)
        {
            int s = Convert.ToInt16(Console.ReadLine());

            switch (s)
            {
                case 1:
                    Console.WriteLine("Введите номер семестра");
                    int num = Convert.ToInt32(Console.ReadLine());
                    Subject stfu = Search(subo, num);
                    Console.WriteLine("Предмет этого семестра:");
                    OutputSearched(stfu);
                    Console.WriteLine();
                    break;
                case 2:
                    Console.WriteLine("Преподаватель лектор? да/нет");
                    string nu = Console.ReadLine();
                    Subject stfu2 = Search2(subo, nu);
                    OutputSearched(stfu2);
                    break;
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введите кол-во дисциплин");
            int size = Convert.ToInt32(Console.ReadLine());
            Subject[] sub = new Subject[size];
            for (int i = 0; i < size; i++)
            {
                sub[i] = new Subject(0, 0, 0);
            }
            InputArraySub(sub);
            OutputArraySub(sub);
            int count = 0;
            while (count == 0 || Console.ReadLine() == "да")
            {
                Console.WriteLine();
                Menu();
                Switches(sub);
                count++;
            }
            Console.ReadLine();
        }
    }
}


