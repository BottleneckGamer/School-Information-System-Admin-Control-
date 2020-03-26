using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMSIS.Model
{    
    class SubjectModel :ObservableObject 
    {
        #region fields
        private string _subjectCode;
        private string _name;
        private int _units;
        private int _prelim;
        private int _midterm;
        private int _prefi;
        private int _final;
        #endregion
        #region properties
        public int Prelim
        {
            get { return _prelim; }
            set
            {
                if (value != _prelim)
                {
                    _prelim = value;
                    OnPropertyChanged("PrelimGrade");
                }
            }
        }

        public int Midterm
        {
            get { return _midterm; }
            set
            {
                if (value != _midterm)
                {
                    _midterm = value;
                    OnPropertyChanged("MidtermGrade");
                }
            }
        }

        public int Prefinal
        {
            get { return _prefi; }
            set
            {
                if (value != _prefi)
                {
                    _prefi = value;
                    OnPropertyChanged("PrefinalGrade");
                }
            }
        }

        public int Final
        {
            get
            {
                _final = (Prelim + Midterm + Prefinal) / 3;
                return _final;
            }
            
        }

        public string SubjectCode
        {
            get { return _subjectCode; }
            set
            {
                if (value != _subjectCode)
                {
                    _subjectCode = value;
                    OnPropertyChanged("SubjectCode");
                }
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                if (value != _name)
                {
                    _name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        public int Units
        {
            get { return _units; }
            set
            {
                if (value != _units)
                {
                    _units = value;
                    OnPropertyChanged("Units");
                }
            }
        }
        #endregion
    }
}
