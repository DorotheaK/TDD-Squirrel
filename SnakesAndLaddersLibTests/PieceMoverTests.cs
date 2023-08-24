using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using FakeItEasy;
using FluentAssertions;
using FluentAssertions.Execution;
using SnakesAndLaddersLib;

namespace SnakesAndLaddersLibTests
{
    public class PieceMoverTests
    {
        //[TestCase(0, 1, 1)]
        //[TestCase(5, 2, 7)]
        //[TestCase(5, 5, 10)]
        //[TestCase(7, 6, 10)]
        //public void Move_Should_Return_PositionInRange(int previousPosition, int fakedDie, int expected)
        //{
        //    A.CallTo(() => _diceRoller.RollDie()).Returns(fakedDie);
        //    using var assertionScope = new AssertionScope();

        //    var result = _sut.Move(previousPosition, 10);
        //    result.Position.Should().Be(expected);

        //}

        //[TestCase(9, 10, true)]
        //[TestCase(0, 10, false)]
        //[TestCase(10, 15, true)]
        //[TestCase(9, 15, false)]
        //[TestCase(0, 15, false)]
        //public void Move_Should_Return_GameStatus(int position, int numberOfFields, bool expected)
        //{
        //    A.CallTo(() => _diceRoller.RollDie()).Returns(5);
        //    var result = _sut.Move(position, numberOfFields);
        //    result.IsFinalSquareReached.Should().Be(expected);
        //}

        
        [TestCase(3, 2, 1, 4, 2, 2)]
        [TestCase(3, 3, 2, 4, 2, 2)]
        [TestCase(0, 2, 2, 4, 1, 1)]
        [TestCase(3, 3, 6, 4, 1, 1)]
        [TestCase(0, 2, 6, 4, 2, 0)]
        [TestCase(0, 2, 6, 4, 2, 0)]
        [TestCase(2, 0, 6, 4,  0, 0)]
        
        [TestCase(0, 4, 1, 5, 1, 4)] // move right
        [TestCase(0, 3, 1, 4, 1, 3)]
        [TestCase(0, 3, 2, 4, 2, 3)]


        // move up - on right side
        [TestCase(0, 4, 5, 5, 4, 3)]
        [TestCase(0, 3, 4, 4, 3, 2)]


        [TestCase(3, 3, 1, 5, 2, 3)] //move left

        [TestCase(0, 3, 2, 5, 1, 2)] // move up on left side

        [TestCase(4, 4, 6, 5, 0, 2)]  // snake 
        [TestCase(0, 3, 6, 5, 4, 1)]   
        [TestCase(0, 2, 6, 5, 3, 1)]
        [TestCase(2, 0, 6, 5,  4, 0)]  // end 


        public void Move_Should_ReturnExpected(int x, int y, int movement,int size, int expectedX, int expectedY)
        {
            var diceRoller = A.Fake<IDiceRoller>();
            var sut = new PieceMover(diceRoller, size);
            A.CallTo(() => diceRoller.RollDie()).Returns(movement);

            var result = sut.Move((x, y));
            result.Position.Should().Be((expectedX,expectedY));
        }

        // Ladder from (2,3) to (2,2) ***************************************************************************************************************************************
        // In the following part a small ladder is implemented and tested. The ladder lets you reduce the y-position by 1.

        // [TestCase] (2, 3, )]

        //TODO: in weiterem Schritt ladder als Objekt erzeugen lassen und hier als Parameter einlesen
        [Test]
        public void Move_On_Ladder_Should_Return_2()// später durch: ...End_of_Ladder() ersetzen//int startX, int startY, int endLadder01X, int endLadder01Y, int size, int expectedX, int expectedY
        {
            var result = LadderMove((2, 3), 2);
            result.Should().Be(2); 
        }

        public int LadderMove((int, int) previousPosition, int endLadder01X) // later: LadderResult LadderMove((int, int) previousPosition, int endLadder01X, int endLadder01Y)
        {
            var oldX = previousPosition.Item1;
            var oldY = previousPosition.Item2;

            var newX = oldX;
            var newY = oldY - 1;

            return newY;//new LadderResult(newPosition, false);

        }
    }
}
