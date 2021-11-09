using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ADD_CUSTOMER
{
    public class Db:DbContext
    {
        public Db() : base("javad") { }
        public DbSet<customer> customers  { get; set; }
    }
}
