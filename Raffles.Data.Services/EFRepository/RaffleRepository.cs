using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raffles.DomainObjects.Entities;

namespace Raffles.Data.Services.EFRepository
{
    public class RaffleRepository : Repository<Raffle>, IRaffleRepository
    {
        public RaffleRepository(DbContext context) :base(context) {

        }

        IQueryable<RaffleItem> IRaffleRepository.GetRaffleItems() {
            throw new NotImplementedException();
        }

        IQueryable<RaffleParticipant> IRaffleRepository.GetRaffleParticipants() {
            throw new NotImplementedException();
        }

        IQueryable<RaffleItem> IRepository<RaffleItem>.GetAll() {
            throw new NotImplementedException();
        }

        IQueryable<RaffleItem> IRepository<RaffleItem>.GetBy(System.Linq.Expressions.Expression<Func<RaffleItem, bool>> predicate) {
            throw new NotImplementedException();
        }

        RaffleItem IRepository<RaffleItem>.GetBy(int id) {
            throw new NotImplementedException();
        }

        void IRepository<RaffleItem>.Add(RaffleItem entity) {
            throw new NotImplementedException();
        }

        void IRepository<RaffleItem>.Remove(RaffleItem entity) {
            throw new NotImplementedException();
        }

        void IRepository<RaffleItem>.Remove(int id) {
            throw new NotImplementedException();
        }

        void IRepository<RaffleItem>.Update(RaffleItem entity) {
            throw new NotImplementedException();
        }

        IQueryable<RaffleParticipant> IRepository<RaffleParticipant>.GetAll() {
            throw new NotImplementedException();
        }

        IQueryable<RaffleParticipant> IRepository<RaffleParticipant>.GetBy(System.Linq.Expressions.Expression<Func<RaffleParticipant, bool>> predicate) {
            throw new NotImplementedException();
        }

        RaffleParticipant IRepository<RaffleParticipant>.GetBy(int id) {
            throw new NotImplementedException();
        }

        void IRepository<RaffleParticipant>.Add(RaffleParticipant entity) {
            throw new NotImplementedException();
        }

        void IRepository<RaffleParticipant>.Remove(RaffleParticipant entity) {
            throw new NotImplementedException();
        }

        void IRepository<RaffleParticipant>.Remove(int id) {
            throw new NotImplementedException();
        }

        void IRepository<RaffleParticipant>.Update(RaffleParticipant entity) {
            throw new NotImplementedException();
        }
    }
}
