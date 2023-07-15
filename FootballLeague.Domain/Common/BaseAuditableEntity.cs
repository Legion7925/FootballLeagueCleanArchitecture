using FootballLeague.Domain.Common.Interfaces;

namespace FootballLeague.Domain.Common;

public class BaseAuditableEntity : BaseEntity,IAuditableEntity
{
    public int? CreatedBy { get; set; }
    public DateTime? CreatedDate { get; set; }
    public int? UpdatedBy { get; set; }
    public DateTime? UpdatedDate { get; set; }
}
