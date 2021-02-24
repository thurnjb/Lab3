using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/*Jay Thurn, Ryan Booth, John Lee
Our submission of this assignment indicates that we have neither received nor given unauthorized assistance in writing this program. All design and coding is our own work.*/

namespace Lab2
{
    public class Employee
    {
        //Data Fields
        private String userName;
        private String passWord;
        public int userID { get; set; }
        private static int nextID = 100;

        //Constructors
        public Employee(String userName, String passWord)
        {
            this.userName = userName;
            this.passWord = passWord;
            this.userID = nextID++;
        }


        //Methods
        //Properties
        public String UserName
        {
            get
            {
                return this.userName;
            }
            set
            {
                this.userName = value;
            }
        }

        public String PassWord
        {
            get
            {
                return this.passWord;
            }
            set
            {
                this.passWord = value;
            }
        }
    }
}