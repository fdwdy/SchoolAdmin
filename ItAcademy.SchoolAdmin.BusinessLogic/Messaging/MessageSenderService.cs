using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ItAcademy.SchoolAdmin.BusinessLogic.Models;
using ItAcademy.SchoolAdmin.BusinessLogic.Models.DTOs;
using ItAcademy.SchoolAdmin.DataAccess.Interfaces;
using ItAcademy.SchoolAdmin.DataAccess.Models.DTOs;
using ItAcademy.SchoolAdmin.Infrastructure;

namespace ItAcademy.SchoolAdmin.BusinessLogic.Messaging
{
    public class MessageSenderService : IMessageService
    {
        private readonly MessageManager _msgHandler;
        private readonly IMessageDbService _msgService;
        private readonly IMapper _mapper;

        public MessageSenderService(MessageManager msgHandler, IMessageDbService msgService, IMapper mapper)
        {
            _msgHandler = msgHandler;
            _msgService = msgService;
            _mapper = mapper;
        }

        public Result<Message> SendMessageToEmployee(string message, Employee emp)
        {
            return _msgHandler.ProcessMessage(message, emp);
        }

        public async Task<IEnumerable<MessageWithRecipientName>> GetAllSortedByStatusAndTimeAsync()
        {
            var result = await _msgService.GetAllSortedByStatusAndTimeAsync();
            return _mapper.Map<IEnumerable<MessageDbWithRecipientName>, IEnumerable<MessageWithRecipientName>>(result);
        }

        public async Task<MessageWithRecipientName> GetByIdAsync(string id)
        {
            var result = await _msgService.GetByIdAsync(id);
            return _mapper.Map<MessageDbWithRecipientName, MessageWithRecipientName>(result);
        }
    }
}
