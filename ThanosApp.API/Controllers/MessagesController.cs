using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ThanosApp.API.Data;
using ThanosApp.API.Dtos;
using ThanosApp.API.Models;
using ThanosApp.API.Helpers ;

namespace ThanosApp.API.Controllers {
    [Authorize]
    [Route ("api/users/{userid}/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase {
        public IThanosRepository _repo { get; }
        public IMapper _mapper { get; }
        public MessagesController (IThanosRepository repo, IMapper mapper) {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpGet ("{id}", Name = "GetMessage")]
        public async Task<IActionResult> GetMessage (int userId, int id) {
            if (userId != int.Parse (User.FindFirst (ClaimTypes.NameIdentifier).Value))
                return Unauthorized ();

            var messageFromRepo = await _repo.GetMessage (id);
            if (messageFromRepo == null)
                return NotFound ();

            return Ok (messageFromRepo);
        }

[HttpGet]
public async Task<IActionResult> GetMessagesForUser(int userId, MessageParams messageParams){
    if (userId != int.Parse (User.FindFirst (ClaimTypes.NameIdentifier).Value))
                return Unauthorized ();

    var messagesFromRepo = await _repo.GetMessagsForUser(messageParams);

    var messages = _mapper.Map<IEnumerable<MessageToRetunDto>>(messagesFromRepo);

    //Response.Add
    return Ok(messages);



}

        [HttpPost]
        public async Task<IActionResult> CreateMessage (int userId,
            MessageForCreateDto messageForCreateDto) {

            if (userId != int.Parse (User.FindFirst (ClaimTypes.NameIdentifier).Value))
                return Unauthorized ();

            messageForCreateDto.SenderId = userId;
            var recipient = await _repo.GetUser(messageForCreateDto.RecipientId );

            if(recipient == null)
                return BadRequest("Could not find recipient");
            
            var message = _mapper.Map<Message>(messageForCreateDto);
            _repo.Add(message);

            if( await _repo.SaveAll()){
                var messageToReturn = _mapper.Map<MessageToRetunDto>(message);
                return CreatedAtRoute("GetMessage",
                new {userId, id = message.Id}, messageToReturn);
            }

           throw new System.Exception("Creating the message failed at save");
        }
    }
}