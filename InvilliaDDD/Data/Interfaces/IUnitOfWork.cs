using System.Threading.Tasks;

namespace InvilliaDDD.Core.Data.Interfaces
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
