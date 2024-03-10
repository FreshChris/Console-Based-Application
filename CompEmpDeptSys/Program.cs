using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CompEmpDeptSys
{
    class Program
    {
        private static string employeefile = @"..\..\data\employee.csv";
        private static string deptfile = @"..\..\data\dept.csv";

        private static List<Employee> employeelist = new List<Employee>();
        private static List<Department> deptlist = new List<Department>();

        public static void SaveDepartment()
        {
            StreamWriter sw = new StreamWriter(deptfile);

            sw.WriteLine("Dept ID" + "," + "Department Name");

            foreach (Department dpt in deptlist)
            {
                sw.WriteLine(dpt.ToCSV());
            }
            sw.Close();
        }

        public static void LoadDepartment()
        {
            if (File.Exists(deptfile))
            {
                var lines = File.ReadAllLines(deptfile).Skip(1);

                foreach (string line in lines)
                {
                    if (line != null)
                    {
                        string[] fields = line.Split(',');

                        string deptid = fields[0].Trim();
                        string deptnam = fields[1].Trim();

                        Department obj = new Department(deptid, deptnam);
                        deptlist.Add(obj);
                    }
                }
            }
        }

        public static void SaveEmployee()
        {
            StreamWriter sw = new StreamWriter(employeefile);

            sw.WriteLine("Employee ID" + "," + "First Name" + "," + "Last Name" + "," + "Mobile No." + "," + "Email" + "," + "Joining Date" + "," + "Department ID" + "," + "Department Name");

            foreach (Employee emp in employeelist)
            {
                sw.WriteLine(emp.ToCSV());
            }
            sw.Close();
        }

        public static void LoadEmployee()
        {
            if (File.Exists(employeefile))
            {
                var lines = File.ReadAllLines(employeefile).Skip(1);

                foreach (string line in lines)
                {
                    if (line != null)
                    {
                        string[] fields = line.Split(',');

                        string stuid = fields[0];
                        string fname = fields[1];
                        string lname = fields[2];
                        string mobno = fields[3];
                        string eml = fields[4];
                        string jdate = fields[5];
                        string deptid = fields[6];
                        string deptnam = fields[7];

                        Department dptobj = new Department(deptid, deptnam);

                        Employee obj = new Employee(stuid, fname, lname, mobno, eml, jdate, dptobj);
                        employeelist.Add(obj);
                    }
                }
            }
        }

        public static bool CheckDeptID(string deptid)
        {
            bool flag = false;
            foreach (Department dpt in deptlist)
            {
                if (dpt.DeptID.Equals(deptid))
                {
                    flag = true;
                    break;
                }
            }

            return flag;
        }

        public static void AddDept()
        {
            string deptid;
            string deptname;

            while (true)
            {
                Console.Write("Enter Department ID : ");
                deptid = Console.ReadLine();
                deptid = deptid.ToLower();
                if (deptid.Equals(""))
                {
                    Console.WriteLine("Department ID cannot be blank !!!");
                }
                else if (CheckDeptID(deptid) == true)
                {
                    Console.WriteLine("Department ID already exist !!!");
                }
                else
                {
                    break;
                }
            }

            while (true)
            {
                Console.Write("Enter Department Name : ");
                deptname = Console.ReadLine();
                if (deptname.Equals(""))
                {
                    Console.WriteLine("Department Name cannot be blank !!!");
                }
                else
                {
                    break;
                }
            }

            Department obj = new Department(deptid, deptname);
            deptlist.Add(obj);
            SaveDepartment();

            Console.WriteLine("Department Added Successfully !!!");
            Console.ReadKey();
        }

        public static bool CheckEmployeeID(string empid)
        {
            bool flag = false;
            foreach (Employee emp in employeelist)
            {
                if (emp.EmployeeID.Equals(empid))
                {
                    flag = true;
                    break;
                }
            }
            return flag;
        }

        public static bool CheckMobileNo(string mobno)
        {
            bool flag = false;
            foreach (Employee emp in employeelist)
            {
                if (emp.MobileNo.Equals(mobno))
                {
                    flag = true;
                    break;
                }
            }
            return flag;
        }

        public static bool CheckEmail(string email)
        {
            bool flag = false;
            foreach (Employee emp in employeelist)
            {
                if (emp.Email.Equals(email))
                {
                    flag = true;
                    break;
                }
            }
            return flag;
        }

        public static void AddEmployee()
        {
            string empid;
            string fname;
            string lname;
            string mobno;
            string email;
            string strtdt;
            Department dobj;

            while (true)
            {
                Console.Write("Enter Employee ID : ");
                empid = Console.ReadLine();
                empid = empid.ToLower();
                if (empid.Equals(""))
                {
                    Console.WriteLine("Employee ID cannot be blank !!!");
                }
                else if (CheckEmployeeID(empid) == true)
                {
                    Console.WriteLine("Employee ID already exists !!!");
                }
                else
                {
                    break;
                }
            }

            while (true)
            {
                Console.Write("Enter First Name : ");
                fname = Console.ReadLine();
                if (fname.Equals(""))
                {
                    Console.WriteLine("First Name cannot be blank !!!");
                }
                else
                {
                    break;
                }
            }

            while (true)
            {
                Console.Write("Enter Last Name : ");
                lname = Console.ReadLine();
                if (lname.Equals(""))
                {
                    Console.WriteLine("Last Name cannot be blank !!!");
                }
                else
                {
                    break;
                }
            }

            while (true)
            {
                Console.Write("Enter Mobile No. : ");
                mobno = Console.ReadLine();

                if (mobno.Equals(""))
                {
                    Console.WriteLine("Mobile No. cannot be blank !!!");
                }
                else if (mobno.Length != 10)
                {
                    Console.WriteLine("Mobile No. should be 10 digits long !!!");
                }
                else if (!long.TryParse(mobno, out long m))
                {
                    Console.WriteLine("Mobile No. should be only digits !!!");
                }
                else if (CheckMobileNo(mobno) == true)
                {
                    Console.WriteLine("This Mobile No. is already exists in records !!!");
                }
                else
                {
                    break;
                }
            }

            while (true)
            {
                Console.Write("Enter Email Address : ");
                email = Console.ReadLine();
                if (email.Equals(""))
                {
                    Console.WriteLine("Email Address cannot be blank !!!");
                }
                else if (CheckEmail(email) == true)
                {
                    Console.WriteLine("This email address already exists in records !!!");
                }
                else if (!email.Contains("@"))
                {
                    Console.WriteLine("Email Address format is incorrect !!!");
                }
                else
                {
                    break;
                }
            }

            while (true)
            {
                Console.Write("Enter Joining Date : ");
                strtdt = Console.ReadLine();

                if (strtdt.Equals(""))
                {
                    Console.WriteLine("Start Date cannot be blank !!!");
                }
                else if (!DateTime.TryParse(strtdt, out DateTime dt))
                {
                    Console.WriteLine("Start Date format is not correct !!!");
                }
                else
                {
                    break;
                }
            }

            while (true)
            {
                foreach (Department dpt in deptlist)
                {
                    Console.WriteLine(dpt.ToString());
                }
                Console.WriteLine();
                Console.Write("Enter Dept ID : ");
                string dptid = Console.ReadLine();
                int index = -1;
                bool flag = false;
                foreach (Department dpt in deptlist)
                {
                    if (dpt.DeptID.Equals(dptid))
                    {
                        index = deptlist.IndexOf(dpt);
                        flag = true;
                        break;
                    }
                }

                if (flag == false)
                {
                    Console.WriteLine("Dept ID does not exist !!!");
                }
                else
                {
                    dobj = deptlist[index];
                    break;
                }
            }

            Employee obj = new Employee(empid, fname, lname, mobno, email, strtdt, dobj);
            employeelist.Add(obj);
            SaveEmployee();

            Console.WriteLine("Employee Record Added Successfully !!!");
            Console.ReadKey();
        }

        public static void RemoveEmpByID()
        {
            string empid;
            int index = -1;
            string q = "";
            bool flag = false;
            while (true)
            {
                Console.Write("Enter Employee ID : ");
                empid = Console.ReadLine();
                empid = empid.ToLower();
                if (empid.Equals(""))
                {
                    Console.WriteLine("Employee ID cannot be blank !!!");
                }
                else if (CheckEmployeeID(empid) == true)
                {
                    flag = true;
                    break;
                }
                else
                {
                    flag = false;
                    Console.WriteLine("Employee ID does not exists !!!");
                    break;
                }
            }

            if (flag == true)
            {
                foreach (Employee emp in employeelist)
                {
                    if (emp.EmployeeID.Equals(empid))
                    {
                        index = employeelist.IndexOf(emp);
                        Console.WriteLine(emp.ToString());
                        break;
                    }
                }

                while (true)
                {
                    Console.Write("Remove this record Y/N : ");
                    q = Console.ReadLine();
                    q = q.ToLower();

                    if (q.Equals("y"))
                    {
                        employeelist.RemoveAt(index);
                        SaveEmployee();
                        Console.WriteLine("Employee Record Removed Successfully !!!");

                        break;
                    }
                    else if (q.Equals("n"))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Enter Y or N only !!!");
                    }
                }

            }

            Console.ReadKey();
        }

        public static void RemoveEmpByPhone()
        {
            string mobno;
            int index = -1;
            string q = "";
            bool flag = false;
            while (true)
            {
                Console.Write("Enter Mobile No. : ");
                mobno = Console.ReadLine();

                if (mobno.Equals(""))
                {
                    Console.WriteLine("Mobile No. cannot be blank !!!");
                }
                else if (mobno.Length != 10)
                {
                    Console.WriteLine("Mobile No. should be 10 digits long !!!");
                }
                else if (!long.TryParse(mobno, out long m))
                {
                    Console.WriteLine("Mobile No. should be only digits !!!");
                }
                else if (CheckMobileNo(mobno) == true)
                {
                    flag = true;
                    break;
                }
                else
                {
                    Console.WriteLine("This Mobile No. is does not exists in records !!!");
                    break;
                }
            }

            if (flag == true)
            {
                foreach (Employee emp in employeelist)
                {
                    if (emp.MobileNo.Equals(mobno))
                    {
                        index = employeelist.IndexOf(emp);
                        Console.WriteLine(emp.ToString());
                        break;
                    }
                }

                while (true)
                {
                    Console.Write("Remove this record Y/N : ");
                    q = Console.ReadLine();
                    q = q.ToLower();

                    if (q.Equals("y"))
                    {
                        employeelist.RemoveAt(index);
                        SaveEmployee();
                        Console.WriteLine("Employee Record Removed Successfully !!!");
                        break;
                    }
                    else if (q.Equals("n"))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Enter Y or N only !!!");
                    }
                }
            }
            Console.ReadKey();
        }

        public static void UpdateEmployee()
        {
            string empid;
            string fname;
            string lname;
            string mobno;
            string email;
            string strtdt;
            Department dobj;
            int index = -1;

            while (true)
            {
                Console.Write("Enter Employee ID : ");
                empid = Console.ReadLine();
                empid = empid.ToLower();
                if (empid.Equals(""))
                {
                    Console.WriteLine("Employee ID cannot be blank !!!");
                }
                else if (CheckEmployeeID(empid) == true)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Employee ID does not exists !!!");
                    break;
                }
            }

            foreach (Employee emp in employeelist)
            {
                if (emp.EmployeeID.Equals(empid))
                {
                    index = employeelist.IndexOf(emp);
                    Console.WriteLine(emp.ToString());
                    break;
                }
            }

            while (true)
            {
                Console.Write("Enter First Name : ");
                fname = Console.ReadLine();
                if (fname.Equals(""))
                {
                    Console.WriteLine("First Name cannot be blank !!!");
                }
                else
                {
                    break;
                }
            }

            while (true)
            {
                Console.Write("Enter Last Name : ");
                lname = Console.ReadLine();
                if (lname.Equals(""))
                {
                    Console.WriteLine("Last Name cannot be blank !!!");
                }
                else
                {
                    break;
                }
            }

            while (true)
            {
                Console.Write("Enter Mobile No. : ");
                mobno = Console.ReadLine();

                if (mobno.Equals(""))
                {
                    Console.WriteLine("Mobile No. cannot be blank !!!");
                }
                else if (mobno.Length != 10)
                {
                    Console.WriteLine("Mobile No. should be 10 digits long !!!");
                }
                else if (!long.TryParse(mobno, out long m))
                {
                    Console.WriteLine("Mobile No. should be only digits !!!");
                }
                else
                {
                    break;
                }
            }

            while (true)
            {
                Console.Write("Enter Email Address : ");
                email = Console.ReadLine();
                if (email.Equals(""))
                {
                    Console.WriteLine("Email Address cannot be blank !!!");
                }
                else if (!email.Contains("@"))
                {
                    Console.WriteLine("Email Address format is incorrect !!!");
                }
                else
                {
                    break;
                }
            }

            while (true)
            {
                Console.Write("Enter Joining Date : ");
                strtdt = Console.ReadLine();

                if (strtdt.Equals(""))
                {
                    Console.WriteLine("Start Date cannot be blank !!!");
                }
                else if (!DateTime.TryParse(strtdt, out DateTime dt))
                {
                    Console.WriteLine("Joining Date format is not correct !!!");
                }
                else
                {
                    break;
                }
            }

            while (true)
            {
                foreach (Department dpt in deptlist)
                {
                    Console.WriteLine(dpt.ToString());
                }
                Console.WriteLine();
                Console.Write("Enter Dept ID : ");
                string dptid = Console.ReadLine();
                int index1 = -1;
                bool flag = false;
                foreach (Department dpt in deptlist)
                {
                    if (dpt.DeptID.Equals(dptid))
                    {
                        index1 = deptlist.IndexOf(dpt);
                        flag = true;
                        break;
                    }
                }

                if (flag == false)
                {
                    Console.WriteLine("Dept ID does not exist !!!");
                }
                else
                {
                    dobj = deptlist[index1];
                    break;
                }
            }

            Employee obj = new Employee(empid, fname, lname, mobno, email, strtdt, dobj);
            employeelist[index] = obj;
            SaveEmployee();
            Console.WriteLine("Employee Record Updated Successfully !!!");
            Console.ReadKey();
        }

        public static void SearchEmpByPhone()
        {
            string mobno;
            int index = -1;
            bool flag = false;
            while (true)
            {
                Console.Write("Enter Mobile No. : ");
                mobno = Console.ReadLine();

                if (mobno.Equals(""))
                {
                    Console.WriteLine("Mobile No. cannot be blank !!!");
                }
                else if (mobno.Length != 10)
                {
                    Console.WriteLine("Mobile No. should be 10 digits long !!!");
                }
                else if (!long.TryParse(mobno, out long m))
                {
                    Console.WriteLine("Mobile No. should be only digits !!!");
                }
                else if (CheckMobileNo(mobno) == true)
                {
                    flag = true;
                    break;
                }
                else
                {
                    Console.WriteLine("This Mobile No. is does not exists in records !!!");
                    break;
                }
            }

            if (flag == true)
            {
                foreach (Employee emp in employeelist)
                {
                    if (emp.MobileNo.Equals(mobno))
                    {
                        index = employeelist.IndexOf(emp);
                        Console.WriteLine(emp.ToString());
                        break;
                    }
                }
            }

            Console.ReadKey();
        }

        public static void SearchEmpByID()
        {
            string empid;
            bool flag = false;
            while (true)
            {
                Console.Write("Enter Employee ID : ");
                empid = Console.ReadLine();
                empid = empid.ToLower();
                if (empid.Equals(""))
                {
                    Console.WriteLine("Employee ID cannot be blank !!!");
                }
                else if (CheckEmployeeID(empid) == true)
                {
                    flag = true;
                    break;
                }
                else
                {
                    flag = false;
                    Console.WriteLine("Employee ID does not exists !!!");
                    break;
                }
            }

            if (flag == true)
            {
                foreach (Employee emp in employeelist)
                {
                    if (emp.EmployeeID.Equals(empid))
                    {
                        Console.WriteLine(emp.ToString());
                        break;
                    }
                }
            }

            Console.ReadKey();
        }

        public static void SearchEmpByDept()
        {
            string deptnam;
            bool flag = false;
            while (true)
            {
                Console.Write("Enter Department Name : ");
                deptnam = Console.ReadLine();

                if (deptnam.Equals(""))
                {
                    Console.WriteLine("Department Name cannot be blank !!!");
                }
                else
                {
                    break;
                }
            }

            foreach (Employee emp in employeelist)
            {
                if (emp.Dept.DeptName.Equals(deptnam))
                {
                    Console.WriteLine(emp.ToString());
                    flag = true;
                }
            }

            if (flag == false)
            {
                Console.WriteLine("No Employee in this Department !!!");
            }

            Console.ReadKey();
        }


        static void Main(string[] args)
        {
            LoadDepartment();
            LoadEmployee();
            int choice;

            do
            {
                Console.Clear();
                Console.WriteLine("COMPANY EMPLOYEE DEPARTMENT INFO SYSTEM - MAIN MENU");
                Console.WriteLine("===================================================");
                Console.WriteLine();
                Console.WriteLine("1. ADD DEPARTMENT");
                Console.WriteLine("2. ADD NEW EMPLOYEE");
                Console.WriteLine("3. REMOVE EMPLOYEE BY ID");
                Console.WriteLine("4. REMOVE EMPLOYEE BY PHONE NO.");
                Console.WriteLine("5. UPDATE EMPLOYEE DETAILS");
                Console.WriteLine("6. SEARCH EMPLOYEE BY PHONE NO.");
                Console.WriteLine("7. SEARCH EMPLOYEE BY ID");
                Console.WriteLine("8. SEARCH EMPLOYEE BY DEPARTMENT NAME");
                Console.WriteLine("0. EXIT");
                Console.WriteLine();
                Console.Write("Enter Your Choice (1-8 and 0 to exit) : ");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        {
                            AddDept();
                            break;
                        }

                    case 2:
                        {
                            AddEmployee();
                            break;
                        }

                    case 3:
                        {
                            RemoveEmpByID();
                            break;
                        }

                    case 4:
                        {
                            RemoveEmpByPhone();
                            break;
                        }

                    case 5:
                        {
                            UpdateEmployee();
                            break;
                        }

                    case 6:
                        {
                            SearchEmpByPhone();
                            break;
                        }

                    case 7:
                        {
                            SearchEmpByID();
                            break;
                        }

                    case 8:
                        {
                            SearchEmpByDept();
                            break;
                        }

                    case 0:
                        {

                            break;
                        }

                    default:
                        {
                            Console.WriteLine("Wrong Choice !!! Enter again...");
                            Console.ReadKey();
                            continue;
                        }

                }
            } while (choice != 0);
        }
    }
}
