using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectCRM.Models.Entities;

namespace ProyectCRM.Models.Data.Interfaces
{
    public interface IAreaRepository : IRepositoryBase<Area>
    {
        Task<bool> AreaExistsAsync(Guid id);
    }
}
