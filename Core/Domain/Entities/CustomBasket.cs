using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CustomBasket
    {
        public string Id { get; set; }
        public IEnumerable<BasketItem> Item{ get; set; }
    }
}
