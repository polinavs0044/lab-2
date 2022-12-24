using System;

namespace laba1
{
    class Program
    {
        static void Main(string[] args)
        {
            Team t1 = new Team("Organization 1", 11);
            Team t2 = new Team("Organization 1", 11);
            if (t1 == t2) Console.WriteLine("Равенство по значению: true");
            else Console.WriteLine("Равенство по значению: false");
            object tt1 = t1;
            object tt2 = t2;
            if (tt1 == tt2) Console.WriteLine("Равенство по ссылке: true");
            else Console.WriteLine("Равенство по ссылке: false");
            Console.WriteLine("Хэш-код первого объекта: " + t1.GetHashCode());
            Console.WriteLine("Хэш-код второго объекта: " + t2.GetHashCode());
            Console.WriteLine();
            Console.WriteLine("Cообщение об ошибке:");
            try
            {
                t1.RegNum = -100;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine();
            ResearchTeam resT = new ResearchTeam("My Topic", "New Organization", 789, TimeFrame.TwoYears);           
            Person ann  = new Person("Ann", "Pilova", new DateTime(1989, 9, 18));
            Person mary  = new Person("Mary", "Mitchell", new DateTime(1994, 2, 24));
            Person tony = new Person("Tony", "Montana", new DateTime(1995, 12, 12));
            Paper p1 = new Paper("Name of paper 1", tony, new DateTime(2010, 12, 3));
            Paper p2 = new Paper("Name of paper 2", ann, new DateTime(2018, 3, 2));
            Paper p3 = new Paper("Name of papaer 3", mary, new DateTime(2022, 12, 24));
            resT.AddMembers(tony, ann, mary);
            resT.AddPapers(p1, p2, p3);
            Console.WriteLine("    Созданный объект ResearchTeam:");
            Console.WriteLine(resT.ToString());
            Console.WriteLine("    Свойство типа Team:");
            Console.WriteLine(resT.ToBaseTeam.ToString());
            Console.WriteLine();
            ResearchTeam resTCopy = (ResearchTeam)resT.DeepCopy();
            (resT.PapersList[0] as Paper).Author = ann;
            resT.OrgName = "Other Organization";
            resT.Topic = "Other Topic";
            Console.WriteLine("        Скопированный объект");
            Console.WriteLine(resTCopy.ToString());
            Console.WriteLine("        Исходный объект (изменён)");
            Console.WriteLine(resT.ToString());
            Console.WriteLine("      Не имеют публикаций:");
            foreach (Person x in resT.GetMemsNoPaps())         
                Console.WriteLine(x);
            Console.WriteLine("      Публикации за последние 10 лет:");
            foreach (Paper x in resT.GetPapForYears(10))
                Console.WriteLine(x);
            Console.WriteLine("      Публикации за последний год:");
            foreach (Paper x in resT.GetLastPaps())
                Console.WriteLine(x);
            Console.WriteLine("      Имеют более одной публикации:");
            foreach (Person x in resT.GetMemsMuchPaps())
                Console.WriteLine(x);
            Console.WriteLine("      Имеют публикации:");
            foreach (Person x in resT)
                Console.WriteLine(x);
        }
    }
}



//теория
/*Реализация виртуального метода bool Equals (object obj) в классе System.Object определяет равенство объектов как равенство ссылок на объекты. Некоторые классы из базовой библиотеки BCL переопределяют метод Equals(). В классе System.String этот метод переопределен так, что равными считаются строки, которые совпадают посимвольно. Реализация метода Equals() в структурном типе DateTime равенство объектов DateTime определяет как равенство значений.
В лабораторной работе требуется переопределить метод Equals так, чтобы объекты считались равными, если равны все данные объектов. Для класса Person это означает, что равны даты рождения и посимвольно совпадают строки с именем и фамилией.
Определение операций должно быть согласовано с переопределенным методом Equals, т.е. критерии, по которым проверяется равенство объектов в методе Equals, должны использоваться и при проверке равенства объектов в операциях и !=. 
Переопределение виртуального метода int GetHashCode() также должно быть согласовано с операциями == и !=. Виртуальный метод GetHashCode() используется некоторыми классами базовой библиотеки, например, коллекциями-словарями. Классы базовой библиотеки, вызывающие метод GetHashCode() из пользовательского типа, предполагают, что равным объектам отвечают равные значения хэш-кодов. Поэтому в случае, когда под равенством объектов понимается совпадение данных (а не ссылок), реализация метода GetHashCode() должна для объектов с совпадающими данными возвращать равные значения хэш-кодов.
В классах, указанных в вариантах лабораторной работы, требуется определить метод object DeepCopy() для создания полной копии объекта. Определенные в некоторых классах базовой библиотеки методы Clone() и Сору() создают ограниченную (shallow) копию объекта при копировании объекта копии создаются только для полей структурных типов, для полей ссылочных типов копируются только ссылки. В результате в ограниченной копии объекта поля-ссылки указывают на те же объекты, что и в исходном объекте.
Метод DeepCopy() должен создать полные копии всех объектов, ссылки на которые содержат поля типа. После создания полная копия не зависит от исходного объекта - изменение любого поля или свойства исходного объекта не должно приводить к изменению копии.
При реализации метода DeepCopy() в классе, который имеет поле типа System.Collections.ArrayList, следует иметь в виду, что определенные в классе ArrayList конструктор ArrayList(lCollection) и метод Clone() при создании копии коллекции, состоящей из элементов ссылочных типов, копируют только ссылки.
Метод DeepCopy() должен создать как копии элементов коллекции ArrayList, так и полные копии объектов, на которые ссылаются элементы коллекции. Для типов, содержащих коллекции, реализация метода DeepCopy() упрощается, если в типах элементов коллекций также определить метод DeepCopy()•
*/