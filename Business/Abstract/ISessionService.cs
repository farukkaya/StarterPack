using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Abstract
{
    public interface ISessionService
    {
        List<Session> GetActiveSessions(int userId);
        #region CRUD
        IDataResult<List<Session>> GetAll();
        IDataResult<Session> GetByToken(string id);

        IDataResult<Session> Add(Session session);
        IDataResult<Session> Update(Session session);
        IResult Delete(Session session);
        #endregion

    }
}
