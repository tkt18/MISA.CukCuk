using MISA.CukCuk.ApplicationCore.Interfaces;
using MISA.CukCuk.Common.EntityModels;
using MISA.CukCuk.Infrastructure.Interfaces;

namespace MISA.CukCuk.ApplicationCore.Services
{
    public class RoleService:BaseService<Role>, IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        public RoleService(IRoleRepository roleRepository) : base(roleRepository)
        {
            _roleRepository = roleRepository;
        }
    }
}
