using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models
{
    public class ItemQuantity
    {
        public int ItemId { get; }
        public int Quantity { get; }

        public ItemQuantity(int id, int quantity) 
        {
            ItemId = id;
            Quantity = quantity;
        }


    }
}
