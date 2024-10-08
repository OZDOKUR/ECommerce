﻿using Entities.Concrete;

namespace ECommerce.Models.ViewModels
{
    public class AddressViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string Country{ get; set; }
        public string State{ get; set; }
        public string PhoneNumber { get; set; }
        public string PostalCode { get; set; }
    }
}

