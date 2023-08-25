using FluentAssertions;
using SnakesAndLaddersLib;

namespace SnakesAndLaddersLibTests;

// Ladder ***************************************************************************************************************************************
// In the following part a small ladder is implemented and tested. The ladder lets you reduce the y-position by 1.

//TODO: evtl. in weiterem Schritt ladder als Objekt erzeugen lassen und hier als Parameter einlesen

// When reaching a position (x, y) assuming there is a small ladder:
// move piece to the position directly above the current position
public class LadderMoverTests
{
    [TestCase(2, 3, 2)]
    [TestCase(0, 3, 2)]
    [TestCase(3, 3, 2)]
    [TestCase(0, 3, 2)]
    [TestCase(3, 1, 0)]
    [TestCase(0, 1, 0)]
    // size > 4
    [TestCase(2, 4, 3)]
    [TestCase(4, 1, 0)]
    [TestCase(4, 1, 0)]
    [TestCase(0, 1, 0)]
    public void Move_On_Ladder_Should_Return_ExpectedYField(int xPosition, int yPosition , int expectedPosition)// später durch: ...End_of_Ladder() ersetzen
    {
        // later: var result = LadderMove(previousPosition); 
        var oldX = xPosition; // later: previousPosition.Item1;
        var oldY = yPosition; // later: previousPosition.Item2;

        var result = LadderMove(oldX, oldY);
        result.Should().Be(expectedPosition);
       // AssertionExtensions.Should((int)result).Be(expectedPosition); 
    }

    public static int LadderMove(int x, int y)// later: (int, int) previousPosition) // later: LadderResult LadderMove((int, int) previousPosition, int endLadder01X, int endLadder01Y)
    {
        var oldX = x;// later: previousPosition.Item1;
        var oldY = y; // later: previousPosition.Item2;

        var newX = oldX;
        var newY = oldY - 1;

        return newY;//later: new LadderResult(newPosition, false);

    }

    [Test]
    // A ladder should never start in the last row (y = 0);
    // so make sure the starting position of a ladder > 0 (and here <= 4)
    public void CreateLadder_Should_Return_IntInRange1To4() //later: int size
    {
        var startPosition = CreateLadder();
        startPosition.Should().BeOfType(typeof(int));
        //AssertionExtensions.Should((int)startPosition).BeOfType(typeof(int));

        // later: var maxY = size - 1;
        startPosition.Should().BeInRange(1, 4); // maxY);
        //AssertionExtensions.Should((int)startPosition).BeInRange(1, 4); 
    }

    private int CreateLadder()
    {
        var random = new Random();
        var result = random.Next(1, 4);
        return result;
    }
}