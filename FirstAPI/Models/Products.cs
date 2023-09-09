
using System.ComponentModel.DataAnnotations;

namespace FirstAPI.Models
{
    public class Products
    {
        [Key]
        public int Pid { get; set; }
        public string Pname { get; set; }
        public int PPrice { get; set; }
        public string Category { get; set; }
    }
}
