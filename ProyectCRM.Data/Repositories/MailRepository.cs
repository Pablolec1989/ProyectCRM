using Microsoft.EntityFrameworkCore;
using ProyectCRM.Models.Data.Interfaces;
using ProyectCRM.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Models.Data.Repositories
{
    public class MailRepository : RepositoryBase<Mail>, IMailRepository
    {
        private readonly AppDbContext _context;
        public MailRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<Mail> Mails()
        {
            return _context.Mails
                .Include(m => m.Usuario).ThenInclude(u => u.Area)
                .Include(m => m.Cliente).ThenInclude(c => c.Empresa)
                .Include(m => m.AsuntoDeContacto);
        }

        public async Task<Mail> GetByIdWithRelatedDataAsync(Guid id)
        {
            return await Mails()
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public override async Task<IEnumerable<Mail>> GetAllAsync()
        {
            return await Mails().ToListAsync();
        }
    }
}
