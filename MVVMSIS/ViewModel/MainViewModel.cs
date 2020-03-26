using MVVMSIS.Model;
using MVVMSIS.View;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System;
using System.Security.Cryptography.X509Certificates;

namespace MVVMSIS.ViewModel
{
    class MainViewModel : ObservableObject
    {
        public MainViewModel()
        {
            SubjectModel A1 = new SubjectModel() { Name = "Chemistry", SubjectCode = "111", Units = 3 };
            SubjectModel A2= new SubjectModel() { Name = "Algebra", SubjectCode = "222", Units = 3 };
            SubjectModel A3= new SubjectModel() { Name = "Calculus", SubjectCode = "333", Units = 3 };
            SubjectModel A4 = new SubjectModel() { Name = "Differential Eq.", SubjectCode = "444", Units = 3 };
            SubjectModel A5 = new SubjectModel() { Name = "Statics", SubjectCode = "555", Units = 3 };
            SubjectModel A6 = new SubjectModel() { Name = "Dynamics", SubjectCode = "666", Units = 3 };
            SubjectModel A7 = new SubjectModel() { Name = "Ciruits", SubjectCode = "777", Units = 3 };
            SubjectModel A8 = new SubjectModel() { Name = "Sociology", SubjectCode = "888", Units = 3 };
            SubjectModel A9 = new SubjectModel() { Name = "Physics", SubjectCode = "999", Units = 3 };
            SubjectModel A10 = new SubjectModel() { Name = "Theology", SubjectCode = "101", Units = 3 };
            SubjectList.Add(A1);
            SubjectList.Add(A2);
            SubjectList.Add(A3);
            SubjectList.Add(A4);
            SubjectList.Add(A5);
            SubjectList.Add(A6);
            SubjectList.Add(A7);
            SubjectList.Add(A8);
            SubjectList.Add(A9);
            SubjectList.Add(A10);

            StudentModel q = new StudentModel() { FirstName = "Gil", LastName = "Bancud", RequiredUnits = 6 };
            StudentList.Add(q);

            SectionModel p = new SectionModel() { SectionName = "SEC1" };
            SectionList.Add(p);

            AdviserModel r = new AdviserModel() {LastName = "Adviser1"};
            AdviserList.Add(r);
        }

        #region fields for student
        //For Student
        private ObservableCollection<StudentModel> _studentList = new ObservableCollection<StudentModel>();
        private StudentModel _currentStudent;
        private StudentModel _selectedStudent;
        private ICommand _openStudentViewCommand;
        private ICommand _saveStudentCommand;
        private ICommand _deleteStudentCommand;
        private ICommand _editStudentCommand;
        private ICommand _takeSubject;
        private ICommand _dropSubject;
        private ICommand _closeStudentViewCommand;
        private StudentView SV;
        private ObservableCollection<SubjectModel> _takenSubjectCollection = new ObservableCollection<SubjectModel>();
        #endregion
        #region fields for subject
        //For Subject
        private ObservableCollection<SubjectModel> _subjectList = new ObservableCollection<SubjectModel>();
        private SubjectModel _currentSubject;
        private SubjectModel _selectedSubject;
        private ICommand _openSubjectViewCommand;
        private ICommand _closeSubjectViewCommand;
        private ICommand _saveSubjectCommand;
        private ICommand _deleteSubjectCommand;
        private ICommand _editSubjectCommand;
        private SubjectView SubjView;

        #endregion
        #region fields for sections
        //For Sections
        private ObservableCollection<SectionModel> _sectionList = new ObservableCollection<SectionModel>();
        private AdviserModel _takenadviser = new AdviserModel();
        private SectionModel _currentSection;
        private SectionModel _selectedSection;        
        private SectionView SecView;
        private ICommand _openSectionCommand;
        private ICommand _closeSectionCommand;
        private ICommand _saveSectionCommand;
        private ICommand _deleteSectionCommand;
        private ICommand _editSectionCommand;
        private ICommand _sectionAdviserCommand;
        #endregion
        #region fields for advisers
        private ObservableCollection<AdviserModel> _adviserList = new ObservableCollection<AdviserModel>();
        private AdviserModel _currentAdviser;
        private AdviserModel _selectedAdviser;
        private ICommand _openAdviserViewCommand;
        private ICommand _closeAdviserViewCommand;
        private ICommand _saveAdviserCommand;
        private ICommand _deleteAdviserCommand;
        private ICommand _advisertakeSubject;
        private ICommand _adviserdropSubject;
        private AdviserView AdView;
        private ObservableCollection<SubjectModel> _advisertakenSubjectCollection = new ObservableCollection<SubjectModel>();
        #endregion
        #region fields for grades
        private ICommand _openGiveGradeCommand;
        private ICommand _closeGiveGradeCommand;
        private ICommand _clearGradesCommand;
        private ICommand _givegradesCommand;
        private GiveGrade _gg;
        #endregion
        #region properties for grades
        public ICommand OpenGiveGradeCommand
        {
            get
            {
                if (_openGiveGradeCommand == null)
                {
                    _openGiveGradeCommand = new RelayCommand(
                        param => OpenGiveGrade(),
                        param => true
                    );
                }
                return _openGiveGradeCommand;
            }
        }

        public ICommand CloseGiveGradeCommand
        {
            get
            {
                if (_closeGiveGradeCommand == null)
                {
                    _closeGiveGradeCommand  = new RelayCommand(
                        param => CloseGiveGrade(),
                        param => true
                    );
                }
                return _closeGiveGradeCommand;
            }
        }

        public ICommand ClearGradesCommand
        {
            get
            {
                if (_clearGradesCommand  == null)
                {
                    _clearGradesCommand  = new RelayCommand(
                        param => ClearGrades(),
                        param => true
                    );
                }
                return _clearGradesCommand;
            }
        }

        public ICommand GiveGradesCommand
        {
            get
            {
                if (_givegradesCommand == null)
                {
                    _givegradesCommand = new RelayCommand(
                        param => GiveGrades(),
                        param => true
                    );
                }
                return _givegradesCommand;
            }
        }

       

        #endregion
        #region private helpers for Grades
        private void OpenGiveGrade()
        {
            var q = new SubjectModel();
            q = _selectedSubject;
            CurrentSubject = CurrentSubject ?? new SubjectModel();
            CurrentSubject.Name = q.Name;
            CurrentSubject.SubjectCode = q.SubjectCode;
            CurrentSubject.Units = q.Units;
            CurrentSubject.Prelim = q.Prelim;
            CurrentSubject.Midterm = q.Midterm;
            CurrentSubject.Prefinal = q.Prefinal;
            _gg = new GiveGrade();
            _gg.Show();
        }
        private void CloseGiveGrade()
        {
            _gg.Hide();
        }
        private void GiveGrades()
        {
            _selectedSubject.Prelim = _currentSubject.Prelim;
            _selectedSubject.Midterm = _currentSubject.Midterm;
            _selectedSubject.Prefinal = _currentSubject.Prefinal;
            SelectedSubject = null;
            _gg.Close();
        }
        private void ClearGrades()
        {
            SelectedSubject.Prelim = 0;
            SelectedSubject.Midterm = 0;
            SelectedSubject.Prefinal = 0;
            SelectedSubject = null;
        }
        #endregion 
        #region properties for advisers
        public ObservableCollection<SubjectModel> AdviserTakenSubjectCollection
        {
            get
            {
                return _advisertakenSubjectCollection;
            }
            set
            {
                _advisertakenSubjectCollection = value;
                OnPropertyChanged("AdviserTakenSubjectCollection");
            }
        }
        public ObservableCollection<AdviserModel> AdviserList
        {
            get
            {
                return _adviserList;
            }
            set
            {
                _adviserList = value;
                OnPropertyChanged("AdviserList");
            }
        }
        public AdviserModel CurrentAdviser
        {
            get
            {
                return _currentAdviser;
            }
            set
            {
                if (value != _currentAdviser)
                {
                    _currentAdviser = value;
                    OnPropertyChanged("CurrentAdviser");
                    OnPropertyChanged("AdviserTakenSubjectCollection");
                }
            }
        }
        public AdviserModel SelectedAdviser
        {
            get
            {
                return _selectedAdviser;
            }
            set
            {
                if (value != _selectedAdviser)
                {
                    _selectedAdviser = value;
                    OnPropertyChanged("SelectedAdviser");
                }
            }
        }
        public ICommand AdviserTakeSubject
        {
            get
            {
                if (_advisertakeSubject  == null)
                {
                    _advisertakeSubject = new RelayCommand(
                            param => AdviserSubject(),
                            param => (SelectedSubject != null)
                        );
                }
                return _advisertakeSubject;
            }
        }

        public ICommand AdviserDropSubject
        {
            get
            {
                if (_adviserdropSubject == null)
                {
                    _adviserdropSubject = new RelayCommand(
                            param => AdviserDroppingSubject(),
                            param => (SelectedSubject != null)
                        );
                }
                return _adviserdropSubject;
            }
        }


        public ICommand OpenAdviserViewCommand
        {
            get
            {
                if (_openAdviserViewCommand == null)
                {
                    _openAdviserViewCommand = new RelayCommand(
                        param => OpenAdviserView(),
                        param => true
                    );
                }
                return _openAdviserViewCommand;
            }
        }

        public ICommand CloseAdviserViewCommand
        {
            get
            {
                if (_closeAdviserViewCommand  == null)
                {
                    _closeAdviserViewCommand = new RelayCommand(
                        param => CloseAdviserView(),
                        param => true
                    );
                }
                return _closeAdviserViewCommand;
            }
        }

        public ICommand SaveAdviserCommand
        {
            get
            {
                if (_saveAdviserCommand == null)
                {
                    _saveAdviserCommand = new RelayCommand(
                        param => AdviserChecker(),
                        param => (CurrentAdviser != null)
                    );
                }
                return _saveAdviserCommand;
            }
        }
        public ICommand DeleteAdviserCommand
        {
            get
            {
                if (_deleteAdviserCommand == null)
                {
                    _deleteAdviserCommand = new RelayCommand(
                            param => RemoveAdviser(),
                            param => (SelectedAdviser != null)
                        );
                }
                return _deleteAdviserCommand;
            }
        }

        private void AdviserChecker()
        {
            if (CurrentAdviser.Age <= 24)
            {
                MessageBox.Show("Adviser is Underage!");
            }
            else
            {
                if (SelectedAdviser == null)
                {
                    SaveAdviser();
                }
                else
                {
                    if (CurrentAdviser.Equals(SelectedAdviser))
                    {
                        MessageBox.Show("Updated");
                    }
                    else
                    {
                        UpdateAdviser();
                    }
                }
                SelectedAdviser = null;
                CurrentAdviser = null;
                AdView.Close();
            }
        } 
        #endregion

        #region properties for sections
        public ICommand DeleteSectionCommand
        {
            get
            {
                if (_deleteSectionCommand == null)
                {
                    _deleteSectionCommand = new RelayCommand(
                            param => RemoveSection(),
                            param => (CurrentSection == null)
                        );
                }
                return _deleteSectionCommand;
            }
        }
        public ICommand EditSectionCommand
        {
            get
            {
                if (_editSectionCommand == null)
                {
                    _editSectionCommand = new RelayCommand(
                            param => UpdateSection(),
                            param => (CurrentSection == null)
                        );
                }
                return _editSectionCommand;
            }
        }
        public ICommand SectionAdviserCommand
        {
            get
            {
                if(_sectionAdviserCommand == null)
                {
                    _sectionAdviserCommand = new RelayCommand(
                        param => TakeSectionAdviser(),
                        param => (SelectedAdviser!= null));
                }
                return _sectionAdviserCommand;
            }
        }
        public AdviserModel TakenAdviser
        {
            get
            {
                return _takenadviser;
            }
            set
            {
                _takenadviser = value;
                OnPropertyChanged("TakenAdviserCollection");
            }
        }
        public ICommand SaveSectionCommand
        {
            get
            {
                if (_saveSectionCommand == null)
                {
                    _saveSectionCommand = new RelayCommand(
                        param => SectionChecker(),
                        param => (CurrentSection != null)
                    );
                }
                return _saveSectionCommand;
            }
        }
        public ICommand OpenSectionViewCommand
        {
            get
            {
                if (_openSectionCommand == null)
                {
                    _openSectionCommand = new RelayCommand(
                        param => OpenSectionView(),
                        param => true
                    );
                }
                return _openSectionCommand;
            }
        }
        public ICommand CloseSectionViewCommand
        {
            get
            {
                if (_closeSectionCommand == null)
                {
                    _closeSectionCommand = new RelayCommand(
                        param => CloseSectionView(),
                        param => true
                    );
                }
                return _closeSectionCommand;
            }
        }
        public ObservableCollection<SectionModel> SectionList
        {
            get
            {
                return _sectionList;
            }
            set
            {
                _sectionList = value;
                OnPropertyChanged("SectionList");
                OnPropertyChanged("TakenAdviserCollection");
            }
        }
        public SectionModel CurrentSection
        {
            get
            {
                return _currentSection;
            }
            set
            {
                if (value != _currentSection)
                {
                    _currentSection = value;
                    OnPropertyChanged("CurrentSection");
                }
            }
        }
        public SectionModel SelectedSection
        {
            get
            {
                return _selectedSection;
            }
            set
            {
                if (_selectedSection == null)
                    _selectedSection = new SectionModel();
                _selectedSection = value;
                OnPropertyChanged("SelectedSection");
            }
        }
        #endregion

        #region properties/Commands for students
        //For Student
        public ObservableCollection<SubjectModel> TakenSubjectCollection
        {
            get
            {
                return _takenSubjectCollection;
            }
            set
            {
                _takenSubjectCollection = value;
                OnPropertyChanged("TakenSubjectCollection");
            }
        }
        public ObservableCollection<StudentModel> StudentList
        {
            get { return _studentList; }
            set
            {
                _studentList = value;
                OnPropertyChanged("StudentList");
                OnPropertyChanged("TakenSubjectCollection");
            }
        }
        public ICommand TakeSubjectCommand
        {
            get
            {
                if (_takeSubject == null)
                {
                    _takeSubject = new RelayCommand(
                            param => TakingSubject(),
                            param => (SelectedSubject != null)
                        );
                }
                return _takeSubject;
            }
        }
        public ICommand DropSubjectCommand
        {
            get
            {
                if (_dropSubject == null)
                {
                    _dropSubject = new RelayCommand(
                            param => DroppingSubject(),
                            param => ( SelectedSubject != null ) 
                        );
                }
                return _dropSubject ;
            }
        }
        
        public StudentModel CurrentStudent
        {
            get
            {
                return _currentStudent;
            }
            set
            {
                if (value != _currentStudent)
                {
                    _currentStudent = value;
                    OnPropertyChanged("CurrentStudent");
                    OnPropertyChanged("TakenSubjectCollection");
                }
            }
        }
        public StudentModel SelectedStudent
        {
            get { return _selectedStudent; }
            set
            {
                if (_selectedStudent == null)
                    _selectedStudent = new StudentModel();
                _selectedStudent = value;                
                OnPropertyChanged("SelectedStudent");
            }
        }
        public ICommand OpenStudentViewCommand
        {
            get
            {
                if (_openStudentViewCommand  == null)
                {
                    _openStudentViewCommand = new RelayCommand(
                        param => OpenStudentView(),
                        param => true
                    );
                }
                return _openStudentViewCommand ;
            }
        }
        public ICommand CloseStudentViewCommand
        {
            get
            {
                if (_closeStudentViewCommand == null)
                {
                    _closeStudentViewCommand = new RelayCommand(
                        param => CloseStudentView(),
                        param => true 
                    );
                }
                return _closeStudentViewCommand;
            }
        }
        public ICommand DeleteStudentCommand
        {
            get
            {
                if (_deleteStudentCommand == null)
                {
                    _deleteStudentCommand = new RelayCommand(
                            param => RemoveStudent(),
                            param => (StudentList.Count > 0)
                        );
                }
                return _deleteStudentCommand;
            }
        }
        public ICommand SaveStudentCommand
        {
            get
            {
                if (_saveStudentCommand  == null)
                {
                    _saveStudentCommand  = new RelayCommand(
                        param => StudentChecker(),
                        param => (CurrentStudent != null)
                    );
                }
                return _saveStudentCommand;
            }
        }
        public ICommand EditStudentCommand
        {
            get
            {
                if (_editStudentCommand == null)
                {
                    _editStudentCommand = new RelayCommand(
                            param => UpdateStudent(),
                            param => (CurrentStudent != null)
                        );
                }
                return _editStudentCommand;
            }
        }
        #endregion

        #region properties/Commands for Subject
        //For Subject
        public ObservableCollection<SubjectModel> SubjectList
        {
            get { return _subjectList; }
            set
            {
                _subjectList = value;
                OnPropertyChanged("SubjectList");
            }
        }
        public SubjectModel CurrentSubject
        {
            get { return _currentSubject; }
            set
            {
                if (value != _currentSubject)
                {
                    _currentSubject  = value;
                    OnPropertyChanged("CurrentSubject");
                }
            }
        }
        public SubjectModel SelectedSubject
        {
            get { return _selectedSubject; }
            set
            {
                if (_selectedSubject  == null)
                    _selectedSubject  = new SubjectModel();
                _selectedSubject = value;
                OnPropertyChanged("SelectedSubject");
            }
        }
        public ICommand DeleteSubjectCommand
        {
            get
            {
                if (_deleteSubjectCommand  == null)
                {
                    _deleteSubjectCommand  = new RelayCommand(
                            param => RemoveSubject(),
                            param => (CurrentSubject == null)
                        );
                }
                return _deleteSubjectCommand;
            }
        }
        public ICommand SaveSubjectCommand
        {
            get
            {
                if (_saveSubjectCommand == null)
                {
                    _saveSubjectCommand = new RelayCommand(
                        param => SubjectChecker(),
                        param => (CurrentSubject  != null)
                    );
                }
                return _saveSubjectCommand;
            }
        }
        public ICommand EditSubjectCommand
        {
            get
            {
                if (_editSubjectCommand == null)
                {
                    _editSubjectCommand = new RelayCommand(
                            param => UpdateSubject(),
                            param => (CurrentSubject != null)
                        );
                }
                return _editSubjectCommand;
            }
        }
        public ICommand OpenSubjectViewCommand
        {
            get
            {
                if (_openSubjectViewCommand == null)
                {
                    _openSubjectViewCommand = new RelayCommand(
                            param => OpenSubjectView(),
                            param => true 
                        );
                }
                return _openSubjectViewCommand;
            }
        }
        public ICommand CloseSubjectViewCommand
        {
            get
            {
                if (_closeSubjectViewCommand == null)
                {
                    _closeSubjectViewCommand = new RelayCommand(
                            param => CloseSubjectView(),
                            param => true 
                        );
                }
                return _closeSubjectViewCommand;
            }
        }
        #endregion
        #region Private Helpers for Adviser
        private void SelectAdviser()
        {
            _currentAdviser = _selectedAdviser;
        }
        private void AdviserDroppingSubject()
        {
            _currentAdviser.SubjectSpecialty.Remove(_selectedSubject);
            AdviserTakenSubjectCollection.Remove(_selectedSubject);
            SelectedSubject = null;
        }

        private void UpdateAdviser()
        {
            _selectedAdviser.FirstName = _currentAdviser.FirstName;
            _selectedAdviser.LastName = _currentAdviser.LastName;
            _selectedAdviser.Birthdate = _currentAdviser.Birthdate;
            _selectedAdviser.Gender = _currentAdviser.Gender;
            _selectedAdviser.Rank = _currentAdviser.Rank;
            SelectedAdviser.SubjectSpecialty = _currentAdviser.SubjectSpecialty;
            _selectedAdviser.Department = _currentAdviser.Department;
            _selectedAdviser.SectionHandledList = _currentAdviser.SectionHandledList;
        }

        private void SaveAdviser()
        {
            AdviserModel adv = new AdviserModel();
            adv = CurrentAdviser;
            AdviserList.Add(adv);
        }

        private void CloseAdviserView()
        {
            AdView.Hide();
        }

        private void OpenAdviserView()
        {
            if (SelectedAdviser == null)
                CurrentAdviser = new AdviserModel();
            else
            {
                var q = new AdviserModel();
                q = _selectedAdviser;
                CurrentAdviser = SelectedAdviser ?? new AdviserModel();
                CurrentAdviser.FirstName = q.FirstName;
                CurrentAdviser.LastName = q.LastName;
                CurrentAdviser.Birthdate = q.Birthdate;
                CurrentAdviser.SubjectSpecialty = q.SubjectSpecialty;
                CurrentAdviser.Gender = q.Gender;
                CurrentAdviser.SectionHandledList = q.SectionHandledList;
                CurrentAdviser.Department = q.Department;
                CurrentAdviser.Rank = q.Rank;
            }
            AdView = new AdviserView();
            AdView.Show();
        }


        private void RemoveAdviser()
        {
            _adviserList.Remove(_selectedAdviser);
        }

        private void AdviserSubject()
        {
            _currentAdviser.SubjectSpecialty.Add(_selectedSubject);
            _advisertakenSubjectCollection.Add(_selectedSubject);
            SelectedSubject = null;
        }
        #endregion
        #region Private Helpers for student
        //For Student
        public void DroppingSubject()
        {
            if (_totalLoad == 0)
            {
                MessageBox.Show("You have no subjects to drop");
            }
            else
            {
                _totalLoad -= _selectedSubject.Units;
                _currentStudent.TakenSubjects.Remove(_selectedSubject);
                TakenSubjectCollection.Remove(_selectedSubject);
            }
            SelectedSubject = null;

        }
        private void CloseStudentView()
        {
            SelectedStudent = null;
            SV.Hide();
        }
        private void OpenStudentView()
        {
            if (SelectedStudent == null)
                CurrentStudent = new StudentModel();
            else
            {
                var q = new StudentModel();
                q = _selectedStudent;
                CurrentStudent = SelectedStudent ?? new StudentModel(); 
                CurrentStudent.FirstName = q.FirstName;
                CurrentStudent.LastName = q.LastName;
                CurrentStudent.Birthdate = q.Birthdate;
                CurrentStudent.Course = q.Course;
                CurrentStudent.Gender = q.Gender;
                CurrentStudent.RequiredUnits = q.RequiredUnits;
                CurrentStudent.TakenSubjects = q.TakenSubjects;
                CurrentStudent.Department = q.Department;
                CurrentStudent.Section = q.Section;
            }
            SV = new StudentView();
            SV.Show();
           
        }
        private void SelectStudent()
        {
            _currentStudent = _selectedStudent;
        }
        private void UpdateStudent()
        {
            _selectedStudent.FirstName  = _currentStudent.FirstName;
            _selectedStudent.LastName = _currentStudent.LastName;
            _selectedStudent.Birthdate = _currentStudent.Birthdate;
            _selectedStudent.Gender = _currentStudent.Gender;
            _selectedStudent.RequiredUnits = _currentStudent.RequiredUnits;
            SelectedStudent.TakenSubjects = _currentStudent.TakenSubjects;
            _selectedStudent.Course  = _currentStudent.Course;
            _selectedStudent.Department = _currentStudent.Department;
            _selectedStudent.Section = _currentStudent.Section;
        }
        private void SaveStudent()
        {
            StudentModel stu = new StudentModel();
            stu = CurrentStudent;
            StudentList.Add(stu);
        }
        private void StudentChecker()
        {
            if (CurrentStudent.Age <= 7)
            {
                MessageBox.Show("Student is Underage!");
            }
            else
            {
                if (SelectedStudent == null)
                {
                    SaveStudent();
                }
                else
                {
                    if (CurrentStudent.Equals(SelectedStudent))
                    {
                        MessageBox.Show("Updated");
                    }
                    else
                    {
                        UpdateStudent();
                    }
                }
                SelectedStudent = null;
                CurrentStudent = null;
                SV.Close();
            }
        }
        private void RemoveStudent()
        {
            _studentList.Remove(_selectedStudent);
        }
        private int _totalLoad;
        private void TakingSubject()
        {
            _totalLoad += _selectedSubject.Units;
            if (CurrentStudent.RequiredUnits >= _totalLoad)
            {
                _selectedStudent.TakenSubjects.Add(_selectedSubject);
                TakenSubjectCollection.Add(_selectedSubject);
                SelectedSubject = null;
            }
            else
            {
                MessageBox.Show("The Student is in Max Load");
            }
        }
        #endregion

        #region Private Helpers for Subjects
        //For Subjects
        private void OpenSubjectView()
        {
            {
                if (SelectedSubject == null)
                    CurrentSubject = new SubjectModel();
                else
                {
                    var x = new SubjectModel();
                    x  = _selectedSubject;
                    CurrentSubject = CurrentSubject ?? new SubjectModel();
                    CurrentSubject.Name = x.Name;
                    CurrentSubject.SubjectCode = x.SubjectCode;
                    CurrentSubject.Units = x.Units;
                }
            }
            SubjView = new SubjectView();
            SubjView.Show();
        }
        private void CloseSubjectView()
        {
            SubjView.Hide();
        }
        private void SelectSubject()
        {
            _currentSubject = _selectedSubject;
        }
        private void UpdateSubject()
        {
            _selectedSubject.Name = _currentSubject.Name;
            _selectedSubject.SubjectCode = _currentSubject.SubjectCode;
            _selectedSubject.Units = _currentSubject.Units;
        }
        private void SaveSubject()
        {
            SubjectModel sub = new SubjectModel();
            sub = CurrentSubject;
            SubjectList.Add(sub);
        }
        private void SubjectChecker()
        {
            if (SelectedSubject == null)
            {
                SaveSubject();
            }
            else
            {
                if (CurrentSubject.Equals(SelectedSubject))
                {
                    MessageBox.Show("You have not made any changes to this entry");
                }
                else
                {
                    UpdateSubject();
                }
            }
            SelectedSubject = null;
            CurrentSubject = null;
            SubjView.Close();
        }
        private void RemoveSubject()
        {
            _subjectList.Remove(_selectedSubject);
        }
        #endregion
        #region Private Helpers for Sections
        private void OpenSectionView()
        {
            if (SelectedSection == null)
                CurrentSection = new SectionModel();
            else
            {
                var q = new SectionModel();
                q = _selectedSection;
                CurrentSection = SelectedSection ?? new SectionModel();
                CurrentSection.SectionName = q.SectionName;
                CurrentSection.Adviser  = q.Adviser;
                CurrentSection.Department = q.Department;
                CurrentSection.NumberOfStudents = q.NumberOfStudents;
                CurrentSection.StudentsEnrolled = q.StudentsEnrolled;
            }
            SecView = new SectionView();
            SecView.Show();
        }
        private void CloseSectionView()
        {
            SecView.Hide();
        }

        private void SectionChecker()
        {
            if (SelectedSection == null)
            {
                SaveSection();
            }
            else
            {
                if (CurrentSection.Equals(SelectedSection))
                {
                    MessageBox.Show("Updated");
                }
                else
                {
                    UpdateSection();
                }
            }
            SelectedSection = null;
            CurrentSection = null;
            SecView.Close();
        }

        private void SaveSection()
        {
            SectionModel sec = new SectionModel();
            sec = CurrentSection;
            SectionList.Add(sec);
        }

        private void UpdateSection()
        {
            _selectedSection.SectionName = _currentSection.SectionName;
            SelectedSection.Adviser  = _currentSection.Adviser;
            _selectedSection.Department = _currentSection.Department;
            _selectedSection.NumberOfStudents = _currentSection.NumberOfStudents;
            _selectedSection.StudentsEnrolled = _currentSection.StudentsEnrolled;
        }

        private void RemoveSection()
        {
            _sectionList.Remove(_selectedSection);
        }
        private void TakeSectionAdviser()
        {
            CurrentSection.Adviser = _selectedAdviser;
            TakenAdviser = _selectedAdviser;
            SelectedAdviser = null;
        }
        #endregion
    }
}
