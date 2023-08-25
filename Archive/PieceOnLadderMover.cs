namespace SnakesAndLaddersLibTests;

public class PieceOnLadderMover
{
    public static int LadderMove(int x, int y)// later: (int, int) previousPosition) // later: LadderResult LadderMove((int, int) previousPosition, int endLadder01X, int endLadder01Y)
    {
        var oldX = x;// later: previousPosition.Item1;
        var oldY = y; // later: previousPosition.Item2;

        var newX = oldX;
        var newY = oldY - 1;

        return newY;//later: new LadderResult(newPosition, false);

    }

    public static int CreateLadder()
    {
        var random = new Random();
        var result = random.Next(1, 4);
        return result;
    }
}