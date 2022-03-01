using Application.Common.Mappings;
using Domain.Entities;
using Domain.Enums;

namespace Application.Notifications.Queries.GetNotificationByTradeIdWithPagination
{
    public class NotificationDTO: IMapFrom<Notification>
    {
        public Guid Id { get; set; }
        public Guid TradeId { get; set; }
        public bool EmailSent { get; set; }
        public bool SmsSent { get; set; }
        public TradeStatus TradeStatus{get;set;}
        public Side Side{get;set;}
    }
}