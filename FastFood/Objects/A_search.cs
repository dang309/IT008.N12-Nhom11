using System;
using System.Collections.Generic;
using System.Text;

namespace FastFood.Objects
{
    public class A_search
    {
        public const int NAME = 0;
        public const int ID = 1;
        public const int HISTORY = 2;

        public string Search_Content { get; set; }
        public int type { get; set; }
        public An_emp Associated_emp { get; set; }
    }
}
