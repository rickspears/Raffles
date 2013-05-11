using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raffles.DomainObjects.Entities
{
    [ComplexType]
    public class ContactDetails
    {
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zip { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool CanText { get; set; }
    }
}
