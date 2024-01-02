namespace LearnDapper.Model
{
    public class Employee
    {
        public int employee_id { get; set; }
        public string first_name { get; set; }
        public string middle_name { get; set; }
        public string last_name { get; set; }
        public int job_id { get; set; }
        public int salary { get; set; }
        public string birth_date { get; set; }
        public string hire_date { get; set; }
        public int department_id { get; set; }
        public int manager_id { get; set; }
        public string phone { get; set; }
        public string street_address { get; set; }
        public string city { get; set; }
        public string state_province { get; set; }
        public string postal_code { get; set; }
        public int country_id { get; set; }
        public string termination_date { get; set; }
    }
}
