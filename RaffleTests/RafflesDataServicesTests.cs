using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Raffles.Data.Services.Factory;
using Raffles.Data.Services.UnitOfWork;

namespace RaffleTests
{
    [TestClass]
    public class RafflesDataServicesTests
    {
        RepositoryFactories factory;
        IRepositoryProvider provider;
        IUnitOfWork uow;

        [TestInitialize]
        public void Initialize() {
            factory = new RepositoryFactories();
            provider = new RepositoryProvider(factory);
            uow = new UnitOfWork(provider);
        }

        [TestMethod]
        public void UoW_IRepository_CanGetById() {
            var item = uow.Items.GetBy(1);
            Assert.IsTrue(item.ItemId == 1);
        }

        [TestMethod]
        public void UoW_IRepository_CanGetByExpression() {
            var item = uow.Participants.GetBy(i => i.ParticipantId == 1).FirstOrDefault();
            Assert.IsTrue(item.ParticipantId == 1);
        }

        [TestMethod]
        public void UoW_IRepository_CanAddEntity() {

        }

        [TestMethod]
        public void UoW_IRepository_CanRemoveEntity() {

        }

        [TestMethod]
        public void UoW_IRepository_CanRemoveId() {

        }

        [TestMethod]
        public void UoW_IRepository_CanUpdateEntity() {

        }

        [TestMethod]
        public void UoW_IRepository_CanGetAll() {

        }

        [TestMethod]
        public void UoW_CanCommit() {

        }
    }
}
