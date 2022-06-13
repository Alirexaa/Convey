namespace Convey.Domain.Model;

public interface IHaveVersion
{
    public long CurrentVersion { get;   }
    public long OrginalVersion { get;  }
}