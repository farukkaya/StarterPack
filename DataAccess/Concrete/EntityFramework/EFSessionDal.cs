using System.Collections.Generic;
using System.Linq;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Entities.Dtos;

namespace DataAccess.Concrete.EntityFramework
{
	public class EfSessionDal : EfEntityRepositoryBase<Session,SeyirContext>,ISessionDal
	{
        public List<Session> GetActiveSessions(int userId)
        {
            using var context = new SeyirContext();
            var result = from session in context.Sessions
                where session.UserId == userId && session.IsActive
                select new Session();

            return result.ToList();
        }
    }
}

