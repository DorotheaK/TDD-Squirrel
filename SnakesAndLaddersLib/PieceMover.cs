using System.Security.Cryptography.X509Certificates;

namespace SnakesAndLaddersLib;

public class PieceMover
{
    private readonly IDiceRoller _diceRoller;
    private readonly int _size;

    public PieceMover(IDiceRoller diceRoller, int size)
    {
        _diceRoller = diceRoller;
        _size = size;
    }

    public MovingResult Move((int, int) previousPosition)
    {
        var dieRoll = _diceRoller.RollDie();
        var newPosition = CalculatePosition(previousPosition, dieRoll);
        return new MovingResult(newPosition, false);
    }

    private  (int, int) CalculatePosition((int, int) previousPosition, int dieRoll)
    {
        var newX = previousPosition.Item1;
        var newY = previousPosition.Item2;

        if (_size % 2 == 0)  // _size of the board is even
        {
            if (previousPosition.Item2 % 2 == 0)
            {
                 newX = previousPosition.Item1 - dieRoll;
                 newY = previousPosition.Item2;
            }
            else
            {
                newX = previousPosition.Item1 + dieRoll;
                newY = previousPosition.Item2;
            }

        }
        else // _size if the board is odd
        {
            if (previousPosition.Item2 % 2 == 0)
            {
                newX = previousPosition.Item1 + dieRoll;
                newY = previousPosition.Item2;
            }
            else
            {
                newX = previousPosition.Item1 - dieRoll;
                newY = previousPosition.Item2;
            }
        }

        while (newX > _size - 1 || newX < 0)
        {
            if (newX > _size - 1)
            {
                var overflow = newX - (_size - 1);
                newX = _size - overflow;
                newY -= 1;
            }

            if (newX < 0)
            {
                var overflow = -newX - 1;
                newX = overflow;
                newY -= 1;
            }

            if (_size % 2 == 0)  // _size of the board is even
            {
                if (newY < 0) 
                {
                    newX = 0;
                    newY = 0;
                    break;
                }
            }
            else // _size if the board is odd
            {
                newX = _size - 1;
                newY = 0;
            }
        }


        return (newX, newY);
    }

    //public  MovingResult Move(int previousPosition, int numberOfFields)
    //{
    //    var dieRoll = _diceRoller.RollDie();
    //    var newPosition = CalculatePosition(previousPosition, dieRoll, numberOfFields);
    //    var gameFinished = newPosition == numberOfFields;
    //    return new MovingResult(newPosition, gameFinished);
    //}

    private static int CalculatePosition(int previousPosition, int dieResult, int numberOfFields)
    {
        var nextPosition = previousPosition + dieResult;
        return Math.Min(nextPosition, numberOfFields);
    }

}