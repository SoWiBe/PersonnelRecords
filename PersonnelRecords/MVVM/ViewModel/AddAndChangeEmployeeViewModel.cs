using PersonnelRecords.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PersonnelRecords.MVVM.ViewModel
{
    class AddAndChangeEmployeeViewModel : ObservableObject
    {
        public string NamePage { get; set; }
        public string SelectedDate { get; set; }

        private Employees employee;
        public Employees Employee { get; set; }
        public string FIO { get; set; }

        public ObservableCollection<string> Genders { get; set; }
        public ObservableCollection<Positions> Positions { get; set; }

        private string _selectedDateOfBirth;
        public string SelectedDateOfBirth
        {
            get
            {
                return _selectedDateOfBirth;
            }

            set
            {
                _selectedDateOfBirth = value;
                OnPropertyChanged();
            }
        }

        private string _selectedGender;
        public string SelectedGender
        {
            get
            {
                return _selectedGender;
            }

            set
            {
                _selectedGender = value;
                OnPropertyChanged();
            }
        }

        private Positions _selectedPosition;
        public Positions SelectedPosition
        {
            get
            {
                return _selectedPosition;
            }

            set
            {
                _selectedPosition = value;
                OnPropertyChanged();
            }
        }

        public ICommand SaveCommand { get; set; }
        public ICommand BackCommand { get; set; }

        public AddAndChangeEmployeeViewModel(string namePage, Employees employee)
        {
            this.NamePage = namePage;
            if(employee != null)
            {
                this.Employee = employee;
                this.employee = employee;
            }
            
            Genders = new ObservableCollection<string>();
            Genders.Add("Мужской");
            Genders.Add("Женский");

            Positions = new ObservableCollection<Positions>();
            var pos = StaffBaseEntities.GetContext().Positions.ToList();
            for (int i = 0; i < pos.Count; i++)
            {
                Positions.Add(pos[i]);

            }

            if (Employee != null)
            {
                FIO = Employee.FIO;
                if (Employee.Gender.Equals("Мужской")) SelectedGender = Genders[0];
                else SelectedGender = Genders[1];
                SelectedPosition = StaffBaseEntities.GetContext().Positions.Where(x => x.Name == Employee.Positions.Name).First();
                SelectedDate = Employee.DateOfBirth;
            }

            SaveCommand = new RelayCommand(o => SaveInformation());
            BackCommand = new RelayCommand(o => GoBack());
        }

        private void GoBack()
        {
            FrameManager.MainFrame.Navigate(new PersonalPage());
        }

        private void SaveInformation()
        {
            if (employee == null)
                employee = new Employees();

            if(!CheckCorrectInfo(FIO, SelectedGender, SelectedPosition))
            {
                return;
            }

            employee.FIO = FIO;
            employee.Gender = SelectedGender;
            employee.Positions = SelectedPosition;
            employee.DateOfBirth = SelectedDate;

            if (employee.Id == 0)
            {
                StaffBaseEntities.GetContext().Employees.Add(employee);
            }

            StaffBaseEntities.GetContext().SaveChanges();
            MessageBox.Show("Информация сохранена!");
        }

        private bool CheckCorrectInfo(string fio, string gender, Positions position)
        {
            if(string.IsNullOrEmpty(fio) || string.IsNullOrEmpty(gender) || position is null)
            {
                MessageBox.Show("Введена не вся информация!!!");
                return false;
            }
            return true;
        }
    }
}
