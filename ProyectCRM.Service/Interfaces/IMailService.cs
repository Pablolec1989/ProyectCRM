using ProyectCRM.Models.Entities;
using ProyectCRM.Models.Service;
using ProyectCRM.Models.Service.DTOs;
using ProyectCRM.Service.DTOs;

namespace ProyectCRM.Models.Service.Interfaces
{
    public interface IMailService : IServiceBase<MailDTO, MailRequestDTO, Mail>
    {
        //Metodo para devolver un MailDetailDTO por id
        Task<MailDetailDTO> GetMailByIdWithRelatedDataAsync(Guid id);

    }

}
