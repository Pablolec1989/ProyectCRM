using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Mapper
{
    public interface IMapper <TDTO, TCreateUpdateDTO, TEntity> 
        where TDTO : class
        where TCreateUpdateDTO : class
        where TEntity : class
    {
        TDTO ToDTO(TEntity entity);
        TEntity ToEntity(TCreateUpdateDTO createDTO);
        IEnumerable<TDTO> ToDTOList(IEnumerable<TEntity> entities);
    }
}
