using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G
{
    [Table("Exits1")]
    internal class Exit1
    {
        [Key]
        [Column(Order = 3)]
        public int iter_number { get; set; }
        [Key]
        [Column(Order = 2)]
        public int variant { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double eps { get; set; }
        [Key]
        [Column(Order = 0)]
        public string data_time { get; set; }


        public Exit1() { }
        public Exit1(int variant, int iter_number, int X, double eps)

        {
            this.eps = eps;
            this.variant = variant;
            this.iter_number = iter_number;
            this.X = X;
            this.Y = Y;
        }
    }

}

