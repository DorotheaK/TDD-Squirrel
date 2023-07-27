using System.Diagnostics.CodeAnalysis;
using FakeItEasy;
using FluentAssertions;
using FluentAssertions.Execution;
using SnakesAndLaddersLib;

namespace SnakesAndLaddersLibTests
{
    public class PieceMoverTests
    {
        private IDiceRoller _diceRoller;
        private PieceMover _sut;

        [SetUp]
        public void SetUp()
        {
            _diceRoller = A.Fake<IDiceRoller>();
            _sut = new PieceMover(_diceRoller);
        }

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

        [TestCase(0, 3, 1, 1, 3)]
        [TestCase(0, 3, 2, 2, 3)]
        [TestCase(0, 3, 4, 3, 2)]
        [TestCase(3, 2, 1, 2, 2)]
        [TestCase(3, 3, 2, 2, 2)]
        [TestCase(0, 2, 2, 1, 1)]
        [TestCase(3, 3, 6, 1, 1)]
        [TestCase(0, 2, 6, 2, 0)]
        [TestCase(0, 2, 6, 2, 0)]
        [TestCase(2, 0, 6, 0, 0)]


        public void Move_Should_ReturnExpected(int x, int y, int movement, int expectedX, int expectedY)
        {
            A.CallTo(() => _diceRoller.RollDie()).Returns(movement);
            var result = _sut.Move((x, y));
            result.Position.Should().Be((expectedX,expectedY));
        }

    }
}
