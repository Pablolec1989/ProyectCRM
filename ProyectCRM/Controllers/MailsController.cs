using Microsoft.AspNetCore.Mvc;
using ProyectCRM.Models.Entities;
using ProyectCRM.Models.Service.DTOs;
using ProyectCRM.Models.Service.Interfaces;

namespace ProyectCRM.Models.Controllers
{
    public class MailsController : CustomControllerBase<MailDTO, MailRequestDTO, Mail>
    {
        private readonly IMailService _service;
        public MailsController(IMailService service) : base(service)
        {
            _service = service;
        }


        [HttpGet("{id}/with-related-data")]
        public async Task<IActionResult> GetByIdWithRelatedDataAsync(Guid id)
        {
            var mailDTO = await _service.GetMailByIdWithRelatedDataAsync(id);
            if (mailDTO == null)
            {
                return NotFound();
            }
            return Ok(mailDTO);
        }
    }
}
