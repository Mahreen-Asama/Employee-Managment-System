using System;
using System.Collections.Generic;
using ClassLibraryEmployee;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;

namespace ClassLibraryEmployeeRepository
{
    public class EmployeeRepository
    {
        static List<Employee> empData = new List<Employee>();
        
        static int count = 0;

        public static void AddEmployee(Employee e)
        {
            /*
             * function adds a new employee in the list
             * arguments: employee to be added
             * return: nothing 
            */
            e.ID = count;               //emp ID next to next
            count++;
            empData.Add(e);
        }

        public static bool DeleteEmployee(int id)
        {
            /*
             * function deletes an employee from employees list
             * arguments: ID of employee to be deleted
             * return: true if deleted successfully, else false
            */
            bool del = false;
            foreach (Employee e in empData)
            {
                if(e.ID==id)
                {
                    del = empData.Remove(e);                
                    break;
                }
            }
            return del;
        }

        public static bool UpdateEmployee(int id)
        {
            /*
             * function updates an employees data (using approach-> first delete then add)
             * arguments: ID of employee to update its data
             * return: true if updated successfully, else false
            */

            if (DeleteEmployee(id))                                  //calling delete method
            {
                Console.Write("Enter Name: ");
                string n = Console.ReadLine();

                Console.Write("Enter Salary: ");
                string s = Console.ReadLine().Replace(",", "");
                bool convertable = int.TryParse(s, out int result);

                Console.Write("Enter Department: ");
                string dept = Console.ReadLine();

                if (convertable)
                {
                    AddEmployee(new Employee(n, int.Parse(s), dept));       //add employee
                    return true;
                }
                else
                {
                    Console.WriteLine("Invalid Salary!\n");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("Employee not found\n");
                return false;
            }
        
        }

        public static string calculateTax(int id, out int tax)
        {
            /*
             * function calculates taxAmount as 15% from salary for a particular employee
             * arguments: ID of employee to calculate its tax
             * return: calculated taxAmount in msg/string form, empty string if employee not found
            */
            tax = 0;
            foreach (Employee e in empData)
            {
                if (e.ID == id)
                {
                    tax = (e.Salary * 15) / 100;
                    string ret = string.Format(
                        format: "Tax Amount for {0} is: {1:C}",
                        arg0: e.Name,
                        arg1: tax
                        );
                    return ret;
                }
            }
            return string.Empty;                                //if employee not found
        }

        public static bool searchEmployee(int id)
        {
            /*
             * function searches for a particular employee and displays its info
             * arguments: employee ID 
             * return: true if employee searched, else false
            */
            foreach (Employee e in empData)
            {
                if(e.ID==id)
                {
                    calculateTax(e.ID, out int tax);

                    Console.WriteLine(
                        format: "Employee ID: {0}\nEmployee Name: {1}\nEmployee Salary: {2:N0}",
                        arg0: e.ID,
                        arg1: e.Name,
                        arg2: e.Salary
                        ) ;
                    Console.WriteLine(
                        format: "Employee Department: {0}\nTaxAmount {1:C}",
                        arg0: e.Department,
                        arg1: tax
                        ) ; 
                    Console.WriteLine();

                    return true;
                }
            }
            return false;
        }

        public static void SaveInfoToFile()
        {
            /*
             * function saves/writes all employees data into file
             * arguments: no
             * return: nothing
            */
            StreamWriter sw = new StreamWriter("Employee.txt", append:true);
            foreach(Employee e in empData)
            {
                string info = JsonSerializer.Serialize(e);
                /*Console.WriteLine(info);*/
                sw.WriteLine(info);
            }
            sw.Close();
        }

        public static List<Employee> ReadInfoFromFile()
        {
            /*
            * function reads all employees from file and add them in list
            * arguments: no
            * return: list of employees read from file
           */
            List<Employee> empList = new List<Employee>();

            StreamReader sr = new StreamReader("Employee.txt");

            string line = string.Empty;

            while((line=sr.ReadLine())!=null)
            {
                /*Console.WriteLine(line);*/
                Employee e = JsonSerializer.Deserialize<Employee>(line);
                empList.Add(e);
            }
            sr.Close();
            return empList;
        }

        public static void DisplayEmployeeInfo()
        {
            /*
             * function displays info of all employees 
             * arguments: no 
             * return: nothing
            */
            foreach (Employee e in empData)
            {
                calculateTax(e.ID, out int tax);

                Console.WriteLine(
                    format: "Employee ID: {0}\nEmployee Name: {1}\nEmployee Salary: {2:N0}",
                    arg0: e.ID,
                    arg1: e.Name,
                    arg2: e.Salary
                    );
                Console.WriteLine(
                    format: "Employee Department: {0}\nTaxAmount {1:C}",
                    arg0: e.Department,
                    arg1: tax
                    );
                Console.WriteLine();
            }
        }

    }
}
