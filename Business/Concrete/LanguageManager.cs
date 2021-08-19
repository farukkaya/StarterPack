using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constans;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.AutoFac;
using Core.CrossCuttingConcerns.Logging.SeriLog.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    [LogAspect(typeof(DatabaseLogger))] 
    [LogAspect(typeof(FileLogger))]
    public class LanguageManager : ILanguageService
    {
        private readonly ILanguageDal _languageDal;
        public LanguageManager(ILanguageDal languageDal) => _languageDal = languageDal;

       
        [CacheAspect(1)]
        [SecuredOperation("Language.List")]
        [PerformanceAspect(5)]//5 saniyeyi geçerse mail at ve loga yaz
        public IDataResult<List<Language>> GetAll()
        {
            //Thread.Sleep(5000);
            return new SuccessDataResult<List<Language>>(_languageDal.GetList());
        }
       
        

        public IDataResult<Language> GetById(int id)
        {
            return new SuccessDataResult<Language>(_languageDal.Get(p => p.Id == id));
        }
       
        [ValidationAspect(typeof(LanguageValidator),Priority = 1)]
        [CacheRemoveAspect("ILanguageService.Get")]//Bu Key ile kaydedilmiş cahce kaldırır
        public IDataResult<Language> Add(Language language)
        {
            return new SuccessDataResult<Language>(_languageDal.Add(language), Messages.Added);
        }
       
        public IDataResult<Language> Update(Language language)
        {
            return new SuccessDataResult<Language>(_languageDal.Update(language), Messages.Updated);
        }
       
        public IResult Delete(Language language)
        {
            _languageDal.Delete(language);
            return new SuccessResult(Messages.Deleted);
        }
        
        [TransactionAspect]
        public IResult TransactionOperation(Language language)
        {
            _languageDal.Update(language);
            _languageDal.Add(language);
            return new SuccessResult(Messages.Updated);
        }
    }

}
