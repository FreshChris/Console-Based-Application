using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompEmpDeptSys
{
    class Employee
    {
        private string employeeid;
        private string firstname;
        private string lastname;
        private string mobileno;
        private string email;
        private string joiningdate;
        private Department dept;

        public Employee(string employeeid, string firstname, string lastname, string mobileno, string email, string joiningdate, Department dept)
        {
            this.employeeid = employeeid;
            this.firstname = firstname;
            this.lastname = lastname;
            this.mobileno = mobileno;
            this.email = email;
            this.joiningdate = joiningdate;
            this.dept = dept;
        }

        public string EmployeeID
        {
            get
            {
                return this.employeeid;
            }
            set
            {
                this.employeeid = value;
            }
        }

        public string FirstName
        {
            get
            {
                return this.firstname;
            }
            set
            {
                this.firstname = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastname;
            }
            set
            {
                this.lastname = value;
            }
        }

        public string MobileNo
        {
            get
            {
                return this.mobileno;
            }
            set
            {
                this.mobileno = value;
            }
        }

        public string Email
        {
            get
            {
                return this.email;
            }
            set
            {
                this.email = value;
            }
        }

        public string JoiningDate
        {
            get
            {
                return this.joiningdate;
            }
            set
            {
                this.joiningdate = value;
            }
        }

        public Department Dept
        {
            get
            {
                return this.dept;
            }
            set
            {
                this.dept = value;
            }
        }

        public string ToCSV()
        {
            string msg;

            msg = this.employeeid + "," + this.firstname + "," + this.lastname + "," + this.mobileno + "," + this.email + "," + this.joiningdate + "," + this.dept.DeptID + "," + this.dept.DeptName;
            return msg;
        }

        public override string ToString()
        {
            string msg;

            msg = "Employee ID   : " + this.employeeid + "\t\t" + "Employee Name      :  " + this.firstname + " " + this.lastname + "\n";
            msg += "Mobile No.    : " + this.mobileno + "\t\t" + "Email             :  " + this.email + "\n";
            msg += "Joining Date  : " + this.joiningdate + "\n";
            msg += "Department ID : " + this.dept.DeptID + "\t\t" + "Department Name  :  " + this.dept.DeptName + "\n";
            return msg;
        }

    }
}
