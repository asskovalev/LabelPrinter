using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LabelPrinter
{
    public class Label
    {
        public Label() { }
        public Label(string addressee, int postalCode, string address, string city)
        {
            PostalCode = postalCode;
            Address = address;
            Addressee = addressee;
            City = city;
        }
        
        public int PostalCode { get; set; }
        public string Addressee { get; set; }
        public string City { get; set; }
        public string Address { get; set; }

        public override string ToString()
        {
            return string.Format("{0}, {1} {2} {3}", Addressee, PostalCode, City, Address);
        }
    }
}
