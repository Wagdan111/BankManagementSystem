using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
namespace BusinessLogic
{
    public class Client_CodingMain
    {

        enum enMode { Add=0,Update=1 }
        public  string FirstName { get; set; }
        public string Pincode { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string AccountNumber { get; set; }
        public  int AccountBalance { get; set; }
        public int ID { get; set; }
        enMode Mode;
        public Client_CodingMain()
        {
            ID =-1;
            FirstName = "";
            Pincode = "";
             LastName = "";
            Phone = "";
            Email = "";
            AccountNumber = "";
            AccountBalance = 0;
            Mode = enMode.Add;
        }
        public Client_CodingMain(string Account,string FirstName, string Pincode, string LastName, string Phone, string Email,int AccountBalance)
        {
            ID = -1;
            this.FirstName = FirstName;
            this.Pincode = Pincode;
            this.LastName = LastName;
            this.Phone = Phone;
            this.Email = Email;
            this.AccountNumber = Account;
            this.AccountBalance = AccountBalance;
            Mode = enMode.Update;
        }
        public bool AddNewClient()
        {

            this.ID = clsClient.AddNwClint(this.FirstName, this.LastName, this.Phone, this.Email, this.AccountNumber,this.Pincode, this.AccountBalance);
            return (ID != -1);
        }
        public static DataTable ShowListClient()
        {
            
            return clsClient.ShowListClient();
        }
        public static DataTable ShowListClientbyOrderbyAsc()
        {
           
            return clsClient.ShowListClientbyOrderbyAsc();
        }
        public static DataTable ShowClientbyOrderAccoutDesc()
        {

            return clsClient.ShowClientbyOrderAccoutDesc();
        }
        public static DataTable ShowAccoutNumber()
        {

            return clsClient.ShowAccoutNumber();
        }
        public static int CountsClients()
        {

            return clsClient.CountsClients();
        }
        public static DataTable SearcehByName(string Name)
        {

            return clsClient.SearcehByName(Name);
        }
        public static DataTable SearcehAccountNumberByName(string Name)
        {

            return clsClient.SearcehAccountNumberByName(Name);
        }
        public static Client_CodingMain FindbyAccountNumber(string Account)
        {
            string FirstName = "", Lastname = "", Phone = "", Email = "", AccountNumber = "", pinCode = "";
            int AccountBalance = 0;

            if (clsClient.FindbyAccountNumber(Account, ref Lastname, ref FirstName, ref Phone, ref Email, ref pinCode, ref AccountBalance))
            {
                return new Client_CodingMain(Account, FirstName, pinCode, Lastname, Phone, Email, AccountBalance);
            }
            else
                return null;

        }
        public bool UpdateClient()
        {
            return clsClient.UpdateContcst(this.AccountNumber,  this.LastName,  this.FirstName, this.Email,this.Phone,  this.Pincode, this.AccountBalance);
        }
        public bool Save()
        {
            switch(Mode)
            {
                case enMode.Add:
                    {
                        if (AddNewClient())
                        {
                            Mode = enMode.Update;
                            return true;
                            
                        }
                        else
                            return false;
                    }
                case enMode.Update:
                    return UpdateClient();

            }
            return false;
        }
    }
}
