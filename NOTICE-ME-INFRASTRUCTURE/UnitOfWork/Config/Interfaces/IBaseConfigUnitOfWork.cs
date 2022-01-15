using System.Threading.Tasks;

namespace NOTICE_ME_INFRASTRUCTURE.UnitOfWork.Config.Interfaces
{
    public interface IBaseConfigUnitOfWork
    {
        Task CommitAsync();
    }
}
