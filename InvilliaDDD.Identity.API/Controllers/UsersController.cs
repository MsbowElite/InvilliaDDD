using AutoMapper;
using InvilliaDDD.Identity.API.Data.Interfaces;
using InvilliaDDD.Identity.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InvilliaDDD.Identity.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public partial class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IRepositoryWrapper _rw;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public UsersController(IUserService userService, IRepositoryWrapper rw, IMapper mapper, ILogger<UsersController> logger)
        {
            _userService = userService;
            _rw = rw;
            _mapper = mapper;
            _logger = logger;
        }
    }
}
