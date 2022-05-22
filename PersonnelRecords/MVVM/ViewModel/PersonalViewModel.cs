using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelRecords.MVVM.ViewModel
{
    

    class PersonalViewModel : ObservableObject
    {
        public ObservableCollection<Employees> Employees { get; set; }

        public PersonalViewModel()
        {
            Employees = new ObservableCollection<Employees>();


            var listEmployees = StaffBaseEntities.GetContext().Employees.ToList();
            foreach (var employee in listEmployees)
            {
                Employees.Add(employee);
            }
        }

    }
}
