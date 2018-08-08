using System;

namespace BattleShipGame
{
    class Program
    {
        static void Main( string[] args )
        {
            Board board = new Board( "Igor" );
            board.AddBattleShip( "A1", "A4" );
            board.AddBattleShip( "B1", "B4" );
            board.AddBattleShip( "J1", "J3" );

            //------------------//
            board.Attack( "A1" ); //HIT
            board.Attack( "A2" ); 
            board.Attack( "A3" );
            board.Attack( "A4" );
            board.Attack( "A5" ); //MISS
            //------------------//
            board.Attack( "B1" );
            board.Attack( "B2" );
            board.Attack( "B3" );
            board.Attack( "B4" );

            board.GameStatus();
            board.DisplayDimension();
            Console.ReadKey();
        }
    }
}
