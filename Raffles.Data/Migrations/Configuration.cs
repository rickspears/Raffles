namespace Raffles.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Raffles.DomainObjects.Entities;

    internal sealed class Configuration : DbMigrationsConfiguration<Raffles.Data.AppContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Raffles.Data.AppContext context) {
            #region Raffles
            Raffle raffleA = new Raffle() {
                Name = "RaffleA",
                Description = "The first test.",
                Location = new ContactDetails() {
                    Address1 = "12345 abcdef street",
                    Address2 = "678",
                    City = "Roseville",
                    State = "Ca",
                    Zip = 12345,
                    Email = "ohnoes@noes.com",
                    Phone = "123456789",
                    CanText = false
                }
                //RaffleItems = new List<Item>(), 
                //RaffleParticipants = new List<Participant>()
                //Results = new List<Result>()              
            };

            Raffle raffleB = new Raffle() {
                Name = "RaffleB",
                Description = "The second test.",
                Location = new ContactDetails() {
                    Address1 = "67890 ghijklm street",
                    Address2 = "123",
                    City = "SomewhereElse",
                    State = "Ca",
                    Zip = 12345,
                    Email = "yessir@noes.com",
                    Phone = "987654332",
                    CanText = false
                },
                //RaffleItems = new List<Item>(),
                //RaffleParticipants = new List<Participant>()
                //Results = new List<Result>()
            };
            Raffle raffleC = new Raffle() {
                Name = "RaffleC",
                Description = "The third test.",
                Location = new ContactDetails() {
                    Address1 = "456321987 zxyw road",
                    Address2 = "652",
                    City = "Nowhere",
                    State = "Ac",
                    Zip = 12345,
                    Email = "fghj@noes.com",
                    Phone = "111222333",
                    CanText = false
                },
                //RaffleItems = new List<Item>(),
                //RaffleParticipants = new List<Participant>()
                //Results = new List<Result>()
            };
            #endregion

            #region Items
            //Item itemA = new Item() { Name = "FuzzyToadSticks", Description = "Fuzzy.Toad.Sticks.", Sku = "RIBBIT", ItemParticipants = new List<Participant>(), ItemRaffles = new List<Raffle>() };
            //Item itemB = new Item() { Name = "Stones", Description = "Break Bones.", Sku = "Ouch", ItemParticipants = new List<Participant>(), ItemRaffles = new List<Raffle>() };
            //Item itemC = new Item() { Name = "Super Tired", Description = "Sleep is for the weak.", Sku = "zzz", ItemParticipants = new List<Participant>(), ItemRaffles = new List<Raffle>() };
            //Item itemD = new Item() { Name = "Awake", Description = "I.Am.A.Wake.", Sku = "aaa", ItemParticipants = new List<Participant>(), ItemRaffles = new List<Raffle>() };

            Item itemA = new Item() { Name = "FuzzyToadSticks", Description = "Fuzzy.Toad.Sticks.", Sku = "RIBBIT" };
            Item itemB = new Item() { Name = "Stones", Description = "Break Bones.", Sku = "Ouch" };
            Item itemC = new Item() { Name = "Super Tired", Description = "Sleep is for the weak." };
            Item itemD = new Item() { Name = "Awake", Description = "I.Am.A.Wake.", Sku = "aaa" };
            #endregion

            #region Participants
            Participant pA = new Participant() {
                Name = "Dirk Dur",
                Contact = new ContactDetails() {
                    Address1 = "yosho",
                    Address2 = "iza",
                    City = "somewhere",
                    State = "Dtr",
                    Zip = 57812,
                    Email = "gijoe@loses.com",
                    Phone = "456789456",
                    CanText = true
                }
            };
            Participant pB = new Participant() {
                Name = "fur dur",
                Contact = new ContactDetails() {
                    Address1 = "soyo",
                    Address2 = "sleep",
                    City = "somewhere",
                    State = "wer",
                    Zip = 12314,
                    Email = "cobra.loses@this.time.com",
                    Phone = "45443",
                    CanText = false
                }
            };
            Participant pC = new Participant() {
                Name = "farfignugan nuganfarfig",
                Contact = new ContactDetails() {
                    Address1 = "no",
                    Address2 = "yes",
                    City = "rainbow",
                    State = "Ca",
                    Zip = 12345,
                    Email = "triple@thepower.com",
                    Phone = "098765432",
                    CanText = true
                }
            };
            Participant pD = new Participant() {
                Name = "totally unique individual",
                Contact = new ContactDetails() {
                    Address1 = "not",
                    Address2 = "sure",
                    City = "wheresome",
                    State = "PO",
                    Zip = 95153,
                    Email = "goto@schweep.com",
                    Phone = "852456753",
                    CanText = true
                }
            };
            #endregion

            #region Add Raffle Item and Participant Objects
            context.Items.Add(itemA);
            context.Items.Add(itemB);
            context.Items.Add(itemC);
            context.Items.Add(itemD);

            context.Participants.Add(pA);
            context.Participants.Add(pB);
            context.Participants.Add(pC);
            context.Participants.Add(pD);

            context.Raffles.Add(raffleA);
            context.Raffles.Add(raffleB);
            context.Raffles.Add(raffleC);                      

            context.SaveChanges();
            #endregion

            #region Raffle Items
            RaffleItem R1I1 = new RaffleItem() { 
                ItemId = 1, Item = context.Items.First(i => i.ItemId == 1), 
                RaffleId = 1, Raffle = context.Raffles.FirstOrDefault(r => r.RaffleId == 1), 
                ItemCount = 11 
            };

            RaffleItem R1I2 = new RaffleItem() {
                ItemId = 2, Item = context.Items.First(i => i.ItemId == 2),
                RaffleId = 1, Raffle = context.Raffles.FirstOrDefault(r => r.RaffleId == 1),
                ItemCount = 55
            };

            RaffleItem R1I4 = new RaffleItem() {
                ItemId = 4, //Item = context.Items.First(i => i.ItemId == 4),
                RaffleId = 1, //Raffle = context.Raffles.FirstOrDefault(r => r.RaffleId == 1),
                ItemCount = 13
            };

            RaffleItem R2I1 = new RaffleItem() {
                ItemId = 1,
                Item = context.Items.First(i => i.ItemId == 1),
                RaffleId = 2,
                Raffle = context.Raffles.FirstOrDefault(r => r.RaffleId == 2),
                ItemCount = 1
            };

            RaffleItem R2I3 = new RaffleItem() {
                ItemId = 3,
                Item = context.Items.First(i => i.ItemId == 3),
                RaffleId = 2,
                Raffle = context.Raffles.FirstOrDefault(r => r.RaffleId == 2),
                ItemCount = 3
            };

            RaffleItem R3I3 = new RaffleItem() {
                ItemId = 3,
                Item = context.Items.First(i => i.ItemId == 3),
                RaffleId = 3,
                Raffle = context.Raffles.FirstOrDefault(r => r.RaffleId == 3),
                ItemCount = 2
            };

            RaffleItem R3I4 = new RaffleItem() {
                ItemId = 4,
                Item = context.Items.First(i => i.ItemId == 4),
                RaffleId = 3,
                Raffle = context.Raffles.FirstOrDefault(r => r.RaffleId == 3),
                ItemCount = 2
            };

            #endregion

            #region Raffle Participants
            RaffleParticipant R1P1 = new RaffleParticipant() {
                ParticipantId = 1,
                Participant = context.Participants.First(i => i.ParticipantId == 1),
                RaffleId = 1,
                Raffle = context.Raffles.FirstOrDefault(r => r.RaffleId == 1),
                TicketCount = 11
            };

            RaffleParticipant R1P2 = new RaffleParticipant() {
                ParticipantId = 2,
                Participant = context.Participants.First(i => i.ParticipantId == 2),
                RaffleId = 1,
                Raffle = context.Raffles.FirstOrDefault(r => r.RaffleId == 1),
                TicketCount = 1
            };

            RaffleParticipant R1P3 = new RaffleParticipant() {
                ParticipantId = 3,
                Participant = context.Participants.First(i => i.ParticipantId == 3),
                RaffleId = 1,
                Raffle = context.Raffles.FirstOrDefault(r => r.RaffleId == 1),
                TicketCount = 3
            };

            RaffleParticipant R2P1 = new RaffleParticipant() {
                ParticipantId = 1,
                Participant = context.Participants.First(i => i.ParticipantId == 1),
                RaffleId = 2,
                Raffle = context.Raffles.FirstOrDefault(r => r.RaffleId == 2),
                TicketCount = 123
            };

            RaffleParticipant R2P3 = new RaffleParticipant() {
                ParticipantId = 3,
                Participant = context.Participants.First(i => i.ParticipantId == 3),
                RaffleId = 2,
                Raffle = context.Raffles.FirstOrDefault(r => r.RaffleId == 2),
                TicketCount = 4
            };

            RaffleParticipant R2P4 = new RaffleParticipant() {
                ParticipantId = 4,
                Participant = context.Participants.First(i => i.ParticipantId == 4),
                RaffleId = 2,
                Raffle = context.Raffles.FirstOrDefault(r => r.RaffleId == 2),
                TicketCount = 6
            };

            RaffleParticipant R3P1 = new RaffleParticipant() {
                ParticipantId = 1,
                Participant = context.Participants.First(i => i.ParticipantId == 1),
                RaffleId = 3,
                Raffle = context.Raffles.FirstOrDefault(r => r.RaffleId == 3),
                TicketCount = 1
            };

            RaffleParticipant R3P2 = new RaffleParticipant() {
                ParticipantId = 2,
                Participant = context.Participants.First(i => i.ParticipantId == 2),
                RaffleId = 3,
                Raffle = context.Raffles.FirstOrDefault(r => r.RaffleId == 3),
                TicketCount = 2
            };

            RaffleParticipant R3P3 = new RaffleParticipant() {
                ParticipantId = 3,
                Participant = context.Participants.First(i => i.ParticipantId == 3),
                RaffleId = 3,
                Raffle = context.Raffles.FirstOrDefault(r => r.RaffleId == 3),
                TicketCount = 3
            };

            RaffleParticipant R3P4 = new RaffleParticipant() {
                ParticipantId = 4,
                Participant = context.Participants.First(i => i.ParticipantId == 4),
                RaffleId = 3,
                Raffle = context.Raffles.FirstOrDefault(r => r.RaffleId == 3),
                TicketCount = 4
            };

            #endregion

            #region Add Raffle Items and Raffle Participants
            context.RaffleItems.Add(R1I1);
            context.RaffleItems.Add(R1I2);
            context.RaffleItems.Add(R1I4);

            context.RaffleItems.Add(R2I1);
            context.RaffleItems.Add(R2I3);

            context.RaffleItems.Add(R3I3);
            context.RaffleItems.Add(R3I4);

            context.RaffleParticipants.Add(R1P1);
            context.RaffleParticipants.Add(R1P2);
            context.RaffleParticipants.Add(R1P3);

            context.RaffleParticipants.Add(R2P1);
            context.RaffleParticipants.Add(R2P3);
            context.RaffleParticipants.Add(R2P4);

            context.RaffleParticipants.Add(R3P1);
            context.RaffleParticipants.Add(R3P2);
            context.RaffleParticipants.Add(R3P3);
            context.RaffleParticipants.Add(R3P4);
            context.SaveChanges();
            #endregion

            #region Winners
            Winner wA = new Winner { RaffleId = 1, ItemId = 4, ParticipantId = 1, Claimed = true, RaffleCounter=1 };
            Winner wAa = new Winner { RaffleId = 1, ItemId = 1, ParticipantId = 1, Claimed = true, RaffleCounter=2 };
            Winner wB = new Winner { RaffleId = 1, ItemId = 2, ParticipantId = 3, Claimed = true, RaffleCounter=1 };
            Winner wC = new Winner { RaffleId = 2, ItemId = 3, ParticipantId = 4, Claimed = true, RaffleCounter=1 };
            Winner wD = new Winner { RaffleId = 2, ItemId = 1, ParticipantId = 3, Claimed = true, RaffleCounter=1 };
            Winner wE = new Winner { RaffleId = 3, ItemId = 3, ParticipantId = 4, Claimed = true, RaffleCounter=1 };
            Winner wF = new Winner { RaffleId = 3, ItemId = 4, ParticipantId = 3, Claimed = true, RaffleCounter=1 };
            Winner wG = new Winner { RaffleId = 3, ItemId = 4, ParticipantId = 3, Claimed = true, RaffleCounter=2 };
            Winner wH = new Winner { RaffleId = 3, ItemId = 3, ParticipantId = 4, Claimed = true, RaffleCounter=2 };
            #endregion

            #region Results
            //RaffleResult rA = new RaffleResult { Name = "Raffle 1 Result 1", RaffleId = 1, Winners = new List<Winner>() { wA, wAa, wB } };
            //RaffleResult rB = new RaffleResult { Name = "Raffle 1 Result 2", RaffleId = 1, Winners = new List<Winner>() { wC, wD } };
            //RaffleResult rC = new RaffleResult { Name = "Raffle 2 Result 1", RaffleId = 2, Winners = new List<Winner>() { wE, wF, wG, wH } };
            //RaffleResult rD = new RaffleResult { Name = "Raffle 2 Result 2", RaffleId = 2, Winners = new List<Winner>() { wE, wF, wG, wH } };
            //RaffleResult rE = new RaffleResult { Name = "Raffle 3 Result 1", RaffleId = 3, Winners = new List<Winner>() { wE, wF, wG, wH } };
            //RaffleResult rF = new RaffleResult { Name = "Raffle 3 Result 2", RaffleId = 3, Winners = new List<Winner>() { wE, wF, wG, wH } };
            #endregion

            #region Add Winners and Results
            //context.RaffleResults.Add(rA);
            //context.RaffleResults.Add(rB);
            //context.RaffleResults.Add(rC);

            context.Winners.Add(wA);
            context.Winners.Add(wAa);
            context.Winners.Add(wB);
            context.Winners.Add(wC);
            context.Winners.Add(wD);
            context.Winners.Add(wE);
            context.Winners.Add(wF);
            context.Winners.Add(wG);
            context.Winners.Add(wH);
            #endregion

            #region Add Relationships
            //context.Entry(raffleA).Entity.RaffleItems.Add(context.Items.First(i=>i.Name==itemA.Name));
            //context.Entry(raffleA).Entity.RaffleItems.Add(context.Items.First(i => i.Name == itemB.Name));
            //context.Entry(raffleA).Entity.RaffleParticipants.Add(context.Participants.First(i => i.Name == pA.Name));
            //context.Entry(raffleA).Entity.RaffleParticipants.Add(context.Participants.First(i => i.Name == pD.Name));
            //context.Entry(raffleB).Entity.RaffleItems.Add(context.Items.First(i => i.Name == itemD.Name));
            //context.Entry(raffleB).Entity.RaffleItems.Add(context.Items.First(i => i.Name == itemA.Name));
            //context.Entry(raffleB).Entity.RaffleParticipants.Add(context.Participants.First(i => i.Name == pC.Name));
            //context.Entry(raffleB).Entity.RaffleParticipants.Add(context.Participants.First(i => i.Name == pB.Name));
            //context.Entry(raffleC).Entity.RaffleItems.Add(context.Items.First(i => i.Name == itemB.Name));
            //context.Entry(raffleC).Entity.RaffleItems.Add(context.Items.First(i => i.Name == itemC.Name));
            //context.Entry(raffleC).Entity.RaffleItems.Add(context.Items.First(i => i.Name == itemD.Name));
            //context.Entry(raffleC).Entity.RaffleItems.Add(context.Items.First(i => i.Name == itemA.Name));
            //context.Entry(raffleC).Entity.RaffleParticipants.Add(context.Participants.First(i => i.Name == pA.Name));
            //context.Entry(raffleC).Entity.RaffleParticipants.Add(context.Participants.First(i => i.Name == pD.Name));             
            //context.Entry(raffleC).Entity.RaffleParticipants.Add(context.Participants.First(i => i.Name == pC.Name));
            //context.Entry(raffleC).Entity.RaffleParticipants.Add(context.Participants.First(i => i.Name == pB.Name));

            //context.SaveChanges();

            //context.Entry(itemA).Entity.ItemParticipants.Add(context.Participants.First(i => i.Name == pA.Name));
            //context.Entry(itemB).Entity.ItemParticipants.Add(context.Participants.First(i => i.Name == pD.Name));
            //context.Entry(itemC).Entity.ItemParticipants.Add(context.Participants.First(i => i.Name == pC.Name));
            //context.Entry(itemD).Entity.ItemParticipants.Add(context.Participants.First(i => i.Name == pB.Name));
            //context.Entry(itemA).Entity.ItemRaffles.Add(context.Raffles.First(i => i.Name == raffleA.Name));
            //context.Entry(itemB).Entity.ItemRaffles.Add(context.Raffles.First(i => i.Name == raffleB.Name));
            //context.Entry(itemC).Entity.ItemRaffles.Add(context.Raffles.First(i => i.Name == raffleC.Name));
            //context.Entry(itemD).Entity.ItemRaffles.Add(context.Raffles.First(i => i.Name == raffleA.Name));
            //context.Entry(pA).Entity.ParticipantItems.Add(context.Items.First(i => i.Name == itemA.Name));
            //context.Entry(pB).Entity.ParticipantItems.Add(context.Items.First(i => i.Name == itemB.Name));
            //context.Entry(pC).Entity.ParticipantItems.Add(context.Items.First(i => i.Name == itemC.Name));
            //context.Entry(pD).Entity.ParticipantItems.Add(context.Items.First(i => i.Name == itemD.Name));
            //context.Entry(pA).Entity.ParticipantRaffles.Add(context.Raffles.First(i => i.Name == raffleA.Name));
            //context.Entry(pB).Entity.ParticipantRaffles.Add(context.Raffles.First(i => i.Name == raffleB.Name));
            //context.Entry(pC).Entity.ParticipantRaffles.Add(context.Raffles.First(i => i.Name == raffleB.Name));
            //context.Entry(pD).Entity.ParticipantRaffles.Add(context.Raffles.First(i => i.Name == raffleC.Name));

            //context.SaveChanges();
            #endregion
        }
    }
}
