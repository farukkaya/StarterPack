using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;

namespace Core.Aspects.AutoFac
{
    public class TransactionAspect : MethodInterception
    {
        public override void Intercept(IInvocation invocation)
        {
            using TransactionScope transaction=new TransactionScope();
            try
            {
                invocation.Proceed();
                transaction.Complete();
            }
            catch (Exception e)
            {
                transaction.Dispose();
                throw;
            }
        }
    }
}
