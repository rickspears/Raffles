using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raffles.DomainObjects.Models;

namespace Raffles.DomainObjects.Logic
{
    public class CalculateWinner
    {
        public RaffleModel Raffle { get; private set; }

        public CalculateWinner(RaffleModel raffle) {

        }


        //When play is pressed
            // For each raffle item
                // while item has stock && participant list is not empty
                    // For Each participant 
                        // get highest roll for participant
                        // roll current number of entries
                    // return highest roll


                // winning participant is added to winners, along with the item
                    //participant entry is reduced
                    //item stock is reduced
                // winning participant is removed from the list of participants for the item
                // rolling will continue 

    }
}
