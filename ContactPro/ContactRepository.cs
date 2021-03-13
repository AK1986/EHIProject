using ContactPro.Data;
using ContactPro.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactPro
{
    public class ContactRepository : IContactRepository
    {
        private ContactDbContext _dbContext;
        public ContactRepository(ContactDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task<int> CreateContact(Contact contact)
        {
            try
            {
                _dbContext.Add(contact);
                await _dbContext.SaveChangesAsync();
                return contact.ContactId;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task DeleteContact(int contactId)
        {
            try
            {
                var contact = await _dbContext.Contact.FindAsync(contactId);
                if (contact == null)
                {
                    throw new Exception("NOT_FOUND");
                }

                _dbContext.Contact.Remove(contact);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Contact> GetContact(int contactId)
        {
            try
            {
                var contact = await _dbContext.Contact.FindAsync(contactId);
                return contact;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Contact>> GetContacts()
        {
            try
            {
                return await _dbContext.Contact.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task UpdateContact(Contact contact)
        {
            try
            {
                _dbContext.Entry(contact).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactExists(contact.ContactId))
                {
                    throw new Exception("NOT_FOUND");
                }
                else
                {
                    throw;
                }
            }
        }
        private bool ContactExists(int id)
        {
            return _dbContext.Contact.Any(e => e.ContactId == id);
        }
    }
}
