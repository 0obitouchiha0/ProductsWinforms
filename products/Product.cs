using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace products
{
    public class Product
    {
        public string vendorCode;
        public string name;
        public int workshopNumber;
        public int price;
        public string type;
        public string img;

        public Product(string vendorCode, string name, int workshopNumber, int price, string type, string img)
        { 
            this.vendorCode = vendorCode;
            this.name = name;
            this.workshopNumber = workshopNumber;
            this.price = price;
            this.type = type;
            this.img = img;
        }

        public Product(string vendorCode, string name, int workshopNumber, int price, string type)
        {
            this.vendorCode = vendorCode;
            this.name = name;
            this.workshopNumber = workshopNumber;
            this.price = price;
            this.type = type;
            img = "./placeholderImg.png";
        }
    }
}
