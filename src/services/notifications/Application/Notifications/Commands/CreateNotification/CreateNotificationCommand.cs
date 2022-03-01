using Application.Common;
using Domain.Entities;
using Domain.Enums;
using MediatR;

namespace Application.Notifications.Commands.CreateNotification
{
    public class CreateNotificationCommand: IRequest<Guid>
    {
        public Guid TradeId { get; set; }
        public TradeStatus TradeStatus{get;set;}
        public Side Side{get;set;}
    }
    public class CreateNotificationCommandHandler : IRequestHandler<CreateNotificationCommand, Guid>
    {
        private readonly IApplicationDbContext _context;
        public CreateNotificationCommandHandler(IApplicationDbContext context)
        {
            _context=context;
        }
        public async Task<Guid> Handle(CreateNotificationCommand request, CancellationToken cancellationToken)
        {
           var entity=new Notification{
               TradeId=request.TradeId,
               EmailSent=false,
               SmsSent=false,
               TradeStatus=request.TradeStatus,
               Side=request.Side

           };
           _context.Notifications.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
        }
    }

}