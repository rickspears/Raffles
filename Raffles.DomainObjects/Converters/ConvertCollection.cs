namespace Raffles.DomainObjects.Converters
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using Raffles.DomainObjects.Entities;
    using Raffles.DomainObjects.Models;

    public class ConvertCollection
    {
        public ObservableCollection<ParticipantModel> GetParticipantModelFrom(
            ICollection<Participant> entities) {
            
            ObservableCollection<ParticipantModel> collection = 
                new ObservableCollection<ParticipantModel>();
            foreach (Participant entity in entities) {
                ParticipantModel model = new ParticipantModel(entity);
                collection.Add(model);
            }
            return collection;
        }

        public ObservableCollection<ItemModel> GetItemModelFrom(
            ICollection<Item> entities) {

            ObservableCollection<ItemModel> collection =
            new ObservableCollection<ItemModel>();
            foreach (Item entity in entities) {
                ItemModel model = new ItemModel(entity);
                collection.Add(model);
            }
            return collection;
        }

        public ObservableCollection<RaffleModel> GetRaffleModelFrom(
            ICollection<Raffle> entities) {

            ObservableCollection<RaffleModel> collection =
                new ObservableCollection<RaffleModel>();
            foreach (Raffle entity in entities) {
                RaffleModel model = new RaffleModel(entity);
                collection.Add(model);
            }
            return collection;
        }

        
    }
}
