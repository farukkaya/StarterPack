using System.Collections.Generic;
using Business.Abstract;
using Business.Constans;
using Core.Aspects.AutoFac;
using Core.CrossCuttingConcerns.Logging.SeriLog.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Concrete
{
	[LogAspect(typeof(DatabaseLogger))]
	public class SessionManager : ISessionService
	{
		private readonly ISessionDal _sessionDal;
		public SessionManager(ISessionDal sessionDal) => _sessionDal = sessionDal;

        public List<Session> GetActiveSessions(int userId)
        {
          return _sessionDal.GetActiveSessions(userId);
        }
        #region CRUD
        public IDataResult<List<Session>> GetAll()
        {
            return new SuccessDataResult<List<Session>>(_sessionDal.GetList());
        }
        public IDataResult<Session> GetByToken(string id)
        {
            return new SuccessDataResult<Session>(_sessionDal.Get(p => p.AccessToken == id));
        }
        public IDataResult<Session> Add(Session session)
        {
            return new SuccessDataResult<Session>(_sessionDal.Add(session), Messages.Added);
        }
        public IDataResult<Session> Update(Session session)
        {
            return new SuccessDataResult<Session>(_sessionDal.Update(session), Messages.Updated);
        }
        public IResult Delete(Session session)
        {
            _sessionDal.Delete(session);
            return new SuccessResult(Messages.Deleted);
        } 
        #endregion

       
    }
}

