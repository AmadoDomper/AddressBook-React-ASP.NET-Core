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
        public ActionResult<List<ContactDTO>> Get()
        {
            var contacts = _repository.GetAll();
            return Ok(mapper.Map<List<ContactDTO>>(contacts));
        }

        [HttpGet("{id:int}", Name = "getContact")]
        public ActionResult<ContactDTO> Get(int id)
        {
            var contact = _repository.GetById(id);

            if(contact == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<ContactDTO>(contact));
        }

        [HttpPost]
        public  ActionResult Post(ContactCreationDTO contactCreationDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var contact = mapper.Map<Contact>(contactCreationDTO);
            var newContact = mapper.Map<ContactDTO>(_repository.Insert(contact));

            return CreatedAtAction(nameof(Get), new {id = newContact.Id}, newContact);
        }


        [HttpPut("{id:int}")]
        public ActionResult Put(ContactCreationDTO contactCreationDTO, int id)
        {
            var existingContact = _repository.GetById(id);

            if (existingContact == null)
            {
                return NotFound();
            }

            var contact = mapper.Map<Contact>(contactCreationDTO);
            _repository.Update(contact, id);

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var existingContact = _repository.GetById(id);

            if(existingContact == null)
            {
                return NotFound();
            }

            _repository.Delete(id);
            return NoContent();
        }

    }
}
