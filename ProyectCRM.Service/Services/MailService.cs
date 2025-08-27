using FluentValidation;
using MapsterMapper;
using ProyectCRM.Models.Data.Interfaces;
using ProyectCRM.Models.Entities;
using ProyectCRM.Models.Service.DTOs;
using ProyectCRM.Models.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Models.Service.Services
{
    public class MailService : ServiceBase<MailDTO, MailRequestDTO, Mail>, IMailService
    {
        public MailService(IMapper mapper, 
            IMailRepository repository, 
            IValidator<MailRequestDTO> validator) : base(mapper, repository, validator)
        {
            
        }
    }
}
