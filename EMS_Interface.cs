using System;
using ClassLibraryEmployee;
using ClassLibraryEmployeeRepository;

namespace ClassLibraryInterface
{
    public class EMS_Interface
    {
        public static void startEMS()
        {
            /*employe respository class just need to manage employee related information, is it suitable
             to make its objects??? to make more than one list of same employees?? 
            THere fore, we will make all functions of employee respository class "STATIC" */

            string input = string.Empty;
           
            do
            {
                Console.WriteLine("<----------------WELCOME TO EMS-------------->");
                Console.WriteLine("1. Add Employee");
                Console.WriteLine("2. Delete Employee");
                Console.WriteLine("3. Update Employee");
                Console.WriteLine("4. Calculate Tax");
                Console.WriteLine("5. Search Employee");
                Console.WriteLine("6. Write Employees to File");
                Console.WriteLine("7. Read Employees from File");
                Console.WriteLine("8. Display All Employees");
                Console.WriteLine("9. Exit Application");

                input = Console.ReadLine();
                Console.Clear();

                string name = string.Empty;
                int sal = 0;
                string dept = string.Empty;

                /*------------------ONE------------------*/
                if(input =="1")
                {
                    Console.WriteLine("<----------------Add Employee-------------->");

                    Console.Write("Enter Name: ");                      //input name
                    name = Console.ReadLine();

                    Console.Write("Enter Salary: ");
                    string s = Console.ReadLine().Replace(",", "");     //removing ',' from salary
                    bool convertable = int.TryParse(s, out int result);

                    Console.Write("Enter Department: ");                //input dept
                    dept = Console.ReadLine();

                    if (convertable)                
                    {
                        sal = int.Parse(s);
                        EmployeeRepository.AddEmployee(new Employee(name, sal, dept));   //adding employee
                        Console.WriteLine("Employee added successfully!\n");
                    }
                    else
                    {
                        Console.WriteLine("Invalid salary!\n");
                    }

                }

                /*-------------------TWO-----------------*/
                else if (input == "2")
                {
                    Console.WriteLine("<----------------Delete Employee-------------->");

                    Console.Write("Enter Employee ID: ");
                    string s = Console.ReadLine();
                    bool convertable = int.TryParse(s, out int result);

                    if (convertable)                                //if ID is integer
                    {
                        int id = int.Parse(s);
                        if(EmployeeRepository.DeleteEmployee(id))                   //calling method
                        {
                            Console.WriteLine("Employee deleted successfully!\n");
                        }
                        else
                        {
                            Console.WriteLine("Employee not found!\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid ID!\n");
                    }
                }

                /*------------------THREE------------------*/
                else if (input == "3")
                {
                    Console.WriteLine("<----------------Update Employee-------------->");

                    Console.Write("Enter Employee ID: ");
                    string s = Console.ReadLine();
                    bool convertable = int.TryParse(s, out int result);

                    if (convertable)
                    {
                        int id = int.Parse(s);
                        if(EmployeeRepository.UpdateEmployee(id))                       //calling method
                        {
                            Console.WriteLine("Employee Updated successfullly!\n");
                        }
                        else
                        {
                            //already handled in the function
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid ID\n");
                    }
                }

                /*-------------------FOUR-----------------*/
                else if (input == "4")
                {
                    Console.WriteLine("<----------------Calculate Tax-------------->");

                    Console.Write("Enter Employee ID: ");
                    string s = Console.ReadLine();
                    bool convertable = int.TryParse(s, out int result);

                    if (convertable)
                    {
                        int id = int.Parse(s);
                        string rzlt = EmployeeRepository.calculateTax(id, out int taxAmount);
                        if(rzlt==string.Empty)
                        {
                            Console.WriteLine("Employee not found\n");
                        }
                        else
                        {
                            Console.WriteLine(rzlt + "\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid ID\n");
                    }
                }

                /*------------------FIVE------------------*/
                else if (input == "5")
                {
                    Console.WriteLine("<----------------Search Employee-------------->");

                    Console.Write("Enter Employee ID: ");
                    string s = Console.ReadLine();
                    bool convertable = int.TryParse(s, out int result);

                    if (convertable)
                    {
                        if(EmployeeRepository.searchEmployee(int.Parse(s)))                  //calling method
                        {
                        }
                        else
                        {
                            Console.WriteLine("Employee not found\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid ID\n");
                    }
                }

                /*------------------SIX------------------*/
                else if (input == "6")
                {
                    Console.WriteLine("<-----------Write Employees---------->\n");
                    EmployeeRepository.SaveInfoToFile();
                    Console.WriteLine("Employees written to file successfully\n");
                }

                /*------------------SEVEN------------------*/
                else if (input == "7")
                {
                    Console.WriteLine("<-----------Read Employees---------->\n");
                    EmployeeRepository.ReadInfoFromFile();
                    Console.WriteLine("Employees read from file successfully\n");
                }

                /*------------------EIGHT------------------*/
                else if (input == "8")
                {
                    Console.WriteLine("<-------------Display Employees---------->\n");
                    EmployeeRepository.DisplayEmployeeInfo();
                }

                else if (input != "9")
                {
                    Console.WriteLine("Invalid Input!\n");
                }

            } while (input != "9");
        }
    }
}

