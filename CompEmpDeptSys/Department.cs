using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompEmpDeptSys
{
    class Department
    {
        private string deptid;
        private string deptname;

        public Department(string deptid, string deptname)
        {
            this.deptid = deptid;
            this.deptname = deptname;
        }

        public string DeptID
        {
            get
            {
                return this.deptid;
            }
            set
            {
                this.deptid = value;
            }
        }

        public string DeptName
        {
            get
            {
                return this.deptname;
            }
            set
            {
                this.deptname = value;
            }
        }

        public string ToCSV()
        {
            string msg;
            msg = this.deptid + "," + this.deptname;
            return msg;
        }

        public override string ToString()
        {
            string msg;
            msg = "Department ID : " + this.deptid + "\t\t" + "Department Name : " + this.deptname + "\n";
            return msg;
        }
    }
}
