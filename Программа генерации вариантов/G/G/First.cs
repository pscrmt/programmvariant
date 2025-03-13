using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G
{
    internal class First
    {
        [Key]
        public int var1 { get; set; }
         public string typerasp { get; set; }
       

        public First() { }


        public First(string typerasp)
        {
            this.typerasp = typerasp;
        }

    }
}
    