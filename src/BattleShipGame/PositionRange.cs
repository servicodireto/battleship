using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShipGame
{
    public class PositionRange
    {
        #region [Properties]
        public Position Start { get; }
        public Position End { get; }
        #endregion

        #region [Constructor]
        public PositionRange( Position start, Position end )
        {
            Start = start;
            End = end;
        }
        #endregion
    }
}
