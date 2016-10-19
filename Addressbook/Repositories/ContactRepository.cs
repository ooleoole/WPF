using System.Collections.Generic;
using Addressbook.Domain.Entities;
using System.IO;
using System;
using System.Xml.Serialization;

namespace Addressbook.Repositories
{
    public class ContactRepository
    {
        List<Contact> contacts = new List<Contact>();
        private static ContactRepository instance;
        private string contactFile;

        public static ContactRepository GetInstance()
        {
            if (instance==null)
            {
                instance = new ContactRepository();
            }
            return instance;
        }
        private ContactRepository()
        {
            var path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            contactFile = Path.Combine(path, "contacts.xml");
            Load();
        }

        public IEnumerable<Contact> GetAll()
        {
            return contacts;
        }
       
        public void AddContact(Contact newContact)
        {
            contacts.Add(newContact);
            Save();
        }

        public Contact FindBy(string name)
        {
            return contacts.Find(x => x.Name == name);
        }

        public Contact FindContactById(Guid id)
        {
            return contacts.Find(x => x.Id == id);
        }

        public void DeleteContactById(Guid id)
        {
            var user = FindContactById(id);
            contacts.Remove(user);
            Save();
        }

        public void Load()
        {
            using (Stream stream = File.Open(contactFile, FileMode.Open))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Contact>));
                contacts = (List<Contact>)serializer.Deserialize(stream);

            }
        }

        internal void DeleteBy(string name)
        {
            var user = FindBy(name);
            contacts.Remove(user);
            Save();
        }

        public void Save()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Contact>));
            using (Stream stream = File.Open(contactFile, FileMode.Create))
            {
                serializer.Serialize(stream, contacts);
            }
        }

    }
}
