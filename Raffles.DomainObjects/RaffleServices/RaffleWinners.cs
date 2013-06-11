namespace Raffles.DomainObjects.RaffleServices
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Security.Cryptography;
    using Raffles.Common.Comparers;
    using Raffles.Common.DataStructures;
    using Raffles.DomainObjects.Entities;

    public class RaffleWinners
    {
        #region Constructors
        public RaffleWinners(Raffle raffle) {
            Raffle = raffle;
            heap = new PriorityQueue<RaffleParticipant, int>(new ExtractMax());
            random = new RNGCryptoServiceProvider();
            Winners = new ObservableCollection<Winner>();

            CalculateWinners(Raffle);
        }
        #endregion

        #region Fields
        private PriorityQueue<RaffleParticipant, int> heap;
        private RNGCryptoServiceProvider random;
        #endregion

        #region Properties
        public Raffle Raffle { get; private set; }
        public ICollection<Winner> Winners { get; private set; }
        #endregion 

        #region Methods
        private void CalculateWinners(Raffle raffle) {
            foreach (var item in raffle.RaffleItems) {
                HeapInsertRollsFor(raffle.RaffleParticipants);
                GetWinnersFor(item);
            }
        }

        private void HeapInsertRollsFor(ICollection<RaffleParticipant> participants) {
            foreach (var participant in participants) {
                if (participant.TicketCount > 0) {
                    int roll = GetMaxRoll(participant.TicketCount);
                    heap.Insert(participant, roll);
                }
            }
        }

        private int GetMaxRoll(int count) {
            var bytes = new byte[count];
            random.GetNonZeroBytes(bytes);
            return bytes.Max();

        }

        private void GetWinnersFor(RaffleItem item) {
            int i = item.ItemCount - 1;
            while (i > 0 && heap.Count > 0) {
                var winner = heap.ExtractKey();
                Winners.Add(new Winner() {
                    ItemId = item.ItemId,
                    Item = item.Item,
                    ParticipantId = winner.ParticipantId,
                    Participant = winner.Participant,
                    RaffleId = Raffle.RaffleId,
                    Raffle = Raffle,
                    RaffleCounter = Raffle.ExecutionCount,
                    Claimed = false
                });
                --i;
            }            
        }        
        #endregion
    }
}