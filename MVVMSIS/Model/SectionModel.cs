using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMSIS.Model
{
    class SectionModel
    {
        #region fields
        private string _sectionName;        
        private AdviserModel _adviser = new AdviserModel();
        private List<StudentModel> _studentsEnrolled = new List<StudentModel>();
        private int _numberOfStudents;
        private string _department;
        #endregion

        #region properties
        public string SectionName
        {
            get { return _sectionName; }
            set { _sectionName = value; }
        }

        public string Department
        {
            get { return _department; }
            set { _department = value; }
        }

        public int NumberOfStudents
        {
            get { return _numberOfStudents; }
            set { _numberOfStudents = value ; }
        }
        public List<StudentModel> StudentsEnrolled
        {
            get { return _studentsEnrolled; }
            set { _studentsEnrolled = value; }
        }

        public AdviserModel Adviser
        {
            get { return _adviser; }
            set { _adviser = value; }
        }
        #endregion
    }
}
