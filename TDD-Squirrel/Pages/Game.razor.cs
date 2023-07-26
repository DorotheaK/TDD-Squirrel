using SnakesAndLaddersLib;

namespace TDD_Squirrel.Pages
{
    public partial class Game
    {
        private int _prepartionBoardSize = 0;

        private PieceMover pieceMover;
        public Game()
        {
            var diceRoller = new DiceRoller();
            pieceMover = new PieceMover(diceRoller);
        }

        private int NumberOfFields = 0;
        private int NumberOfRows = 0;

        public int PiecePosition = 0;

        public bool DisabledDie = false;
        public bool ShowGame = false;

        private void MovePiece()
        {
            var result = pieceMover.Move(PiecePosition, NumberOfFields);
            DisabledDie = result.IsFinalSquareReached;
            PiecePosition = result.Position;
        }

        private void StartNewGame()
        {
            var game = GameCreator.CreateGame(_prepartionBoardSize);
            DisabledDie = game.IsDieDisabled;
            ShowGame = game.Status;
            //PiecePosition = game.Position;
            NumberOfFields = game.Columns;
            NumberOfRows = game.Rows;
        }
    }
}

