using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Core.Models
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }
        public string CartId { get; set; }

        public int ProductId { get; set; }

        public DateTime CreatedDate { get; set; }

        public int Count { get; set; }

        public virtual Product Product { get; set; }
    }
}
