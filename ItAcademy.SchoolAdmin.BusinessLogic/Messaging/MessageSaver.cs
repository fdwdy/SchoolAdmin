using AutoMapper;
using ItAcademy.SchoolAdmin.BusinessLogic.Models;
using ItAcademy.SchoolAdmin.DataAccess.Interfaces;
using ItAcademy.SchoolAdmin.DataAccess.Models;
using ItAcademy.SchoolAdmin.Infrastructure;

namespace ItAcademy.SchoolAdmin.BusinessLogic.Messaging
{
    public class MessageSaver : IMessageHandler
    {
        private readonly IMessageDbService _msgService;
        private readonly IMapper _mapper;

        public MessageSaver(IMessageDbService msgService, IMapper mapper)
        {
            _mapper = mapper;
            _msgService = msgService;
        }

        public Result<Message> Process(Message msg, Employee emp)
        {
            var result = _msgService.Save(_mapper.Map<Message, MessageDb>(msg)).Data;
            return Result<Message>.Ok(_mapper.Map<MessageDb, Message>(result));
        }
    }
}
