using System;
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
        public void PriorityQueue_MaxBubbleUpHighestValueToIndexZero_Always() {
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
        public void PriorityQueue_MaxExtractMaxBubbleUpNextHighestValueToIndexZero_Always() {

        }

        [TestMethod]
        public void PriorityQueue_MinBubbleUpLowestValueToIndexZero_Always() {
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
        public void PriorityQueue_MinExtractMinBubbleUpNextLowstValueToIndexZero_Always() {

        }
    }
}
