using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace lab2
{
    public class Person
    {
        private string name;
        private string lastName;
        private DateTime birthday;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
        public DateTime Birthday
        {
            get { return birthday; }
            set { birthday = value; }
        }
        
        public int ChangeBirthday
        {
            get { return Birthday.Year; }
            set { Birthday = new DateTime(value, Birthday.Month, Birthday.Day); }
        }
        public Person(string name, string lastName, DateTime birthday)
        {
            Name = name;
            LastName = lastName;
            Birthday = birthday;
        }
        public Person()
        {
            Name = "Iryna";
            LastName = "Yudina";
            Birthday = new DateTime(2001, 01, 27);
        }
        override public string ToString()
        {
            return ($"\nInformation about subject:\n Name: {Name}\n Last Name: {LastName}\n" +
                $" Date of birthday: {Birthday}\n");
        }
        public virtual string ToShortString()
        {
            return ($"{Name} {LastName}");
        }
    }
    class Article
    {
        public string Name { get; set; }
        public string Place { get; set; }
        public DateTime Date { get; set; }
        public Article(string name, string place, DateTime date)
        {
            Name = name;
            Place = place;
            Date = date;
        }
        public Article()
        {
            Name = "Basics of OOP";
            Place = "DNU";
            Date = new DateTime(2019, 03, 20);
        }
        public override string ToString()
        {
            return ($"\nInformation about article:\n Name: {Name}\n" +
                $" Date of publishing: {Date}\n" +
                $" Place of publishing: {Place}");
        }
    }
    class GraduateStudent
    {
        private Person student;
        private Person supervisor;
        private string speciality;
        private FormOfStudy form;
        private int learningYear;
        private Article[] articles;
        public Person Student
        {
            get { return student; }
            set { student = value; }
        }
        public Person Supervisor
        {
            get { return supervisor; }
            set { supervisor = value; }
        }
        public string Speciality
        {
            get { return speciality; }
            set { speciality = value; }
        }
        public FormOfStudy Form
        {
            get { return form; }
            set { form = value; }
        }
        public int LearningYear
        {
            get { return learningYear; }
            set { learningYear = value; }
        }
        public Article[] Articles
        {
            get { return articles; }
            set { articles = value; }
        }
        public Article LastArticle
        {
            get
            {
                if (Articles[Articles.Length - 1] != null)
                {
                    Article[] ar = Articles.OrderBy(a => a.Date).ToArray();
                    return (ar[Articles.Length - 1]);
                }
                else { return null; }
            }
        }
        public GraduateStudent(Person student, Person supervisor, string speciality, FormOfStudy form, int learningYear)
        {
            Student = student;
            Supervisor = supervisor;
            Speciality = speciality;
            Form = form;
            LearningYear = learningYear;
            this.articles = new Article[0];
        }
        public GraduateStudent()
        {
            Student = new Person();
            Supervisor = new Person();
            Speciality = "Software engineering";
            Form = 0;
            LearningYear = 2024;
            this.articles = new Article[0];
        }
        public void AddArticles(params Article[] p)
        {
            int initialLength = this.articles.Length;
            Array.Resize(ref this.articles, this.articles.Length + p.Length);
            for (int i = initialLength; i < this.articles.Length; i++)
            {
                this.articles[i] = p[i - initialLength];
            }
        }
        public override string ToString()
        {
            string allInfo = ($"Information about Graduete Student\n\nStudent: {Student.ToString()}\n\n Supervisor: {Supervisor.ToString()}\n\n" +
                $" Speciality: {Speciality}\n FormOfstudy: {Form}\n" +
                $"LearningYear: {LearningYear}\n Articles:\n ");
            foreach (Article i in this.articles) { allInfo += i.ToString(); }
            return allInfo;
        }
        public virtual string ToShortString()
        {
            return ($"Information about Graduete Student\n\nStudent: {Student.ToString()}\n\n Supervisor: {Supervisor.ToString()}\n\n" +
                $" Speciality: {Speciality}\n FormOfstudy: {Form}\n" +
                $"LearningYear: {LearningYear}");
        }
    }
    public enum FormOfStudy
    {
        FullTime,
        PartTime,
        Distance
    }
    class Program
    {

        static void Main(string[] args)
        {

            ////////////////Common task///////////////////////
            Console.WriteLine(@"\\\\\\\\\\\\\\Requirements common for all variants\\\\\\\\\\\\\\\\\"+"\n\n\n\n\n\n");
            int m, n;
            Console.WriteLine("Comparation of arrays of Persons");
            int len = 0;
            string inp = "";
            string[] mn;
            while (len < 2)
            {
                Console.WriteLine(@"Enter m and n using following separators: ' ', ',', '.', ':', '\t'");
                inp = Console.ReadLine();
                mn = inp.Split(new Char[] { ' ', ',', '.', ':', '\t' });
                len = mn.Length;
            }
            mn = inp.Split(new Char[] { ' ', ',', '.', ':', '\t' });
            m = EnterPositiveInt(mn[0]);
            n = EnterPositiveInt(mn[1]);
            Person[] arr1dimention = new Person[m * n];
            Person[,] arr2dimention = new Person[m, n];
            Person[][] arrStepped = new Person[m][];
            Create2dstepped(m, n, arrStepped);
            int sssssum = 0;///testing sum of all elements of stepped array
            for (int i = 0; i < m; i++)
            {
                Console.WriteLine($"Stepped[{i}][] = new Stepped[{arrStepped[i].Length}]");
                sssssum += arrStepped[i].Length;
            }
            Console.WriteLine($"Sum of elements of stepped array = { sssssum}");
            for (int i = 0; i < arr1dimention.Length; i++)
            {
                arr1dimention[i] = new Person();
            }
            for (int i = 0; i < m; i++)
            {
                for (int k = 0; k < n; k++)
                {
                    arr2dimention[i, k] = new Person();
                }
            }
            for (int i = 0; i < m; i++)
            {
                for (int k = 0; k < arrStepped[i].Length; k++)
                {
                    arrStepped[i][k] = new Person();
                }
            }

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            for (int i = 0; i < arr1dimention.Length; i++)
            {
                arr1dimention[i].Name = "I";
            }
            stopWatch.Stop();
            TimeSpan ts1d = stopWatch.Elapsed;
            stopWatch.Start();
            for (int i = 0; i < arr2dimention.GetLength(0); i++)
            {
                for (int k = 0; k < arr2dimention.GetLength(1); k++)
                {
                    arr2dimention[i, k].Name = "I";
                }
            }
            stopWatch.Stop();
            TimeSpan ts2d = stopWatch.Elapsed;
            stopWatch.Start();
            for (int i = 0; i < m; i++)
            {
                for (int k = 0; k < arrStepped[i].Length; k++)
                {
                    arrStepped[i][k].Name = "I";
                }
            }
            stopWatch.Stop();
            TimeSpan tss = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts1d.Hours, ts1d.Minutes, ts1d.Seconds,
            ts1d.Milliseconds / 10);
            Console.WriteLine("RunTime of 1 dimentional array " + ts1d);
            Console.WriteLine("RunTime of 2 dimentional array " + ts2d);
            Console.WriteLine("RunTimes of stepped array" + tss);

            ////////Individual task////////////////////Variant 6
            Console.WriteLine("\n\n\n\n\n\n" + @"\\\\\\\\\\\\\\Requirements for 6 variant. Individual tasks\\\\\\\\\\\\\\\\\" + "\n\n\n\n\n\n");

            GraduateStudent graduateStudent = new GraduateStudent();
            Console.WriteLine("\n\n\nInitial value of Graduate student created with constructor without parameters\n\n\n");
            Console.WriteLine(graduateStudent.ToString());
            Console.WriteLine("\n\n\nEach property of Graduate student is modified, except articles\n\n\n");
            graduateStudent.Student = new Person("Maria", "Shewchenko", new DateTime(2000, 04, 04));
            graduateStudent.Supervisor = new Person("Artem", "Melnyk", new DateTime(1990, 09, 01));
            graduateStudent.Speciality = "Applied mathematics";
            graduateStudent.LearningYear = 2025;
            graduateStudent.Form = (FormOfStudy)2;
            Console.WriteLine(graduateStudent.ToShortString());
            Console.WriteLine("\n\n\nInitial value of Graduate student created, using constructor with parameters\n\n\n");
            GraduateStudent graduate = new GraduateStudent(new Person("Lydia", "Yud", new DateTime(1999, 02, 23)), new Person("Maxym", "Boyko", new DateTime(1989, 03, 24)), "Information technology", (FormOfStudy)1, 2026);
            Console.WriteLine(graduate.ToString());
            graduate.AddArticles(
                new Article("Information technology of evaluation and improvement the quality of cluster analysis", "Lviv Polytechnic Publishing House", new DateTime(2012, 08, 24)),
                new Article("Information technology for the analysis of the dynamics of the reaction rate of the operator", "Lviv Polytechnic Publishing House", new DateTime(2014, 07, 19)),
                new Article("article 1", "place 1", new DateTime(2009, 03, 07)),
                new Article("article 2", "place 2", new DateTime(2010, 04, 17)),
                new Article("article 3", "place 3", new DateTime(2013, 02, 12)),
                new Article("article 4", "place 4", new DateTime(2010, 06, 29)),
                new Article("article 5", "place 5", new DateTime(2012, 01, 14)),
                new Article("article 6", "place 6", new DateTime(2014, 07, 19)),
                new Article("article 7", "place 7", new DateTime(2014, 02, 26)),
                new Article("article 8", "place 8", new DateTime(2014, 07, 19)),
                new Article("article 9", "place 9", new DateTime(2014, 03, 19)),
                new Article("article 10", "place 10", new DateTime(2014, 07, 19)),
                new Article("article 11", "place 11", new DateTime(2015, 09, 21)),
                new Article("article 12", "place 12", new DateTime(2014, 07, 19)),
                new Article("article 13", "place 13", new DateTime(2016, 08, 14)),
                new Article("article 14", "place 14", new DateTime(2014, 07, 19)),
                new Article("article 15", "place 15", new DateTime(2017, 04, 06)),
                new Article("article 16", "place 16", new DateTime(2014, 07, 19)),
                new Article("article 17", "place 17", new DateTime(2014, 03, 29)),
                new Article("article 18", "place 18", new DateTime(2014, 07, 19)),
                new Article("article 19", "place 19", new DateTime(2018, 03, 19)),
                new Article("article 20", "place 20", new DateTime(2024, 03, 09)),
                new Article("article 21", "place 21", new DateTime(2014, 01, 20)),
                new Article("article 22", "place 22", new DateTime(2014, 07, 19)),
                new Article("article 23", "place 23", new DateTime(2018, 07, 19)),
                new Article("article 24", "place 24", new DateTime(2014, 07, 19)),
                new Article("article 25", "place 25", new DateTime(2018, 12, 24)),
                new Article("article 26", "place 26", new DateTime(2014, 07, 19)),
                new Article("article 27", "place 27", new DateTime(2019, 11, 08)),
                new Article("article 28", "place 28", new DateTime(2014, 07, 19)),
                new Article("article 29", "place 29", new DateTime(2011, 07, 19)),
                new Article("article 30", "place 30", new DateTime(2014, 07, 19)),
                new Article("article 31", "place 31", new DateTime(2010, 01, 04)));
            Console.WriteLine(graduate.ToString());
            Console.WriteLine("The last article by date");
            Console.WriteLine(graduate.LastArticle);


            int m1, n1;
            Console.WriteLine("Comparation of arrays of Articles");
            int len1 = 0;
            string inp1 = "";
            string[] mn1;
            while (len1 <2)
            {
                Console.WriteLine(@"Enter m and n using following separators: ' ', ',', '.', ':', '\t'");
                inp1 = Console.ReadLine();
                mn1 = inp1.Split(new Char[] { ' ', ',', '.', ':', '\t' });
                len1 = mn1.Length;
            }
            mn1 = inp1.Split(new Char[] { ' ', ',', '.', ':', '\t' });
            m1 = EnterPositiveInt(mn1[0]);
            n1 = EnterPositiveInt(mn1[1]);
            Article[] arr1dimentiona = new Article[m1 * n1];
            Article[,] arr2dimentiona = new Article[m1, n1];
            Article[][] arrSteppeda = new Article[m1][];
            Create2dstepped(m1, n1, arrSteppeda);
            int sssssuma = 0;///testing sum of all elements of stepped array
            for (int i = 0; i < m1; i++)
            {
                Console.WriteLine($"Stepped[{i}][] = new Stepped[{arrSteppeda[i].Length}]");
                sssssuma += arrSteppeda[i].Length;
            }
            Console.WriteLine($"Sum of elements of stepped array = { sssssuma}");
            for (int i = 0; i < arr1dimentiona.Length; i++)
            {
                arr1dimentiona[i] = new Article();
            }
            for (int i = 0; i < m1; i++)
            {
                for (int k = 0; k < n1; k++)
                {
                    arr2dimentiona[i, k] = new Article();
                }
            }
            for (int i = 0; i < m1; i++)
            {
                for (int k = 0; k < arrSteppeda[i].Length; k++)
                {
                    arrSteppeda[i][k] = new Article();
                }
            }

            Stopwatch stopWatch1 = new Stopwatch();
            stopWatch1.Start();
            for (int i = 0; i < arr1dimentiona.Length; i++)
            {
                arr1dimentiona[i].Name = "I";
            }
            stopWatch1.Stop();
            TimeSpan ts1da = stopWatch1.Elapsed;
            stopWatch1.Start();
            for (int i = 0; i < arr2dimentiona.GetLength(0); i++)
            {
                for (int k = 0; k < arr2dimentiona.GetLength(1); k++)
                {
                    arr2dimentiona[i, k].Name = "I";
                }
            }
            stopWatch1.Stop();
            TimeSpan ts2da = stopWatch1.Elapsed;
            stopWatch1.Start();
            for (int i = 0; i < m1; i++)
            {
                for (int k = 0; k < arrSteppeda[i].Length; k++)
                {
                    arrSteppeda[i][k].Name = "I";
                }
            }
            stopWatch1.Stop();
            TimeSpan tssa = stopWatch1.Elapsed;
            string elapsedTimea = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts1da.Hours, ts1da.Minutes, ts1da.Seconds,
            ts1da.Milliseconds / 10);
            Console.WriteLine("RunTime of 1 dimentional array " + ts1da);
            Console.WriteLine("RunTime of 2 dimentional array " + ts2da);
            Console.WriteLine("RunTimes of stepped array" + tssa);

        }

        private static void Create2dstepped(int m, int n, Person[][] arrStepped)
        {
            Random rand = new Random();
            int sum = m * n - 1;//чтобы убедиться что ддлинна последнего массива хотя-бы 1
            int sumremain = sum;
            for (int i = 0; i < arrStepped.Length; i++)
            {
                sumremain = sum;
                for (int k = 0; k < i; k++)
                {
                    sumremain = sumremain - arrStepped[k].Length;
                    if (sumremain < 0)
                    {
                        sumremain = 0;
                    }
                }
                int d = (m / 2) == 0 ? 1 : m / 2;
                int r = sumremain / d > 1 ? rand.Next(1, sumremain / d) : 1;
                arrStepped[i] = new Person[r];
                arrStepped[arrStepped.Length - 1] = new Person[1 + sumremain];
            }
        }
        private static void Create2dstepped(int m, int n, Article[][] arrStepped)
        {
            Random rand = new Random();
            int sum = m * n - 1;//чтобы убедиться что ддлинна последнего массива хотя-бы 1
            int sumremain = sum;
            for (int i = 0; i < arrStepped.Length; i++)
            {
                sumremain = sum;
                for (int k = 0; k < i; k++)
                {
                    sumremain = sumremain - arrStepped[k].Length;
                    if (sumremain < 0)
                    {
                        sumremain = 0;
                    }
                }
                int d = (m / 2) == 0 ? 1 : m / 2;
                int r = sumremain / d > 1 ? rand.Next(1, sumremain / d) : 1;
                arrStepped[i] = new Article[r];
                arrStepped[arrStepped.Length - 1] = new Article[1 + sumremain];
            }
        }
        private static int EnterPositiveInt()
        {
            int m = -1;
            string tmp = Console.ReadLine();
            while (!(int.TryParse(tmp, out m)) || m < 1)
            {
                Console.Write("Введите целое положительное число ");
                tmp = Console.ReadLine();
            }
            return m;
        }
        static int EnterPositiveInt(string tmp)
        {
            int m = -1;
            while (!(int.TryParse(tmp, out m)) || m < 1)
            {
                Console.Write("Введите целое положительное число ");
                tmp = Console.ReadLine();
            }
            return m;
        }
    }

}
