# battleship

This code was written using Visual Studio 2017 / C# Core 2.0 and based on board below:

![Batteship img](https://github.com/servicodireto/battleship/blob/master/src/BattleShipGame/imgs/Battleship_game_board.svg)

```
class Program
    {
        static void Main( string[] args )
        {
            Board board = new Board( "Igor" );
            board.AddBattleShip( "A1", "B1" );
            board.AddBattleShip( "D1", "D3" );
            board.AddBattleShip( "G1", "J1" );
            board.AddBattleShip( "A3", "A6" );
            board.AddBattleShip( "F3", "H3" );
            board.AddBattleShip( "J3", "J4" );
            board.AddBattleShip( "A8", "B8" );
            board.AddBattleShip( "F6", "F7" );
            board.AddBattleShip( "J6", "J8" );
            board.AddBattleShip( "E10", "J10" );

            board.Attack( "A8" ); //HIT
            board.Attack( "B6" ); //MISS
            board.Attack( "B8" ); //HIT
            board.Attack( "C4" ); //MISS
            board.Attack( "F5" ); //MISS
            board.Attack( "G5" ); //MISS
            board.Attack( "H6" ); //MISS
            board.Attack( "H8" ); //MISS
            board.Attack( "J6" ); //HIT
            board.Attack( "J7" ); //HIT
            Console.WriteLine( "---------------------GAMESTATUS------------------------" );
            board.GameStatus();

            Console.WriteLine( "---------------------BATTLESHIP_STATUS-----------------" );
            board.DisplayBattleShipStatus();

            Console.WriteLine( "---------------------DISPLAY ALL POSITIONS-------------" );
            board.DisplayDimension();
            Console.WriteLine( "-------------------------------------------------" );


            Console.ReadKey();
        }
 ```
