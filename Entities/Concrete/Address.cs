namespace Entities.Concrete
{
    public class Address
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        public string Name { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public ApplicationUser User { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
        public int StateId { get; set; }
        public State State { get; set; }
        public int CountryId { get; set; }
        public string PhoneNumber { get; set; }
        public Country Country { get; set; }
        public string PostalCode { get; set; }
    }
}
