using System;
using System.ComponentModel.DataAnnotations;

namespace SistemaGestaoAPI
{
    public class Customer
    {
        public Customer()
        {

        }

        public Customer(int _id, string _name, string _phone1, string _phone2, string  _address, string  _dateBirthday)
        {
            this.Id = _id;
            this.Name = _name;
            this.Phone1 = _phone1;
            this.Phone2 = _phone2;
            this.Address = _address;
            this.DateBirthday = _dateBirthday;
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Phone1 { get; set; }

        [Required]
        public string Phone2 { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string DateBirthday { get; set; }
    
    }
}
