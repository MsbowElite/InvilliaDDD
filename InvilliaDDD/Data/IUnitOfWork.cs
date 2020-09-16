using System.Threading.Tasks;

namespace InvilliaDDD.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
