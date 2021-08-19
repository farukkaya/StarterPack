using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ILanguageService
    {
        IDataResult<List<Language>> GetAll();
        IDataResult<Language> GetById(int id);
        IDataResult<Language> Add(Language language);
        IDataResult<Language> Update(Language language);
        IResult Delete(Language language);
        IResult TransactionOperation(Language language);
    }
}
