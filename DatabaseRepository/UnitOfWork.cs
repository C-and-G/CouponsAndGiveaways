using DatabaseRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseRepository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDatabaseFactory databaseFactory;
        private DbContext giveawaysEntitiesContext;

        public UnitOfWork(IDatabaseFactory databaseFactory)
        {
            this.databaseFactory = databaseFactory;
        }

        protected DbContext GiveawaysEntitiesContext
        {
            get { return giveawaysEntitiesContext ?? (giveawaysEntitiesContext = databaseFactory.GetGiveawaysEntitiesContext()); }
        }

        public void Commit()
        {
            try
            {
                GiveawaysEntitiesContext.SaveChanges();
            }
            catch(DbEntityValidationException ex)
            {
                var validationErrors = ex.EntityValidationErrors.SelectMany(p => p.ValidationErrors).Select(e => e.ErrorMessage);
                var exceptionMessage = string.Concat(ex.Message, "; Validation Errors: ", string.Join("; ", validationErrors));
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
