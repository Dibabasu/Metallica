using Application.Common;
using MediatR;

namespace Application.Notifications.Commands.UpdateNotification
{
    public class UpdateNotificationCommand :IRequest
    {
        public Guid Id { get; set; }

        public bool EmailSent { get; set; }

        public bool SmsSent { get; set; }
    }
    public class UpdateNotificationCommandHandler : IRequestHandler<UpdateNotificationCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateNotificationCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateNotificationCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Notifications
                .FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null)
            {
                Exception exception=new Exception();
                throw exception;
            }

            entity.EmailSent = request.EmailSent;
            entity.SmsSent = request.SmsSent;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}