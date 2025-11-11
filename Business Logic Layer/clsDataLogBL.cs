using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;


namespace BusinessLogic
{
    public class clsDataLogBL
    {
        public DateTime DataLog { get; set; }
        public int UserID { get; set; }
        public int ID { get; set; }
        public enum enMode { Add = 0, Update = 1 }
        enMode Monde;
        public static DataTable ShowDataLog() 
        {
            DataAccess.clsDataLog h = new DataAccess.clsDataLog();
           
            return h.ShowDataLog();
        }
        public static DataTable SearcehByName(string Name)
        {
            DataAccess.clsDataLog h = new DataAccess.clsDataLog();

            return h.SearcehByName(Name);
        }
        public clsDataLogBL()
        {
            this.DataLog = DateTime.Now;
            this.UserID = 0;
            
            Monde = enMode.Add;
        }
        public bool AddDataLog()
        {
            DataAccess.clsDataLog h = new DataAccess.clsDataLog();
            ID = h.AddDataLog(this.DataLog, this.UserID);
            return (ID != -1);
        }
        public bool Save()
        {
            switch (Monde)
            {
                case enMode.Add:
                    {
                        if (AddDataLog())
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
