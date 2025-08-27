using ProyectCRM.Models.Entities;
using ProyectCRM.Models.Service.DTOs;
using ProyectCRM.Models.Service.Interfaces;

namespace ProyectCRM.Models.Controllers
{
    public class MailsController : CustomControllerBase<MailDTO, MailRequestDTO, Mail>
    {
        public MailsController(IMailService service) : base(service)
        {
        }
    }
}
