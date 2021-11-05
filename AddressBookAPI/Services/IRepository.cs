using AddressBookAPI.Entities;

namespace AddressBookAPI.Services
{
    public interface IRepository
    {
        void AddContact(Contact contact);
        void DeleteContact(int id);
        List<Contact> GetAllContacts();
        Contact GetContact(int id);
        void UpdateContact(Contact contact, int id);
    }
}
