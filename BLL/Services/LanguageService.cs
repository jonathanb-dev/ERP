using DAL;
using DL.Services;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class LanguageService : ILanguageService
    {
        private readonly DataContext _context;

        public LanguageService(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> LanguageExists(int id)
        {
            return await _context.Languages.AnyAsync(x => x.Id == id);
        }
    }
}