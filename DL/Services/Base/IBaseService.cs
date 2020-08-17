using System.Threading.Tasks;

namespace DL.Services.Base
{
    public interface IBaseService<T>
    {
        Task Validate(T entity);
    }
}