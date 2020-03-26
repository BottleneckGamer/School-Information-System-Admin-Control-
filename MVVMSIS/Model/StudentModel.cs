using System;
using System.Collections.Generic;
using System.Windows;

namespace MVVMSIS.Model
{
    class StudentModel : PersonModel 
    {
        #region fields
        private string _course;
        private int _requiredUnits;
        private List<SubjectModel> _takenSubjects= new List<SubjectModel>();
        private string _department;
        private string _section;
        #endregion

        #region properties
        public string Section
        {
            get { return _section; }
            set
            {
                if (value != _section)
                {
                    _section = value;
                    OnPropertyChanged("Section");
                }
            }
        }
        public List<SubjectModel> TakenSubjects
        {
            get { return _takenSubjects; }
            set { _takenSubjects = value; }
        }
        public string Course
        {
            get { return _course; }
            set
            {
                if (value != _course)
                {
                    _course = value;
                    OnPropertyChanged("Course");
                }
            }
        }
        public string Department
        {
            get { return _department; }
            set
            {
                if (value != _department)
                {
                    _department = value;
                    OnPropertyChanged("Department");
                }
            }
        }
        public int RequiredUnits
        {
            get { return _requiredUnits; }
            set
            {
                if (value != _requiredUnits)
                {
                    _requiredUnits = value;
                    OnPropertyChanged("RequiredUnits");
                }
            }
        }


        #endregion
    }
}
