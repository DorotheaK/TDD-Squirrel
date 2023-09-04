﻿using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using FakeItEasy;
using FluentAssertions;
using FluentAssertions.Execution;
using SnakesAndLaddersLib;

namespace SnakesAndLaddersLibTests
{
    public class PieceMoverTests
    {
        private readonly LadderMoverTests _ladderMoverTests = new LadderMoverTests();
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

    }
}
