using Oerdering.DOMAIN.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oerdering.DOMAIN.Entities
{
    public class Order : EntityBase
    {
        public string Username { get; set; }
        public decimal TotalPrice { get; set; }

        //billing details
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string AddressLine { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }


        //payment details
        public string  CardName { get; set; }
        public string CardNumber { get; set; }
        public string Expiration { get; set; }
        public string CVV { get; set; }
        public int PaymentMethod { get; set; }



    }
}
