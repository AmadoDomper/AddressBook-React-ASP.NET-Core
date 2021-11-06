using AddressBookAPI.Entities;

namespace AddressBookAPI.Repositories
{
    public class InMemoryRepository : IRepository<Contact, int>
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

        public List<Contact> GetAll()
        {
            return _contacts;
        }

        public Contact GetById(int id)
        {
            return _contacts.FirstOrDefault(value => value.Id == id);
        }

        public void Insert(Contact contact)
        {
            contact.Id = _contacts.Max(value => value.Id) + 1;
            _contacts.Add(contact);
        }

        public void Update(Contact contact, int id)
        {
            var index = _contacts.FindIndex(value => value.Id == id);

            if (index >= 0)
            {
                _contacts[index] = contact;
                _contacts[index].Id = id;
            }
        }

        public void Delete(int id)
        {
            var itemToRemove = _contacts.FirstOrDefault(value => value.Id == id);

            if (itemToRemove != null)
            {
                _contacts.Remove(itemToRemove);
            }

        }
    }
}