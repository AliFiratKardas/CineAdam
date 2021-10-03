using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entity
{
    public class Saloon:BaseEntity
    {
        public Saloon()
        {
            CreatedDate = DateTime.Now;
        }
        public string SaloonName { get; set; }
        public short Capacity { get; set; }
    }
}
