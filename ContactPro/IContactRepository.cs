using ContactPro.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactPro
{
    public interface IContactRepository
    {
        Task<Contact> GetContact(int contactId);
        Task<List<Contact>> GetContacts();
        Task<int> CreateContact(Contact contact);
        Task UpdateContact(Contact contact);
        Task DeleteContact(int contactId);
    }
}
