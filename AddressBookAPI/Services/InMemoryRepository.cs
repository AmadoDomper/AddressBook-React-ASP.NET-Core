using AddressBookAPI.Entities;

namespace AddressBookAPI.Services
{
    public class InMemoryRepository : IRepository
    {
        private List<Contact> _contacts;
        public InMemoryRepository()
        {
            _contacts = new List<Contact>()
            {
                new Contact(){Id = 1, Name ="Amado", Email ="amado.domper@gmail.com", Phone="+51 993998677"},
                new Contact(){Id = 2, Name = "Pedro", Email ="pedro@gmail.com", Phone="+65 993998688"},
                new Contact(){Id = 3, Name = "Juan", Email ="juan@gmail.com", Phone="+65 993998688"},
                new Contact(){Id = 4, Name = "Rodrigo", Email ="rodrigo@gmail.com", Phone="+31 993888688"},
                new Contact(){Id = 5, Name = "Luis", Email ="luis@gmail.com", Phone="+29 993996288"},
            };
        }

        public List<Contact> GetAllContacts()
        {
            return _contacts;
        }

        public Contact GetContact(int id)
        {
            return _contacts.FirstOrDefault(contact => contact.Id == id);
        }

        public void AddContact(Contact contact)
        {
            contact.Id = _contacts.Max(contact => contact.Id) + 1;
            _contacts.Add(contact);
        }

        public void UpdateContact(Contact contact, int id)
        {
            var index = _contacts.FindIndex(contact => contact.Id == id);

            if (index >= 0)
            {
                _contacts[index] = contact;
            }
        }

        public void DeleteContact(int id)
        {
            var itemToRemove = _contacts.FirstOrDefault(contact => contact.Id == id);

            if(itemToRemove != null)
            {
                _contacts.Remove(itemToRemove);
            }
            
        }
    }
}
