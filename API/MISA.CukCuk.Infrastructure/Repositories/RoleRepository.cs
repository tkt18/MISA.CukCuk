using MISA.CukCuk.Common.EntityModels;
using MISA.CukCuk.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MISA.CukCuk.Infrastructure.Repositories
{
    public class RoleRepository : DbContext<Role>, IRoleRepository
    {
        public RoleRepository(IDbConnection dbConnection) : base(dbConnection)
        {

        }
    }
}
