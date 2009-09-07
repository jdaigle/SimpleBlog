﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StructureMap;
using NHibernate;

namespace SimpleBlog.Web.ActionFilters
{
    public class RequireTransactionAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var theSession = ObjectFactory.GetInstance<ISession>();
            if (!theSession.Transaction.IsActive)
            {
                theSession.FlushMode = FlushMode.Commit;
                theSession.BeginTransaction();
            }
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            var theSession = ObjectFactory.GetInstance<ISession>();
            if (theSession.Transaction.IsActive)
            {
                try
                {
                    if (filterContext.Exception == null &&
                        filterContext.Controller.ViewData.ModelState.IsValid)
                        theSession.Transaction.Commit();
                    else
                        theSession.Transaction.Rollback();
                }
                finally
                {
                    theSession.Close();
                }
            }
        }
    }
}
