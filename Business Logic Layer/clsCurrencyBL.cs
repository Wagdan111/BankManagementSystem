using DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class clsCurrencyBL
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public string Code { get; set; }
        public double Rote { get; set; }
        enum enMode{Add=0, Update=1 }
        enMode Monde;
        public clsCurrencyBL(string Code, double Rate)
        {
            this.Rote = Rate;
            this.Code = Code;
            
        }
        public bool UpdateRate()
        {
            return DataAccess.clsCurrency.UpdateRate(this.Rote, this.Code );
        }
        public static DataTable ShowCurrency()
        {
           return DataAccess.clsCurrency.ShowCurrency();
        }
        public static DataTable SearcehByCode(string Code)
        {
            return DataAccess.clsCurrency.SearcehByCode(Code);
        }
        public clsCurrencyBL(string Code,string Name,string country, double Rote)
        {
            this.Name = Name;
            this.Code = Code;
            this.Country = country;
            this.Rote = Rote;
            Monde = enMode.Update;
        }
        public static clsCurrencyBL FindbyCode(string Code)
        {
            string  Country = "", Name = "";
            double Rote = 0; 
     

            if (DataAccess.clsCurrency.FindByCode(Code,  ref Name, ref Rote, ref Country))
            {
                return new clsCurrencyBL(Code, Name, Country, Rote);
            }
            else
                return null;
        }
        public static int SumAccountBalance()
        {
            return DataAccess.clsCurrency.SumAllAccountBalance();
        }
        public bool Save()
        {
            switch(Monde)
            {
                case enMode.Update:
                    {
                        if(UpdateRate())
                        {
                            return true;
                        }
                        else
                            return false;
                    }
            }
            return false;
        }

    }
}
