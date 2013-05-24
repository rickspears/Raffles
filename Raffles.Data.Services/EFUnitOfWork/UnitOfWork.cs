using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raffles.Data.Services.EFUnitOfWork
{
    public class UnitOfWork
    {
        public UnitOfWork() {
            InitializeDbContext();
        }

        private AppContext Context { get; set; }

        public void Commit() {
            Context.SaveChanges();
        }

        protected void InitializeDbContext() {
            Context = new AppContext();

            Context.Configuration.ProxyCreationEnabled = false;
            Context.Configuration.LazyLoadingEnabled = false;
            Context.Configuration.ValidateOnSaveEnabled = false;
        }

    }
}
