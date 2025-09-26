using FluentValidation;
using MapsterMapper;
using ProyectCRM.Models.Data.Interfaces;
using ProyectCRM.Models.Entities;
using ProyectCRM.Models.Service.DTOs;
using ProyectCRM.Service.DTOs;
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
        private readonly IMapper _mapper;
        private readonly IMailRepository _repository;
        private readonly IClienteRepository _clienteRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IAsuntoDeContactoRepository _asuntoDeContactoRepository;
        private readonly IValidator<MailRequestDTO> _validator;

        public MailService(IMapper mapper,
            IMailRepository repository,
            IClienteRepository clienteRepository,
            IUsuarioRepository usuarioRepository,
            IAsuntoDeContactoRepository asuntoDeContactoRepository,
            IValidator<MailRequestDTO> validator) : base(mapper, repository, validator)
        {
            _mapper = mapper;
            _repository = repository;
            _clienteRepository = clienteRepository;
            _usuarioRepository = usuarioRepository;
            _asuntoDeContactoRepository = asuntoDeContactoRepository;
            _validator = validator;
        }

        public async Task<MailDetailDTO> GetMailByIdWithRelatedDataAsync(Guid id)
        {
            var mail = await _repository.GetByIdWithRelatedDataAsync(id);
            if (mail == null)
                return null;
            return _mapper.Map<MailDetailDTO>(mail);
        }

        public override async Task<MailDTO> CreateAsync(MailRequestDTO dto)
        {
            await ValidateMailRequest(null, dto);
            return await base.CreateAsync(dto);
        }

        public override async Task<MailDTO> UpdateAsync(Guid id, MailRequestDTO dto)
        {
            await ValidateMailRequest(id, dto);
            return await base.UpdateAsync(id, dto);
        }

        //Metodo aux
        private async Task ValidateMailRequest(Guid? id, MailRequestDTO dto)
        {

            //Validar si existe clienteId
            var clienteExiste = await _clienteRepository.GetByIdAsync(dto.ClienteId);
            if (clienteExiste == null)
                throw new KeyNotFoundException($"El cliente con Id {dto.ClienteId} no existe");

            //Validar usuarioId
            var usuarioExiste = await _usuarioRepository.GetByIdAsync(dto.UsuarioId);
            if (usuarioExiste == null)
                throw new KeyNotFoundException($"El usuario con Id {dto.UsuarioId} no existe");

            //Validar AsuntoDeContactoId
            var asuntoDeContactoExiste = await _asuntoDeContactoRepository.GetByIdAsync(dto.AsuntoDeContactoId);
            if (asuntoDeContactoExiste == null)
                throw new KeyNotFoundException($"El asunto de contacto con Id {dto.AsuntoDeContactoId} no existe");


        }
    }
}
