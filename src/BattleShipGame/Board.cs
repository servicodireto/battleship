using System;
using System.Collections.Generic;
using System.Linq;

namespace BattleShipGame
{
    public class Board
    {
        #region [Attributes]

        private readonly string _playerName;
        private Position[,] _dimension;
        private List<BattleShip> _battleShips;

        #endregion

        #region [Constructor]

        public Board( string playerName )
        {
            _playerName = playerName;
            _dimension = new Position[Constants.MAX_X, Constants.MAX_Y];
            _battleShips = new List<BattleShip>();
        }

        #endregion

        #region [AddBattleShip]

        public void AddBattleShip( string start, string end )
        {
            start = start.Trim().ToUpper();
            end = end.Trim().ToUpper();
            //
            PositionRange range = new PositionRange( Position.Convert( start ), Position.Convert( end ) );
            AddBattleShip( new BattleShip( range, string.Format( "{0}->{1}", start, end ) ) );
        }

        public void AddBattleShip( string position )
        {
            position = position.Trim().ToUpper();
            PositionRange range = new PositionRange( Position.Convert( position ), Position.Convert( position ) );
            AddBattleShip( new BattleShip( range, position ) );
        }

        private void AddBattleShip( BattleShip battleShip )
        {
            if ( !battleShip.CheckRangePosition() )
                throw new Exceptions.InvalidRangeException();

            if ( HasPositionFilled( battleShip ) )
                throw new Exceptions.InvalidBattleShipPositionException();

            _battleShips.Add( battleShip );
            foreach ( var item in battleShip.Positions )
                _dimension[item.X, item.Y] = item;
        }

        #endregion

        #region [HasPositionFilled]
        private bool HasPositionFilled( BattleShip battleShip )
        {
            bool result = false;
            foreach ( var position in battleShip.Positions )
            {
                if ( _dimension[position.X, position.Y] != null )
                {
                    result = true;
                    break;
                }
            }
            return result;
        }
        #endregion

        #region [DisplayDimension]
        /// <summary>
        /// Display all positions and status
        /// </summary>
        public void DisplayDimension()
        {
            Console.ForegroundColor = ConsoleColor.White;
            for ( int x = 0; x < Constants.MAX_X; x++ )
            {
                for ( int y = 0; y < Constants.MAX_Y; y++ )
                {
                    var item = _dimension[x, y];
                    string position = string.Format( "{0}{1}", (char)( x + Constants.A ), y + 1 ).PadRight( 3, ' ' );
                    if ( item == null )
                        Console.ForegroundColor = ConsoleColor.White;
                    else
                        Console.ForegroundColor = ConsoleColor.Green;


                    Console.WriteLine( "Pos: {0} X: {1} Y: {2}  - {3}", position, x, y, ( item == null ) ? "Empty" : item.Status.ToString() );
                }
            }
        }
        #endregion

        /// <summary>
        /// Display all battleships status
        /// </summary>
        public void DisplayBattleShipStatus()
        {
            Console.ForegroundColor = ConsoleColor.White;
            foreach ( var item in _battleShips )
            {
                Console.WriteLine("{0} - {1}", item.Name, item.GetStatus() );
            }
        }

        #region [Attack]
        /// <summary>
        /// Attack a specific position
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public Position Attack( string position )
        {
            var element = Position.Convert( position );
            if ( _dimension[element.X, element.Y] == null )
            {
                element.Status = StatusType.Miss;
                _dimension[element.X, element.Y] = element;
            }
            else
            {
                _dimension[element.X, element.Y].Status = StatusType.Hit;
                element = _dimension[element.X, element.Y];
            }

            if ( element.Status == StatusType.Hit )
                Console.ForegroundColor = ConsoleColor.Green;
            else
                Console.ForegroundColor = ConsoleColor.Red;


            Console.WriteLine( "{0} : {1}", position, element.Status );

            return element;
        }
        #endregion

        #region [GameStatus]
        /// <summary>
        /// Get latest status of the game
        /// </summary>
        /// <returns></returns>
        public GameStatusType GameStatus()
        {
            var status = ( _battleShips.Count == _battleShips.Where( p => p.GetStatus() == BattleShipStatus.Sunk ).Count() ? GameStatusType.GameOver : GameStatusType.OnGoing );
            Console.WriteLine( "[Status: {0}]", status );
            return status;
        }
        #endregion
    }

    public enum GameStatusType
    {
        GameOver,
        OnGoing
    }
}
