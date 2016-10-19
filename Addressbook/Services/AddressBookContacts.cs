using System;
using System.Collections.Generic;
using Addressbook.Repositories;
using Addressbook.Domain.Entities;
using System.IO;
using System.Linq;
using AddressBook.Helper;

namespace Addressbook.Services
{
    public class ContactService
    {
        private readonly ContactRepository _contactRepository;
        public ContactService()
        {
            var path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            _contactRepository = ContactRepository.GetInstance();

            //_contactRepository = contactRepository;
        }

        public IEnumerable<Contact> GetAllContacts()
        {
            return _contactRepository.GetAll();
        }

        public void AddContact(Contact newContact)
        {
            _contactRepository.AddContact(newContact);
        }
        
        public void DeleteContactById(Guid id)
        {
            _contactRepository.DeleteContactById(id);            
        }

        public void DeleteBy(string name)
        {
            _contactRepository.DeleteBy(name);
        }

        public Contact FindContactById(Guid id)
        {
            return _contactRepository.FindContactById(id);
        }

        public Contact FindBy(string name)
        {
            return _contactRepository.FindBy(name);
        }

        public IEnumerable<Contact> SearchContacts(string searchText)
        {
            
            var result = GetAllContacts().Where(c => c.Name.Contains(searchText, true)
                                                || c.DateOfBirth.ToString("yyyy-MM-dd").Contains(searchText, true)
                                                || c.Email.Value.Contains(searchText, true)
                                                || c.Address.Street.Contains(searchText, true)
                                                || c.Address.Street2.Contains(searchText, true)
                                                || c.Address.ZipCode.Contains(searchText, true)
                                                || c.Address.City.Contains(searchText, true));
            return result;
        }
    }
}