using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Test.Models;

namespace Test.Services
{
    public class ItemService
    {

        public ItemService()
        {

        }

        public bool IsOnSale(Item item)
        {
            //Return true if the item is on sale, return false other wise
            if(item.isOnSale)
                return true;
            return false;
        }
    }
}