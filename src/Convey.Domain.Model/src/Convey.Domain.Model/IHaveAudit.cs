namespace Convey.Domain.Model;

public interface IHaveAudit
{
    public DateTime LastModified { get; set; }
    public long? LastModifiedBy { get; set; }
}
