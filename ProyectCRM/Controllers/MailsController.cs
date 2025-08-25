using ProyectCRM.Models.Entities;
using ProyectCRM.Service.DTOs;
using ProyectCRM.Service.Interfaces;

namespace ProyectCRM.Controllers
{
    public class MailsController : CustomControllerBase<MailDTO, MailRequestDTO, Mail>
    {
        public MailsController(IMailService service) : base(service)
        {
        }
    }
}
