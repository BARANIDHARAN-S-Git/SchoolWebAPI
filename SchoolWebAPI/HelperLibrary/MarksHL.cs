using BusinessLogicLibrary;
using DataAccessLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperLibrary
{
    public class MarksHL
    {
        MarksDAL dal = null;
        public MarksHL()
        {
            dal = new MarksDAL();
        }


        public int RowCount()
        {
            return dal.RowCount();

        }
        public bool AddNew(MarksBLL Marks)
        {
            return dal.Insert(Marks);
        }
        public MarksBLL Locate(int RegisterNumber)
        {
            return dal.Find(RegisterNumber);
        }

        public List<MarksBLL> List()
        {
            return dal.ShowAll();
        }

        public bool RemoveData(int RegisterNumber)
        {
            return dal.Delete(RegisterNumber);
        }



        public bool EditData(int RegisterNumber, MarksBLL Marks)
        {
            return dal.Update(RegisterNumber, Marks);
        }

    }
}
