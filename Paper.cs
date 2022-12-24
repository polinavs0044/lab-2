using System;
using System.Collections.Generic;
using System.Text;

namespace laba1
{
    public enum TimeFrame { Year, TwoYears, Long };

    class Paper
    {
        public string Title { get; set; }
        public Person Author { get; set; }
        public DateTime Date { get; set; }

        public Paper(string title, Person author, DateTime date)
        {
            Title = title;
            Author = author;
            Date = date;
        }

        public Paper()
        {
            Title = "Title";
            Author = new Person();
            Date = new DateTime(1978, 2, 9);
        }

        public override string ToString()
        {
            string s = "Title: " + Title + "; author: " + Author.ToString() + "; date: " + Date.ToLongDateString();
            return s;
        }
    }
}
