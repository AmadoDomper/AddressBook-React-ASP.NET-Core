using AddressBookAPI.DTOs;
using AddressBookAPI.Entities;
using AddressBookAPI.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AddressBookAPI.Controllers
{
    [Route("api/contacts")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IRepository<Contact, int> _repository;
        private readonly IMapper mapper;

        public ContactsController(IRepository<Contact, int> repository, IMapper mapper)
        {
            _repository = repository;
            this.mapper = mapper;
        }

        [HttpGet]
        public List<ContactDTO> Get()
        {
            var contacts = _repository.GetAll();
            return mapper.Map<List<ContactDTO>>(contacts);
        }

        [HttpGet("{id:int}", Name = "getContact")]
        public ContactDTO Get(int id)
        {
            var contact = _repository.GetById(id);
            return mapper.Map<ContactDTO>(contact);
        }

        [HttpPost]
        public  ActionResult Post(ContactCreationDTO contactCreationDTO)
        {
            var contact = mapper.Map<Contact>(contactCreationDTO);
             _repository.Insert(contact);

            return NoContent();
        }


        [HttpPut("{id:int}")]
        public ActionResult Put(ContactCreationDTO contactCreationDTO, int id)
        {
            var contact = mapper.Map<Contact>(contactCreationDTO);
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
