namespace Convey.Domain.Model;

public interface IHaveCreator
{
    public DateTime CreateAt { get; }
    public long? CreateBy { get; }
}