using Application.Common;
using Application.Common.Mappings;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;

namespace Application.Notifications.Queries.GetNotificationByTradeIdWithPagination
{
    public class GetNotificationsWithPaginationQuery : IRequest<PaginatedList<NotificationDTO>>
    {
        public Guid TradeId { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
    public class GetNotificationsWithPaginationQueryHandler : IRequestHandler<GetNotificationsWithPaginationQuery, PaginatedList<NotificationDTO>>
    {
         private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public GetNotificationsWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<PaginatedList<NotificationDTO>> Handle(GetNotificationsWithPaginationQuery request, CancellationToken cancellationToken)
        {
            return await _context.Notifications
            .Where(request.TradeId ==Guid.Empty? m =>1==1 : x => x.TradeId == request.TradeId)
            .OrderBy(x => x.LastModified)
            .ProjectTo<NotificationDTO>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
        }
     
    }
}