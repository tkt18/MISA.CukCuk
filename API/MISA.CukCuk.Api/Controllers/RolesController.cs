using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.CukCuk.ApplicationCore.Interfaces;
using MISA.CukCuk.Common.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class RolesController : BaseController<Role>
    {
        private readonly IRoleService _roleService;
        public RolesController(IRoleService roleService) : base(roleService) { }
    }
}
