namespace Application.Notifications.Queries.GetNotificationStatusByTradeIdWithPagination
{
    public class NotificationStatusDTO
    {
        public Guid Id { get; set; }
        public Guid TradeId { get; set; }
        public bool EmailSent { get; set; }
        public bool SmsSent { get; set; }
    }
}