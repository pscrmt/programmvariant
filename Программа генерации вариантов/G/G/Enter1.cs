using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G
{
    [Table("Enters1")]
    public class Enter1
    {
        [Key]
        [Column(Order = 1)]
        public int variant { get; set; }
        public int start { get; set; }
        public int end { get; set; }
        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }
        public double D { get; set; }
        [Key]
        [Column(Order = 2)]
        public string data_time { get; set; }


        public Enter1() { }
        public Enter1(int start, int end) 
        {            
            this.start = start;
            this.end = end;
        }
        public Enter1(int variant, double A, double B, double C, double D) 
        {
            this.variant = variant;
            this.A = A;
            this.B = B;
            this.C = C;
            this.D = D;
            this.data_time = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
        }

    }
    
}
