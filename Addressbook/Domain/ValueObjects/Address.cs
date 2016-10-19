namespace Addressbook.Domain.ValueTypes
{
    public class Address
    {
        public string Street { get; set; }
        public string Street2 { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }

        public Address(string street, string street2, string zipCode, string city )
        {
            Street = street;
            Street2 = street2;
            ZipCode = zipCode;
            City = city;
        }

        public Address()
            :this("", "", "", "")
        {

        }

        public override string ToString()
        {
            return $"{Street}, {Street2}, {ZipCode} {City}";
        }

    }
}
