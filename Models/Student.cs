using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Student
    {
        public string StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public DateTime DOB { get; set; }
        public string BatchId { get; set; }
    }
}
