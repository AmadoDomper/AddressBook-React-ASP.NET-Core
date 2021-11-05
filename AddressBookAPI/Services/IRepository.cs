using AddressBookAPI.Entities;

namespace AddressBookAPI.Services
{
    public interface IRepository
    {
        List<Contact> GetAllContacts();
    }
}
