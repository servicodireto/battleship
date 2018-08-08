using System;
using System.Collections.Generic;
using System.Linq;

namespace BattleShipGame
{
    public class BattleShip
    {
        #region [Attributes]
        private PositionRange _range;
        #endregion

        #region [Properties]
        public List<Position> Positions { get; set; }
        #endregion

        #region [Constructor]
        public BattleShip( PositionRange range )
        {
            Positions = new List<Position>();
            _range = range;
            if ( _range.Start.X == _range.End.X )
            {
                for ( short i = _range.Start.Y; i <= _range.End.Y; i++ )
                    Positions.Add( new Position( _range.Start.X, i ) );
            }
            else if ( _range.Start.Y == _range.End.Y )
            {
                for ( short i = _range.Start.X; i <= _range.End.X; i++ )
                    Positions.Add( new Position( i, _range.Start.Y ) );
            }
        }
        #endregion

        #region [CheckRangePosition]
        public bool CheckRangePosition()
        {
            return ( _range.Start.X == _range.End.X || _range.Start.Y == _range.End.Y );
        }
        #endregion

        #region [GetStatus]
        /// <summary>
        /// Get battleship status
        /// </summary>
        /// <returns></returns>
        public BattleShipStatus GetStatus()
        {
            return ( Positions.Count == Positions.Where( p => p.Status == StatusType.Hit ).Count() ) ? BattleShipStatus.Sunk : BattleShipStatus.Alive;
        }
        #endregion
    }

    public enum BattleShipStatus
    {
        Alive,
        Sunk
    }
}
