using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
namespace BusinessLogic
{
    public class clsUsersBL
    {
        public int ID { get; set; }
        public int Parmeter { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }

        public  enum enMode { Add=0,Update=1 }
        enMode Monde;
        public    clsUsersBL(string Password ,string UserName,string FirstName,string LastName,string Phone,int ID,int Parmeter)
        {
            this.Password = Password;
            this.UserName = UserName;
            this.Parmeter = Parmeter;
            this.ID = ID;
            this.Phone = Phone;
            this.FirstName = FirstName;
            this.LastName = LastName;
            Monde = enMode.Update;
        }
        public   clsUsersBL()
        {
            this.Password = "";
            this.UserName = "";
            this.Parmeter= 0;
            this.ID = 0;
            this.Phone = "";
            this.FirstName = "";
            this.LastName = "";
            Monde = enMode.Add;
        }
        public bool AddNewUser()
        {
            ID = clsUsers.AddNewUser(this.UserName, this.FirstName, this.LastName, this.Password, this.Phone, this.Parmeter);
            return (ID != -1);
        }
        public static clsUsersBL FindbyPasswordandUserName(string Password,string UserName)
        {
            string FirstName="",LastNAme="",Phone="";
                int Parmeter = 0;
            int ID = 0;

            if (clsUsers.Find(Password, UserName, ref LastNAme, ref FirstName, ref Phone, ref ID,ref Parmeter))
            {
                return new clsUsersBL(Password, UserName, FirstName, LastNAme, Phone, ID, Parmeter);
            }
            else
                return null;
        }
        public static  string v = "";
        public static clsUsersBL FindByPassword(string Password)
        {
            v = Password;
            string FirstName = "", UserName="", LastNAme = "", Phone = "";
            int Parmeter = 0;
            int ID = 0;

            if (clsUsers.FindByPassword(Password,ref UserName, ref LastNAme, ref FirstName, ref Phone, ref ID, ref Parmeter))
            {
                return new clsUsersBL(Password, UserName, FirstName, LastNAme, Phone, ID, Parmeter);
            }
            else
                return null;
        }
        public static DataTable ShowLastUsers()
        {
          return clsUsers.ShowLastUsers();
        }
        public static DataTable Sheresh(string UserName)
        {
            return clsUsers.Sheresh(UserName);
        }
        public bool UpdateUser()
        {
            return clsUsers.UpdateUser( this.Password, this.FirstName, this.LastName,this.UserName ,this.Phone, this.Parmeter);
        }
        public  bool  DelteUser(string ID)
        {
            return clsUsers.DeleteUser(ID);
        }
        public bool Save()
        {
            switch(Monde)
            {
                case enMode.Add:
                    {
                        if(AddNewUser())
                        {
                            return true;
                        }
                        else
                            return false;
                    }
                case enMode.Update:
                    
                        return UpdateUser();
                    
            }
            return false;
        }
    }
}
