using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace wintest
{
    [Serializable]
    public class student
    {
        public Guid id { get; set; }
        private string xb = "男";
        public string xh { get; set; }      
        public string name { get; set; }
        public DateTime birthdate { get; set; }
        public int age { get { return DateTime.Now.Year - birthdate.Year; } }
    }
}
