using AddressBookAPI.Controllers;
using AddressBookAPI.DTOs;
using AddressBookAPI.Helper;
using AddressBookAPI.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AddressBookAPI.Test
{
    public class ContactControllerTest
    {
        private InMemoryRepository _repository;
        private ContactsController _controller;

        public ContactControllerTest()
        {
            _repository = new InMemoryRepository();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfiles());
            });
            var mapper = config.CreateMapper();

            _controller = new ContactsController(_repository, mapper);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult = _controller.Get();
            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsAllContacts()
        {
            // Act
            var okResult = _controller.Get().Result as OkObjectResult;

            // Assert
            var items = Assert.IsType<List<ContactDTO>>((okResult.Value));
            Assert.Equal(5, items.Count);
        }

        [Fact]
        public void GetById_UnknownIdPassed_ReturnsNotFoundResult()
        {
            // Act
            var notFoundResult = _controller.Get(100);

            // Assert
            Assert.IsType<NotFoundResult>(notFoundResult.Result);
        }

        [Fact]
        public void GetById_ExistingId_ReturnsOkResult()
        {
            // Arrange
            var testId = 1;

            // Act
            var okResult = _controller.Get(testId);

            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void GetById_ExistingIdPassed_ReturnsRightItem()
        {
            // Arrange
            var testId = 1;

            // Act
            var okResult = _controller.Get(testId).Result as OkObjectResult;

            // Assert
            Assert.IsType<ContactDTO>(okResult.Value);
            Assert.Equal(testId, (okResult.Value as ContactDTO).Id);
        }

        [Fact]
        public void Add_InvalidObjectPassed_ReturnsBadRequest()
        {
            // Arrange
            var phoneMissignItem = new ContactCreationDTO()
            {
                Name = "Mark Watney",
                Email = "mark.watney@gmail.com"
            };
            _controller.ModelState.AddModelError("phone", "required");

            // Act
            var badResponse = _controller.Post(phoneMissignItem);

            // Assert
            Assert.IsType<BadRequestObjectResult>(badResponse);
        }

        [Fact]
        public void Add_ValidObjectPassed_ReturnsCreatedResponse()
        {
            // Arrange
            ContactCreationDTO testContact = new ContactCreationDTO()
            {
                Name = "Mark Watney",
                Email = "mark.watney@gmail.com",
                Phone = "+63 969856522"
            };
            // Act
            var createdResponse = _controller.Post(testContact);
            // Assert
            Assert.IsType<CreatedAtActionResult>(createdResponse);
        }

        [Fact]
        public void Add_ValidObjectPassed_ReturnedResponseHasCreatedItem()
        {
            // Arrange
            ContactCreationDTO testContact = new ContactCreationDTO()
            {
                Name = "Mark Watney",
                Email = "mark.watney@gmail.com",
                Phone = "+63 969856522"
            };
            // Act
            var createdResponse = _controller.Post(testContact) as CreatedAtActionResult;
            var item = createdResponse.Value as ContactDTO;
            // Assert
            Assert.IsType<ContactDTO>(item);
            Assert.Equal("Mark Watney", item.Name);
        }


        [Fact]
        public void Remove_NotExistingIdPassed_ReturnsNotFoundResponse()
        {
            // Arrange
            var notExistingId = 99999;
            // Act
            var badResponse = _controller.Delete(notExistingId);
            // Assert
            Assert.IsType<NotFoundResult>(badResponse);
        }

        [Fact]
        public void Remove_ExistingIdPassed_ReturnsNoContentResult()
        {
            // Arrange
            var existingId = 3;
            // Act
            var noContentResponse = _controller.Delete(existingId);
            // Assert
            Assert.IsType<NoContentResult>(noContentResponse);
        }

        [Fact]
        public void Remove_ExistingIdPassed_RemovesOneItem()
        {
            // Arrange
            var existingId = 3;
            // Act
            var okResponse = _controller.Delete(existingId);
            // Assert
            Assert.Equal(4 , _repository.GetAll().Count());
        }

        /////////////////////////
  
        [Fact]
        public void Update_NotExistingIdPassed_ReturnsNotFoundResponse()
        {
            // Arrange
            ContactCreationDTO testContact = new ContactCreationDTO()
            {
                Name = "Mark Watney",
                Email = "mark.watney@gmail.com",
                Phone = "+63 969856522"
            };
            var notExistingId = 99999;

            // Act
            var badResponse = _controller.Put(testContact, notExistingId);
            // Assert
            Assert.IsType<NotFoundResult>(badResponse);
        }

        [Fact]
        public void Update_ExistingIdPassed_ReturnsNoContentResult()
        {
            // Arrange
            ContactCreationDTO testContact = new ContactCreationDTO()
            {
                Name = "Plato",
                Email = "plato@gmail.com",
                Phone = "+01 504056522"
            };
            var existingId = 1;
            // Act
            var noContentResponse = _controller.Put(testContact, existingId);
            // Assert
            Assert.IsType<NoContentResult>(noContentResponse);
        }

        [Fact]
        public void Update_ValidItemUpdated_ReturnsNoContentResult()
        {
            // Arrange
            ContactCreationDTO testContact = new ContactCreationDTO()
            {
                Name = "Pythagoras",
                Email = "pythagoras@gmail.com",
                Phone = "+10 161803398"
            };
            var existingId = 5;
            // Act
            var noContentResponse = _controller.Put(testContact, existingId);
            // Assert
            Assert.IsType<NoContentResult>(noContentResponse);
            Assert.Equal("Pythagoras", _repository.GetById(existingId).Name);
        }

    }
}
