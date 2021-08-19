using DataAccess.Abstract;
using Business.Abstract;
using Business.Constans;
using System.Collections.Generic;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Concrete
{
	//[LogAspect(typeof(DatabaseLogger))]
	//[FluentValidationAspect(typeof(UserValidatior))]
	public class UserManager : IUserService
	{
		private readonly IUserDal _userDal;
		public UserManager(IUserDal userDal) => _userDal = userDal;



        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }

        public User GetByMail(string email)
        {
            return _userDal.Get(p => p.Email == email);
        }


        //[CacheAspect(typeof(MemoryCacheManager))]
        //[SecuredOperation(Roles ='' )]
        //[CacheRemoveAspect(typeof(MemoryCacheManager))]
        #region CRUD
        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetList());
        }
        public IDataResult<User> GetById(int id)
        {
            return new SuccessDataResult<User>(_userDal.Get(p => p.Id == id));
        }
        public IDataResult<User> Add(User user)
        {
            return new SuccessDataResult<User>(_userDal.Add(user), Messages.Added);
        }
        public IDataResult<User> Update(User user)
        {
            return new SuccessDataResult<User>(_userDal.Update(user), Messages.Updated);
        }
        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.Deleted);
        }

     
        #endregion
    }
}

