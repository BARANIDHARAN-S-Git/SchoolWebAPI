using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusinessLogicLibrary;
using HelperLibrary;
using SchoolWebAPI.Models;

namespace SchoolWebAPI.Controllers
{
    public class MarksController : ApiController
    {


      
        MarksHL obj = null;
        public MarksController()
        {
            obj = new MarksHL();
        }

      
        public List<Marks> GetList()
        {

            List<MarksBLL> markbal = new List<MarksBLL>(); 
            markbal = obj.List();
            List<Marks> Marks = new List<Marks>();
            foreach (var item in markbal)
            {
                
                Marks.Add(new Marks { RegisterNumber = item.RegisterNumber, SubjectId= item.SubjectId, marks = item.Marks });
            }
            return Marks;

        }

       
        public HttpResponseMessage PostMarks([FromBody] Marks Marksdata)
        {
            MarksBLL marksbal = new MarksBLL();
            marksbal.RegisterNumber = Marksdata.RegisterNumber;
            marksbal.SubjectId = Marksdata.SubjectId;
            marksbal.Marks= Marksdata.marks;
           

            bool ans = obj.AddNew(marksbal);
            if (ans)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotAcceptable);
            }

        }

        public HttpResponseMessage PutMarks(int id, [FromBody] Marks Marksdata)
        {

            MarksBLL marksbal = new MarksBLL();
            marksbal.RegisterNumber = Marksdata.RegisterNumber;
            marksbal.SubjectId = Marksdata.SubjectId;
            marksbal.Marks = Marksdata.marks;
            
            bool ans = obj.EditData(id, marksbal);
            if (ans)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotAcceptable);
            }
        }

        public HttpResponseMessage DeleteMarks(int id)
        {
            bool ans = obj.RemoveData(id);
            if (ans)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotAcceptable);
            }


        }
    }
}