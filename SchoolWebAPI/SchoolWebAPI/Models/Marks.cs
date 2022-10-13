using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolWebAPI.Models
{
    public class Marks
    {
        private int _RegisterNumber;
        public int RegisterNumber
        {
            get
            {
                return _RegisterNumber;

            }
            set
            {
                _RegisterNumber = value;
            }
        }

        private int _SubjectId;

        public int SubjectId
        {
            get
            {
                return _SubjectId;
            }
            set
            {
                _SubjectId = value;
            }
        }

        private int _Marks;
        public int marks
        {
            get
            {
                return _Marks;
            }
            set
            {
                _Marks = value;
            }
        }
    }
}