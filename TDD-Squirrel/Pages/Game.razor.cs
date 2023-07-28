using SnakesAndLaddersLib;

namespace TDD_Squirrel.Pages
{
    public partial class Game
    {
        private int _prepartionBoardSize = 1;

        private readonly PieceMover _pieceMover;
        public Game()
        {
            var diceRoller = new DiceRoller();
            _pieceMover = new PieceMover(diceRoller);
        }

        private int _numberOfFields = 0;
        private int _numberOfRows = 0;

        private (int, int) _piecePosition = default!;

        private bool _disabledDie = false;
        private bool _showGame = false;

        private void MovePiece()
        {
            var result = _pieceMover.Move(_piecePosition);
            _disabledDie = result.IsFinalSquareReached;

            _piecePosition = result.Position;
        }

        private void StartNewGame()
        {
            var game = GameCreator.CreateGame(_prepartionBoardSize);
            _disabledDie = game.IsDieDisabled;
            _showGame = game.Status;
            _numberOfFields = game.Columns;
            _numberOfRows = game.Rows;

            //Set start position
            _piecePosition = (0, game.Rows - 1);
        }
    }
}

