using DemoSystem.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSystem.BLL
{
    class PracticeController
    {
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Staff> ListStaff()
        {
            using (var context = new DemoContext())
            {
                return context.Staff.ToList();
            }
        }
    }
}
