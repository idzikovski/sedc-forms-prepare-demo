namespace RealEstate.Models
{
    public class Estate
    {
		public string Id { get; set; }

		public string DataPartitionId { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string Company { get; set; }

		public string JobTitle { get; set; }

		public string Email { get; set; }

		public string Phone { get; set; }

		public string Street { get; set; }

		public string City { get; set; }

		public string PostalCode { get; set; }

		public string State { get; set; }

		public string PhotoUrl { get; set; }

		public string AddressString { get; }

		public string DisplayName { get; }

		public string DisplayLastNameFirst { get; }

		public string StatePostal { get; }
	}
}
