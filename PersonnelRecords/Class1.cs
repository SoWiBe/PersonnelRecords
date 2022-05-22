using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelRecords
{
    public partial class StaffBaseEntities
    {
        private static StaffBaseEntities _context;
        public static StaffBaseEntities GetContext()
        {
            if (_context == null)
                _context = new StaffBaseEntities();
            return _context;
        }
    }
}
