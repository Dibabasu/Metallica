using Domain.Common;
using Domain.Enums;

namespace Domain.Entities
{
    public class Notification : AuditableEntity
    {
     
        public Guid Id { get; set; }
        public Guid TradeId { get; set; }
        public bool EmailSent { get; set; }
        public bool SmsSent { get; set; }
        public TradeStatus TradeStatus{get;set;}
        public Side Side{get;set;}
    }
}