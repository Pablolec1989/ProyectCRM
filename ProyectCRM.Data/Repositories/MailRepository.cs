using Microsoft.EntityFrameworkCore;
using ProyectCRM.Data.Interfaces;
using ProyectCRM.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Data.Repositories
{
    public class MailRepository : RepositoryBase<Mail>, IMailRepository
    {
        private readonly AppDbContext _context;
        public MailRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<Mail> GetMailsQuery()
        {
            return _context.Mails
                .Include(m => m.Cliente).ThenInclude(c => c.Empresa)
                .Include(m => m.Usuario)
                .Include(m => m.AsuntoDeContacto);
        }

        public override async Task<Mail> GetByIdAsync(Guid id)
        {
            return await GetMailsQuery().FirstOrDefaultAsync(m => m.Id == id);
        }

        public override async Task<IEnumerable<Mail>> GetAllAsync()
        {
            return await GetMailsQuery().ToListAsync();
        }
    }
}
