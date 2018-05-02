using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazing_charts_sample_program
{
    public class Patient :Amazing_charts_sample_program_Patient_Format
    {
        public Patient() { }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
        public string PhoneNumber { get ; set ; }
        public string Age { get ; set ; }
    }
}
