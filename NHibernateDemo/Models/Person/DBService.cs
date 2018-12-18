using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NHibernateDemo.Models.Person
{
    public class DBService
    {
        private ISession _mSession;
        public void SetSession(ISession session)
        {
            _mSession = session;
        }
        public void Update(Object obj)
        {

            using (var transaction = _mSession.BeginTransaction())
            {
                _mSession.Save(obj);
                transaction.Commit();
            }


        }
    }
}