﻿namespace TDD_Squirrel;

    public class FigureMover
{
    public static int RollDie()
    {
        var generator = new Random();
        var result = generator.Next(1, 7);
        return result;
    }


    public static int CalculatePosition(int i, int i1)
    {
        return 1;
    }
}
