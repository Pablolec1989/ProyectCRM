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
    public class VisitaUsuarioRepository : IVisitaUsuarioRepository
    {
        private readonly AppDbContext _context;

        public VisitaUsuarioRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<VisitasUsuarios> CreateAsync(VisitasUsuarios entity)
        {
            try
            {
                await _context.VisitasUsuarios.AddAsync(entity);
                await _context.SaveChangesAsync();
                return entity;

            }
            catch (Exception ex)
            {
                var inner = ex.InnerException?.Message ?? ex.Message;
                throw new Exception($"Error al crear la relación Visita-Usuario: {inner}", ex);
            }
        }
    }
}
