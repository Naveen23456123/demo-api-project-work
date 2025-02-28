namespace DemoAPI
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public int Pincode { get; set; }

        public List<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>()
            {
                new Employee { Id = 101, Name = "Tom", Age = 23, Gender = "male", Address = "USA", Pincode = 12121 },
                new Employee { Id = 102, Name = "John", Age = 23, Gender = "male", Address = "UK", Pincode = 54656 },
                new Employee { Id = 103, Name = "Nick", Age = 45, Gender = "male", Address = "USA", Pincode = 232332 },
                new Employee { Id = 104, Name = "Sara", Age = 22, Gender = "Female", Address = "UK", Pincode = 12121 },
                new Employee { Id = 105, Name = "Mary", Age = 34, Gender = "Female", Address = "USA", Pincode = 9867657 },

            };
            return employees;
        }

    }
}
