using AddressBookAPI.Entities;
using AddressBookAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AddressBookAPI.Controllers
{
    [Route("api/contacts")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IRepository<Contact, int> _repository;
        public ContactsController(IRepository<Contact, int> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public List<Contact> Get()
        {
            return _repository.GetAll();
        }

        [HttpGet("{id:int}", Name = "getContact")]
        public Contact Get(int id)
        {
            return _repository.GetById(id);
        }

        [HttpPost]
        public  ActionResult Post(Contact contact)
        {
             _repository.Insert(contact);

            return NoContent();
        }


        [HttpPut("{id:int}")]
        public ActionResult Put(Contact contact, int id)
        {
            _repository.Update(contact, id);

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            _repository.Delete(id);
            return NoContent();
        }

    }
}
