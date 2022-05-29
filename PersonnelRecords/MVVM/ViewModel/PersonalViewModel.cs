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
    class PersonalViewModel : ObservableObject
    {
        //List of employees for DataGrid
        public ObservableCollection<Employees> Employees { get; set; }
        public ObservableCollection<Positions> Positions { get; set; }
        public ObservableCollection<Subdivisions> Subdivisions { get; set; }

        //Choosed Employee for manipulating his information
        private Employees _selectedEmployee;
        
        public Employees SelectedEmployee
        {
            get
            {
                return _selectedEmployee;
            }
            set
            {
                _selectedEmployee = value;
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
                SortByPosition();
            }
        }
        private Subdivisions _selectedSubdivision;

        public Subdivisions SelectedSubdivision
        {
            get
            {
                return _selectedSubdivision;
            }
            set
            {
                _selectedSubdivision = value;
                OnPropertyChanged();
                SortBySubdivision();
            }
        }

        public ICommand AddNewEmployeeCommand { get; set; }
        public ICommand DeleteEmployeeCommand { get; set; }
        public ICommand ChangeEmployeeCommand { get; set; }
        public ICommand ClearInfoCommand { get; set; }
        public PersonalViewModel()
        {
            Employees = new ObservableCollection<Employees>(StaffBaseEntities.GetContext().Employees.ToList());
            Positions = new ObservableCollection<Positions>(StaffBaseEntities.GetContext().Positions.ToList());
            Subdivisions = new ObservableCollection<Subdivisions>(StaffBaseEntities.GetContext().Subdivisions.Where(x => x.IdType == 1).ToList());

           
            AddNewEmployeeCommand = new RelayCommand(o => AddNewEmployee());
            DeleteEmployeeCommand = new RelayCommand(o => DeleteEmployee(), o => SelectedEmployee != null);
            ChangeEmployeeCommand = new RelayCommand(o => ChangeEmployee(), o => SelectedEmployee != null);
            ClearInfoCommand = new RelayCommand(o => UpdateInfo());
        }

        private void SortByPosition()
        {
            Employees.Clear();
            var x = StaffBaseEntities.GetContext().Employees.Where(y => y.Positions.Name.Equals(SelectedPosition.Name)).ToList();
            for (int i = 0; i < x.Count(); i++)
            {
                Employees.Add(x[i]);
            }
        }
        private void SortBySubdivision()
        {
            Employees.Clear();
            var x = StaffBaseEntities.GetContext().Employees.Where(y => y.Positions.Subdivisions.Info.Equals(SelectedSubdivision.Info)).ToList();
            for (int i = 0; i < x.Count(); i++)
            {
                Employees.Add(x[i]);
            }
        }
        private void UpdateInfo()
        {
            Employees.Clear();
            var x = StaffBaseEntities.GetContext().Employees.ToList();
            for (int i = 0; i < x.Count(); i++)
            {
                Employees.Add(x[i]);
            }
        }

        private void AddNewEmployee()
        {
            FrameManager.MainFrame.Navigate(new AddAndChangeEmployeePage("Добавление сотрудника", null));
        }

        private void DeleteEmployee()
        {
            var mbDelete = MessageBox.Show("Вы действительно хотитет удалить сотрудника - " + SelectedEmployee.FIO + " ?", "Удаление", MessageBoxButton.YesNo);

            if (mbDelete == MessageBoxResult.Yes)
            {
                StaffBaseEntities.GetContext().Employees.Remove(SelectedEmployee);
                StaffBaseEntities.GetContext().SaveChanges();
                MessageBox.Show("Удаление прошло успешно!");
                UpdateInfo();
            }
        }

        private void ChangeEmployee()
        {
            FrameManager.MainFrame.Navigate(new AddAndChangeEmployeePage("Редактирование сотрудника", SelectedEmployee));
        }

    }
}
