using AddressBookAPI.Entities;
using AddressBookAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace AddressBookAPI.Controllers
{
    [Route("api/contacts")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IRepository _repository;
        public ContactsController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public List<Contact> Get()
        {
            return _repository.GetAllContacts();
        }

        [HttpGet("{id:int}", Name = "getContact")]
        public Contact Get(int id)
        {
            return _repository.GetContact(id);
        }

        [HttpPost]
        public  ActionResult Post(Contact contact)
        {
             _repository.AddContact(contact);

            return NoContent();
        }


        [HttpPut("{id:int}")]
        public ActionResult Put(Contact contact, int id)
        {
            _repository.UpdateContact(contact, id);

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            _repository.DeleteContact(id);
            return NoContent();
        }

    }
}
