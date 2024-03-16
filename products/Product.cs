using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace products
{
    public class Product
    {
        public int id;
        public string title;
        public string type;
        public int articlenumber;
        public string description;
        public string image;
        public int productionpersoncount;
        public int productionworkshopnumber;
        public int mincostforagent;

        public Product(int id, string title, int articlenumber, int mincostforagent, string type = "", string description = "", string image = "", int productionpersoncount = 0, int productionworkshopnumber = 0)
        {
            this.id = id;
            this.title = title;
            this.type = type;
            this.articlenumber = articlenumber;
            this.description = description;
            this.image = image;
            this.productionpersoncount = productionpersoncount;
            this.productionworkshopnumber = productionworkshopnumber;
            this.mincostforagent = mincostforagent;
        }
    }
}
