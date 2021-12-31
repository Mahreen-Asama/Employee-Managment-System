using System;


namespace ClassLibraryEmployee
{
    public class Employee
    {
        public Employee()
        {
            //default constructor
        }
        public Employee(string n, int s, string d)     
        {
            name = n;
            salary = s;
            dept = d;
            taxPercentage = 15;
        }

        //........................data member taxPercentage
        private readonly int taxPercentage;

        public int TaxPer
        {
            get { return taxPercentage; }
        }

        //.......................data member id
        private int id;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        //.......................data member name
        private String name;

        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        //......................data member salary
        private int salary;

        public int Salary
        {
            get { return salary; }
            set { salary = value; }
        }

        //.......................data member dept
        private string dept;

        public string Department
        {
            get { return dept; }
            set { dept = value; }
        }

    }
}
