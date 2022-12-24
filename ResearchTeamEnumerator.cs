using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace laba1
{
    class ResearchTeamEnumerator : IEnumerator
    {
        private Person current;
        private int position;
        private readonly ArrayList mems;
        private readonly ArrayList paps;

        public ResearchTeamEnumerator(ArrayList members, ArrayList papersList)
        {
            paps = papersList;
            mems = members;
            position = 0;
            current = mems[0] as Person;
        }

        public object Current
        {
            get { return current; }
        }

        public bool MoveNext()
        {
            for (int i = position; i < mems.Count; i++)
            {
                for (int k = 0, max = paps.Count; k < max; k++)
                    if ((paps[k] as Paper).Author.ToString() == (mems[i] as Person).ToString())
                    {
                        position = i + 1;
                        current = mems[i] as Person;
                        return true;
                    }
            }
            return false;
        }

        public void Reset()
        {
            current = mems[0] as Person;
            position = 0;
        }
    }
}
