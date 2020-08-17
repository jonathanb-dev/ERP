using System.Threading.Tasks;

namespace DL.Services
{
    public interface ILanguageService
    {
        Task<bool> LanguageExists(int id);
    }
}