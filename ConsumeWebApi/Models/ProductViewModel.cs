using System.ComponentModel.DataAnnotations;

namespace ConsumeWebApi.Models
{
    public class ProductViewModel
    {
        [Key]
        public int Pid { get; set; }
        public string Pname { get; set; }
        public int PPrice { get; set; }
        public string Category { get; set; }

    }
}
