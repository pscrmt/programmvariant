using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Windows;
using System.Reflection.Emit;

namespace G
{
    internal class AppContext:DbContext
    {
       

        public DbSet<First> Firsts { get; set; }
        public DbSet<Enter1> Enters1 { get; set; }
        public DbSet<Exit1> Exits1 { get; set; }
        //public DbSet<LR> LRs{ get; set; }
        //public DbSet<Variant> Variants { get; set; }
        //public DbSet<Data_save_student> Data_save_students { get; set; }
        //public DbSet<Data_save_teacher> Data_save_teachers { get; set; }

        public AppContext() : base("DefaultConnection") { }

      

        
    }
}
