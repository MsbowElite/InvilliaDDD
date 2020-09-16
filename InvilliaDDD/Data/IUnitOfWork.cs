using System.Threading.Tasks;

namespace InvilliaDDD.Core.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
