using Addressbook.Domain.ValueTypes;
using System;

namespace Addressbook.Domain.Entities
{
    public class Contact
    {
        public Contact(string name, DateTime dob, Email email)
            :this(name, dob, email, new Address())
        {
        }

        public Contact(Guid id, string name, DateTime dob, Email email)
            : this(id, name, dob, email, new Address())
        {
        }

        public Contact(string name, DateTime dob, Email email, Address address)
            :this(Guid.NewGuid(), name, dob, email, address)
        {
        }
        public Contact() { }
        public Contact(Guid id, string name, DateTime dob, Email email, Address address)
        {
            Id = id;
            Name = name;
            DateOfBirth = dob;
            Email = email;
            Address = address;

        }

        public Guid Id { get; set; }
        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }
        public int Age
        {
            get
            {
                return (int)(DateTime.Now.Subtract(DateOfBirth).TotalDays / 365.0d);
            }
        }
        public Email Email { get; set; }

        public Address Address { get; set; }

        public override string ToString()
        {
            return $"Id: '{Id}', Name: '{Name}', Age: '{Age}', Email: '{Email.Value}', Address: {Address}";
        }
    }
}
