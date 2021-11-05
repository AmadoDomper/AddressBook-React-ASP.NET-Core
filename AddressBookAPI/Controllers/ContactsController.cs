using AddressBookAPI.Entities;
using AddressBookAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace AddressBookAPI.Controllers
{
    [Route("api/contacts")]
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

        [HttpGet("{Id:int}", Name = "getContact")]
        public Contact Get(int Id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public Task<ActionResult> Post([FromBody] Contact contact)
        {
            throw new NotImplementedException();
        }


        [HttpPut]
        public ActionResult Put()
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        public ActionResult Delete()
        {
            throw new NotImplementedException();
        }

    }
}
