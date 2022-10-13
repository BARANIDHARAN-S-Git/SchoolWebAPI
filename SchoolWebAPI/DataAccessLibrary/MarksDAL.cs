using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLibrary;
using System.Configuration;
using System.Xml.Linq;


namespace DataAccessLibrary
{
    public class MarksDAL
    {
        DataSet ds = null;
        SqlDataAdapter da = null;
        SqlConnection cn = null;

      

        public MarksDAL()
        {
            ds = new DataSet();
            cn = new SqlConnection(ConfigurationManager.ConnectionStrings["SchoolCnStr"].ConnectionString);
        }

        private DataTable Connect()
        {
            da = new SqlDataAdapter("select * from Marks", cn);


            da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            da.Fill(ds, "Marks");
            DataTable dt_data = ds.Tables["Marks"];
            return dt_data;
        }

        public int RowCount()
        {
            DataTable dt_data = Connect();
            int cnt = dt_data.Rows.Count;
            return cnt;



        }


        public bool Update(int RegisterNumber, MarksBLL Subject)
        {
            DataTable dt_empdata = Connect();
            DataRow drow = ds.Tables["Marks"].Rows.Find(RegisterNumber);


            drow["RegisterNumber"] = Subject.RegisterNumber;
            drow["SubjectId"] = Subject.SubjectId;
            drow["Marks"] = Subject.Marks;
            

            SqlCommandBuilder bldr = new SqlCommandBuilder(da);
            int i = da.Update(ds.Tables["Marks"]);
            bool status = false;
            if (i == 1)
            {
                status = true;
            }
            return status;



        }
        public MarksBLL Find(int RegisterNumber)
        {
            DataTable dt_empdata = Connect();
            DataRow drow = ds.Tables["Marks"].Rows.Find(RegisterNumber);
            MarksBLL Marks = new MarksBLL();
            Marks.RegisterNumber = Convert.ToInt32(drow["RegisterNumber"]);
            Marks.SubjectId = Convert.ToInt32(drow["SubjectId"]);
            Marks.Marks = Convert.ToInt32(drow["Marks"]);
            
            return Marks;



        }


        public List<MarksBLL> ShowAll()
        {
            DataTable dt_data = Connect();
            List<MarksBLL> list = new List<MarksBLL>();
            for (int i = 0; i < dt_data.Rows.Count; i++)
            {
                DataRow drow = dt_data.Rows[i];
                MarksBLL Marks = new MarksBLL();
                Marks.RegisterNumber = Convert.ToInt32(drow["RegisterNumber"]);
                Marks.SubjectId = Convert.ToInt32(drow["SubjectId"]);
                Marks.Marks = Convert.ToInt32(drow["Marks"]);


                list.Add(Marks);

            }
            return list;


        }


        public bool Delete(int RegNumber)
        {


            DataTable dt_empdata = Connect();
            DataRow drow = ds.Tables["Marks"].Rows.Find(RegNumber);
            drow.Delete();

            SqlCommandBuilder bldr = new SqlCommandBuilder(da);
            int i = da.Update(ds.Tables["Marks"]);
            bool status = false;
            if (i == 1)
            {
                status = true;
            }
            return status;



        }


        public bool Insert(MarksBLL Marks)
        {
            DataTable dt_empdata = Connect();

            DataRow drow = ds.Tables["Marks"].NewRow();
            drow["RegisterNumber"] = Marks.RegisterNumber;
            drow["SubjectId"] = Marks.SubjectId;
            drow["Marks"] = Marks.Marks;

            ds.Tables["Marks"].Rows.Add(drow);

            SqlCommandBuilder bldr = new SqlCommandBuilder(da);
            int i = da.Update(ds.Tables["Marks"]);
            bool status = false;
            if (i == 1)
            {
                status = true;
            }
            return status;




        }

    }
}
