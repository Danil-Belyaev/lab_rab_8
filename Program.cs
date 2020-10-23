using System;
using System.Data;
using System.Security.Cryptography.X509Certificates;

namespace _8._ПРОЕКТИРОВАНИЕ_ИЕРАРХИИ_КЛАССОВ
{

    public enum Proiz { Asus, Acer, HP, Apple, Huawei}
    public enum Diagonal { тринадцатидюймовый, четырнадцатидюймовый, пятнадцатидюймовый }

    class ComputerTechnology
    {
        public ComputerTechnology(int ГВ, int Ц, int СЭ)
        {
            ГодВыпуска = ГВ;
            Цена = Ц;
            СрокЭксплуатации = СЭ;
        }

        public ComputerTechnology()
        {
            ГодВыпуска = 2001;
            Цена = 1000;
            СрокЭксплуатации = 0;
        }

        public int ГодВыпуска, Цена, СрокЭксплуатации;

        public virtual string Info
        {
            get { return "Год выпуска : " + ГодВыпуска + ", Цена: " + Цена + ", Срок эксплуатации: " + СрокЭксплуатации; }
        }

        public virtual void СрокСлужбы(int СС)
        {
            int Срокcлужбы = 50;
            Срокcлужбы = СС;
        }

        public void CW()
        {
            Console.WriteLine();
        }

    }

    class Server : ComputerTechnology
    {
        public Server() : base()
        {
            Производитель = Proiz.Acer;
        }

        public Server(int ГВ, int Ц, int СЭ, Proiz П) :base(ГВ, Ц, СЭ)
        {
            Производитель = П;
        }
        public Proiz Производитель;

        public override string Info
        {
            get {return base.Info + ", Производитель: " + Производитель.ToString(); }
        }
    }

    class Laptop : ComputerTechnology
    {
        public Laptop(int ГВ, int Ц, int СЭ, Diagonal Диаг) : base(ГВ, Ц, СЭ)
        {
            Диагональ = Диаг;
        }
        public Diagonal Диагональ;

        public override string Info
        {
            get { return base.Info + ", Диагональность: " + Диагональ.ToString(); }
        }
    }

    class PersonalComputer : ComputerTechnology
    {
        public PersonalComputer(int ГВ, int Ц, int СЭ) : base(ГВ, Ц, СЭ) { }
            
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Массив КомпТехники
            ComputerTechnology[] mas = new ComputerTechnology[4];

            // Заполнение массива
            mas[0] = new ComputerTechnology(2001, 5000, 19);
            mas[1] = new Server(2002, 20000, 18, Proiz.Acer );
            mas[2] = new Laptop(2003, 25000, 17, Diagonal.четырнадцатидюймовый);
            mas[3] = new PersonalComputer(2004, 100000, 16);

            // Вывод информации
            ComputerTechnology s1 = new ComputerTechnology(); // Использование базового метода отличного от конструктора
            s1.CW();
            for (int i = 0; i < mas.Length; i++)
            {
                Console.WriteLine("Имя класса: " + mas[i].GetType().Name);
                Console.WriteLine(mas[i].Info);
                s1.CW();
            }
        }
    }
}
