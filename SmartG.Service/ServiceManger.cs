using System;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using SmartG.Contracts;
using SmartG.Entities.Models;
using SmartG.Service.Contracts;
using Microsoft.Extensions.Configuration;

namespace SmartG.Service
{
	public class ServiceManager : IServiceManager
	{

	
		private readonly Lazy<IAuthService> _authenticationService;
		//private readonly Lazy<IEmailService> _emailService;
		public ServiceManager(IRepositoryManager repository, ILoggerManager logger, IMapper mapper, UserManager<User> userManager, IConfiguration configuration, IEmailSender emailSenderService)
		{


			
			_authenticationService = new Lazy<IAuthService>(() => new AuthService(logger, mapper, userManager, configuration, emailSenderService));
			//_emailService = new Lazy<IEmailService>(() => new EmailService(emailConfig,logger));
		}


        public IAuthService AuthenticationService => _authenticationService.Value;
	}
}

