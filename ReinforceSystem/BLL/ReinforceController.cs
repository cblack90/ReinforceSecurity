using ReinforceSystem.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReinforceSystem.BLL
{
    [DataObject]
    public class ReinforceController
    {
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Staff> ListStaff()
        {
            using (var context = new ReinforceContext())
            {
                return context.Staffs.ToList();
            }
        }
    }
}
