using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Core.DataAccess;
using Entities.Concrete;
using Entities.Dtos;

namespace DataAccess.Abstract
{
	public interface ISessionDal : IEntityRepository<Session>
	{
        List<Session> GetActiveSessions(int userId);
    }
}

