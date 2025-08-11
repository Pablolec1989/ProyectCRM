using ProyectCRM.Data.Interfaces;
using ProyectCRM.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Data.Repositories
{
    public class ClienteRepository : RepositoryBase<Cliente>, IClienteRepository
    {
        public ClienteRepository(AppDbContext context) : base(context)
        {
        }
        // Aquí puedes agregar métodos específicos para el repositorio de Cliente si es necesario
        // Por ejemplo, si necesitas un método para obtener clientes por algún criterio específico
    }
}
