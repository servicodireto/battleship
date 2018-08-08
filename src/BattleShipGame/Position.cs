using BattleShipGame.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShipGame
{
    public class Position
    {
        #region [Properties]
        public StatusType Status { get; set; }
        public short X { get; }
        public short Y { get; }
        #endregion

        #region [Constructor]
        public Position( short x, short y, BattleShip battleShip )
        {
            X = x;
            Y = y;
            Status = StatusType.None;
        }

        public Position( short x, short y)
        {
            X = x;
            Y = y;
            Status = StatusType.None;
        }
        #endregion

        #region [Convert]
        public static Position Convert( string position )
        {
            short x = 0;
            short y = 0;
            Position result;
            try
            {
                position = position.PadRight( 3, ' ' );
                x = short.Parse( ( position[0] - Constants.A ).ToString() );
                y = short.Parse( position.Substring( 1, 2 ).ToString() );
                y--;

                if ( y < 0 || x >= Constants.MAX_X || y >= Constants.MAX_Y )
                    throw new InvalidPositionException();

                result = new Position( x, y );
            }
            catch
            {
                throw new InvalidPositionException();
            }

            return result;
        }
        #endregion
    }

    public enum StatusType
    {
        None,
        Miss,
        Hit,
    }
}
