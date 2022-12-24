using System;
using System.Collections.Generic;
using System.Text;

namespace laba1
{
    class Team: INameAndCopy
    {
        protected string orgName;
        protected int regNum;

        public Team(string _orgName, int _regNum)
        {
            orgName = _orgName;
            regNum = _regNum;
        }

        public Team()
        {
            orgName = "OrgzName";
            regNum = 0;
        }

        public int RegNum
        {
            get { return regNum; }
            set
            {
                if (value <= 0)
                    throw new Exception("Регистрационный номер должен быть положительным числом");
                else regNum = value;
            }
        }

        public string OrgName
        {
            get { return orgName; }
            set { orgName = value; }
        }

        public virtual object DeepCopy()
        {
            Team temp = new Team(this.orgName, this.regNum);
            return temp;
        }

        public override bool Equals(object obj)
        {
            if (obj != null && (obj is Team))
                return this == (Team)obj;
            else return false;
        }

        public static bool operator ==(Team t1, Team t2)
        {
            if (t1.regNum == t2.regNum && t1.orgName == t2.orgName) return true;
            else return false;
        }

        public static bool operator !=(Team t1, Team t2)
        {
            if (t1.regNum != t2.regNum || t1.orgName != t2.orgName) return true;
            else return false;
        }

        public override string ToString()
        {
            string s = "Название организации: " + orgName + ", Регистрационный номер " + regNum;
            return s;
        }

        public override int GetHashCode()
        {
            return orgName.GetHashCode() ^ regNum.GetHashCode();
        }
    }
}
