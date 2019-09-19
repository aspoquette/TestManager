using System.Collections.Generic;

namespace TestManager.DataLayer
{
    class Company
    {
        public List<Student> CompanyMembers { get; set; } = new List<Student>();
        public int CompanyNumber { get; set; }
        public int StationsCompleted { get; set; }
    }
}
