using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Raffles.Common.Comparers;
using Raffles.Common.DataStructures;
using Raffles.DomainObjects.Entities;

namespace RaffleTests
{
    [TestClass]
    public class RafflesCommonTests
    {
        [TestMethod]
        public void PriorityQueue_ExtractMax_InsertHighestBubblesToRoot() {
            #region Arrange
            Participant participantHighest = new Participant() { Name = "Highest", ParticipantId = 1 };
            Participant participantMiddle = new Participant() { Name = "Middle", ParticipantId = 2 };
            Participant participantLower = new Participant() { Name = "Lower", ParticipantId = 3 };
            Participant participantLowest = new Participant() { Name = "Lowest", ParticipantId = 4 };
            int highestRoll = 100;
            int middleRoll = 50;
            int lowerRoll = 10;
            int lowestRoll = 1;

            PriorityQueue<Participant, int> WinnersMiddleLowestHighest = new PriorityQueue<Participant, int>(new ExtractMax());
            WinnersMiddleLowestHighest.Insert(participantMiddle, middleRoll);
            WinnersMiddleLowestHighest.Insert(participantLower, lowerRoll);
            WinnersMiddleLowestHighest.Insert(participantHighest, highestRoll);
            WinnersMiddleLowestHighest.Insert(participantLowest, lowestRoll);
            #endregion

            #region Act
            var highestWinner = WinnersMiddleLowestHighest.ExtractKey();
            #endregion

            #region Assert
            Assert.AreEqual(participantHighest, highestWinner, "Highest Participant Not Extracted Correctly.");
            #endregion
        }

        [TestMethod]
        public void PriorityQueue_ExtractMax_EachExtractReturnsHighestValue() {
            #region Arrange
            PriorityQueue<Participant, int> Winners = new PriorityQueue<Participant, int>(new ExtractMax());
            Winners.Insert(new KeyValuePair<Participant, int>(new Participant { Name = "1", ParticipantId = 1 }, 1000));
            Winners.Insert(new KeyValuePair<Participant, int>(new Participant { Name = "2", ParticipantId = 2 }, 500));
            Winners.Insert(new KeyValuePair<Participant, int>(new Participant { Name = "3", ParticipantId = 3 }, 600));
            Winners.Insert(new KeyValuePair<Participant, int>(new Participant { Name = "4", ParticipantId = 4 }, 100));
            Winners.Insert(new KeyValuePair<Participant, int>(new Participant { Name = "5", ParticipantId = 5 }, 150));
            Winners.Insert(new KeyValuePair<Participant, int>(new Participant { Name = "6", ParticipantId = 6 }, 175));
            Winners.Insert(new KeyValuePair<Participant, int>(new Participant { Name = "7", ParticipantId = 7 }, 10));
            Winners.Insert(new KeyValuePair<Participant, int>(new Participant { Name = "8", ParticipantId = 8 }, 750));
            Winners.Insert(new KeyValuePair<Participant, int>(new Participant { Name = "9", ParticipantId = 9 }, 300));
            Winners.Insert(new KeyValuePair<Participant, int>(new Participant { Name = "10", ParticipantId = 10 }, 210));
            Winners.Insert(new KeyValuePair<Participant, int>(new Participant { Name = "11", ParticipantId = 11 }, 1));
            Winners.Insert(new KeyValuePair<Participant, int>(new Participant { Name = "12", ParticipantId = 12 }, 19));
            Winners.Insert(new KeyValuePair<Participant, int>(new Participant { Name = "13", ParticipantId = 13 }, 1002));
            Winners.Insert(new KeyValuePair<Participant, int>(new Participant { Name = "14", ParticipantId = 14 }, 1040));
            Winners.Insert(new KeyValuePair<Participant, int>(new Participant { Name = "15", ParticipantId = 15 }, 900));
            Winners.Insert(new KeyValuePair<Participant, int>(new Participant { Name = "16", ParticipantId = 16 }, 90));
            #endregion

            #region Act
            bool AllAreLower = true;
            var higherWinner = Winners.ExtractPair();
            for (int i = 1; i < 16; ++i) {
                var lowerWinner = Winners.ExtractPair();
                if (higherWinner.Value < lowerWinner.Value && AllAreLower) AllAreLower = false;
                higherWinner = lowerWinner;
            }
            #endregion

            #region Assert
            Assert.IsTrue(AllAreLower,"Winners did not extract from highest to lowest value");
            #endregion
        }

        [TestMethod]
        public void PriorityQueue_ExtractMin_InsertLowestBubblesToRoot() {
            #region Arrange
            Participant participantHighest = new Participant() { Name = "Highest", ParticipantId = 1 };
            Participant participantMiddle = new Participant() { Name = "Middle", ParticipantId = 2 };
            Participant participantLower = new Participant() { Name = "Lower", ParticipantId = 3 };
            Participant participantLowest = new Participant() { Name = "Lowest", ParticipantId = 4 };
            int highestRoll = 100;
            int middleRoll = 50;
            int lowerRoll = 10;
            int lowestRoll = 1;

            PriorityQueue<Participant, int> WinnersMiddleLowestHighest = new PriorityQueue<Participant, int>(new ExtractMin());
            WinnersMiddleLowestHighest.Insert(participantMiddle, middleRoll);
            WinnersMiddleLowestHighest.Insert(participantLower, lowerRoll);
            WinnersMiddleLowestHighest.Insert(participantHighest, highestRoll);
            WinnersMiddleLowestHighest.Insert(participantLowest, lowestRoll);
            #endregion

            #region Act
            var lowestWinner = WinnersMiddleLowestHighest.ExtractKey();
            #endregion

            #region Assert
            Assert.AreEqual(participantLowest, lowestWinner, "Highest Participant Not Extracted Correctly.");
            #endregion
        }

        [TestMethod]
        public void PriorityQueue_ExtractMin_EachExtractReturnsLowestValue() {
            #region Arrange
            PriorityQueue<Participant, int> Winners = new PriorityQueue<Participant, int>(new ExtractMin());
            Winners.Insert(new KeyValuePair<Participant, int>(new Participant { Name = "1", ParticipantId = 1 }, 1000));
            Winners.Insert(new KeyValuePair<Participant, int>(new Participant { Name = "2", ParticipantId = 2 }, 500));
            Winners.Insert(new KeyValuePair<Participant, int>(new Participant { Name = "3", ParticipantId = 3 }, 600));
            Winners.Insert(new KeyValuePair<Participant, int>(new Participant { Name = "4", ParticipantId = 4 }, 100));
            Winners.Insert(new KeyValuePair<Participant, int>(new Participant { Name = "5", ParticipantId = 5 }, 150));
            Winners.Insert(new KeyValuePair<Participant, int>(new Participant { Name = "6", ParticipantId = 6 }, 175));
            Winners.Insert(new KeyValuePair<Participant, int>(new Participant { Name = "7", ParticipantId = 7 }, 10));
            Winners.Insert(new KeyValuePair<Participant, int>(new Participant { Name = "8", ParticipantId = 8 }, 750));
            Winners.Insert(new KeyValuePair<Participant, int>(new Participant { Name = "9", ParticipantId = 9 }, 300));
            Winners.Insert(new KeyValuePair<Participant, int>(new Participant { Name = "10", ParticipantId = 10 }, 210));
            Winners.Insert(new KeyValuePair<Participant, int>(new Participant { Name = "11", ParticipantId = 11 }, 1));
            Winners.Insert(new KeyValuePair<Participant, int>(new Participant { Name = "12", ParticipantId = 12 }, 19));
            Winners.Insert(new KeyValuePair<Participant, int>(new Participant { Name = "13", ParticipantId = 13 }, 1002));
            Winners.Insert(new KeyValuePair<Participant, int>(new Participant { Name = "14", ParticipantId = 14 }, 1040));
            Winners.Insert(new KeyValuePair<Participant, int>(new Participant { Name = "15", ParticipantId = 15 }, 900));
            Winners.Insert(new KeyValuePair<Participant, int>(new Participant { Name = "16", ParticipantId = 16 }, 90));
            #endregion

            #region Act
            bool AllAreLower = true;
            var lowerWinner = Winners.ExtractPair();
            for (int i = 1; i < 16; ++i) {
                var higherWinner = Winners.ExtractPair();
                if (higherWinner.Value < lowerWinner.Value && AllAreLower) AllAreLower = false;
                lowerWinner = higherWinner;
            }
            #endregion

            #region Assert
            Assert.IsTrue(AllAreLower, "Winners did not extract from lowest to highest value");
            #endregion
        }
    }
}
