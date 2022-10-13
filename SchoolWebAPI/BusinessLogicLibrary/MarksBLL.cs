using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLibrary
{
    public class MarksBLL
    {
        private int _RegisterNumber;
        public int  RegisterNumber
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
        public int Marks
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
