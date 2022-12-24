using System;
using System.Collections.Generic;
using System.Text;

namespace laba1
{
    interface INameAndCopy
    {
        string OrgName { get; set; }
        object DeepCopy();
    }
}
