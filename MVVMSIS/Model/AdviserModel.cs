using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMSIS.Model
{
    class AdviserModel:PersonModel
    {
        #region Enum
        public enum rankEnum
        {
            Instructor,
            Associate,
            Proffesor
        }
        #endregion
        #region fields
        private List<rankEnum> _rank;
        private List<SubjectModel> _subjectSpecialty = new List<SubjectModel>();
        private string _department;
        private List<SectionModel> _sectionHandledList = new List<SectionModel>();
        

        #endregion
        #region properties
        public List<rankEnum> Rank
        {
            get { return _rank  ?? Enum.GetValues(typeof(rankEnum)).Cast<rankEnum>().ToList();}
            set { _rank = value; }
        }
        public List<SubjectModel> SubjectSpecialty
        {
            get { return _subjectSpecialty; }
            set { _subjectSpecialty = value; }
        }

        public string Department
        {
            get { return _department; }
            set
            {
                if (value != _department)
                {
                    _department  = value;
                    OnPropertyChanged("Department");
                }
            }
        }

        public List<SectionModel> SectionHandledList
        {
            get { return _sectionHandledList; }
            set
            {
                if (value != _sectionHandledList)
                {
                    _sectionHandledList = value;
                    OnPropertyChanged("SectionHandledList");
                }
            }
        }

        #endregion
    }
}
