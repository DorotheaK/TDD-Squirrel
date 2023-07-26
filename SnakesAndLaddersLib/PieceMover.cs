namespace SnakesAndLaddersLib;

public class PieceMover
{
    private readonly IDiceRoller _diceRoller;

    public PieceMover(IDiceRoller diceRoller)
    {
        _diceRoller = diceRoller;
    }

    public MovingResult Move((int, int) previousPosition)
    {
        var dieRoll = _diceRoller.RollDie();
        var newPosition = CalculatePosition(previousPosition, dieRoll);
        return new MovingResult(newPosition, false);
    }

    private static (int, int) CalculatePosition((int, int) previousPosition, int dieRoll)
    {
        var newX = previousPosition.Item1 + dieRoll;
        var newY = previousPosition.Item2;
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