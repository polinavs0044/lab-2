using System;
using System.Collections.Generic;
using System.Text;

namespace laba1
{
    class Person
    {
        private string name;
        string lastName;
        DateTime birth;

        public Person(string name, string lastName, System.DateTime birth)
        {
            this.name = name;
            this.lastName = lastName;
            this.birth = birth;
        }

        public Person()
        {
            name = "Name";
            lastName = "LastName";
            birth = new DateTime(1906, 3, 8);
        }

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

        public System.DateTime Birth
        {
            get { return birth; }
            set { birth = value; }
        }

        public int Year
        {
            get { return birth.Year; }
            set { birth = new DateTime(value, birth.Month, birth.Day); }
        }

        public override string ToString()
        {
            string s = name + " " + lastName + "; birth: " + birth.ToLongDateString();
            return s;
        }

        public virtual string ToShortString()
        {
            string s = name + " " + lastName;
            return s;
        }
    }
}
