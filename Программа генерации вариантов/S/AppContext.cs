using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Windows;
using System.Reflection.Emit;

namespace S
{
    internal class AppContext:DbContext
    {
        public DbSet<Exit1> Exits1 { get; set; }
        public AppContext() : base("DefaultConnection") { }
    }
}
