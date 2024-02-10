using System;
using System.Threading;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        //starts a new game
        Game game = new Game();
        game.game();
    }
}
class PlayAgain
{
    public void playagain()
    {   
        //once a game has ended the code jumps hear and asks the player if they want ot play again
        Console.Clear();
        Console.Write("Would you like to play again? (y/n): ");
        string again = Console.ReadLine();
        if (again == "Y" || again == "y" || again == "Yes" || again == "yes") {
            Game game = new Game();
            game.game();
        } else {
            Console.WriteLine("Have a good day!");
            Thread.Sleep(6000);
        }
    }
}
class Game
{   
    public void game()
    {
        //calls the a class that shows the display in an empty form
        Display display = new Display(); 
        display.display();
        //creates a list that the game pieces will go into
        var numbers = new List<string>(){" "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "};
        //a list used the detrmine which placement a piece will go into based on pieces already in the colum.
        var sendToBottom = new List<int>(){35,28,21,14,7,0}; 
        //a variable used to know how many pieces are on the borad, and it's also used to know when the game is over.
        int j = 0;
        //a variable used to detrmine who the player is
        int player = 0;
        //a varaible used to determine what the game piece is.
        string piece;
        //while the game is going
        while (j < 42)
        {
            //this block of code determines who the player is. Player 1 will always go first
            if (player % 2 == 0) {
                Console.WriteLine("Player 1 Go");
                piece = "X";
            } else {
                Console.WriteLine("Player 2 Go");
                piece = "O";
            }
            //asks the user for input
            Console.Write("Plz choose a number between 1 and 7: ");
            int choice = int.Parse(Console.ReadLine());
            //if the input is bad, try again
            while (choice < 1 || choice > 7) {
                Console.Write("Plz choose a number between 1 and 7: ");
                choice = int.Parse(Console.ReadLine());
            }
            //clear this display
            Console.Clear();
            // a variable used to know how many pieces are in the selected columns
            int placement = 0;
            //used to check if a column is full
            bool isfull = false;
            //checks if a piece is in the selcected place. If so it will rise up one column and check again
            while ((numbers[choice - 1 + sendToBottom[placement]] == "X"  || numbers[choice - 1 + sendToBottom[placement]] == "O") && isfull == false) {
                if (placement == 5) {
                    //if the column is full, the program will go back one move so that a player doesn't lose a turn, and no game progress is lost
                    Console.WriteLine($"The {choice} column is already full");
                    j--;
                    player--;
                    isfull = true;
                } else {
                placement++;
                }
            }
            //once the place where the game piece can be placed is found, it will put down the piece unless that column is already full.
            if (isfull != true) {
                numbers[choice - 1 + sendToBottom[placement]] = piece;
            }
            //builds the game board using the numbers list
            for (int i = 1; i < 43; i++)
            {
                if (i == 1){
                    Console.WriteLine("_____________________________");
                }
                    Console.Write($"| {numbers[i-1]} ");
                if (i % 7 == 0){
                Console.WriteLine("|\n_____________________________");
                }
                if (i == 42) {
                Console.WriteLine("  1   2   3   4   5   6   7   ");
                }
            }
            //this next large block of code checks all 138 possible ways the game might end.
            if (numbers[0] == "X" && numbers[1] == "X" && numbers[2] == "X" && numbers[3] == "X" ||
                numbers[1] == "X" && numbers[2] == "X" && numbers[3] == "X" && numbers[4] == "X" ||
                numbers[2] == "X" && numbers[3] == "X" && numbers[4] == "X" && numbers[5] == "X" ||
                numbers[3] == "X" && numbers[4] == "X" && numbers[5] == "X" && numbers[6] == "X" ||
                numbers[7] == "X" && numbers[8] == "X" && numbers[9] == "X" && numbers[10] == "X" ||
                numbers[8] == "X" && numbers[9] == "X" && numbers[10] == "X" && numbers[11] == "X" ||
                numbers[9] == "X" && numbers[10] == "X" && numbers[11] == "X" && numbers[12] == "X" ||
                numbers[10] == "X" && numbers[11] == "X" && numbers[12] == "X" && numbers[13] == "X" ||
                numbers[14] == "X" && numbers[15] == "X" && numbers[16] == "X" && numbers[17] == "X" ||
                numbers[15] == "X" && numbers[16] == "X" && numbers[17] == "X" && numbers[18] == "X" ||
                numbers[16] == "X" && numbers[17] == "X" && numbers[18] == "X" && numbers[19] == "X" ||
                numbers[17] == "X" && numbers[18] == "X" && numbers[19] == "X" && numbers[20] == "X" ||
                numbers[21] == "X" && numbers[22] == "X" && numbers[23] == "X" && numbers[24] == "X" ||
                numbers[22] == "X" && numbers[23] == "X" && numbers[24] == "X" && numbers[25] == "X" ||
                numbers[23] == "X" && numbers[24] == "X" && numbers[25] == "X" && numbers[26] == "X" ||
                numbers[24] == "X" && numbers[25] == "X" && numbers[26] == "X" && numbers[27] == "X" ||
                numbers[28] == "X" && numbers[29] == "X" && numbers[30] == "X" && numbers[31] == "X" ||
                numbers[29] == "X" && numbers[30] == "X" && numbers[31] == "X" && numbers[32] == "X" ||
                numbers[30] == "X" && numbers[31] == "X" && numbers[32] == "X" && numbers[33] == "X" ||
                numbers[31] == "X" && numbers[32] == "X" && numbers[33] == "X" && numbers[34] == "X" ||
                numbers[35] == "X" && numbers[36] == "X" && numbers[37] == "X" && numbers[38] == "X" ||
                numbers[36] == "X" && numbers[37] == "X" && numbers[38] == "X" && numbers[39] == "X" ||
                numbers[37] == "X" && numbers[38] == "X" && numbers[39] == "X" && numbers[40] == "X" ||
                numbers[38] == "X" && numbers[39] == "X" && numbers[40] == "X" && numbers[41] == "X"){
                    Console.WriteLine("Player 1 wins by horizonal connect four!!");
                    j = 42;
            } else if ( numbers[0] == "X" && numbers[7] == "X" && numbers[14] == "X" && numbers[21] == "X" ||
                numbers[7] == "X" && numbers[14] == "X" && numbers[21] == "X" && numbers[28] == "X" ||
                numbers[14] == "X" && numbers[21] == "X" && numbers[28] == "X" && numbers[35] == "X" ||
                numbers[1] == "X" && numbers[8] == "X" && numbers[15] == "X" && numbers[22] == "X" ||
                numbers[8] == "X" && numbers[15] == "X" && numbers[22] == "X" && numbers[29] == "X" ||
                numbers[15] == "X" && numbers[22] == "X" && numbers[29] == "X" && numbers[36] == "X" ||
                numbers[2] == "X" && numbers[9] == "X" && numbers[16] == "X" && numbers[23] == "X" ||
                numbers[9] == "X" && numbers[16] == "X" && numbers[23] == "X" && numbers[30] == "X" ||
                numbers[16] == "X" && numbers[23] == "X" && numbers[30] == "X" && numbers[37] == "X" ||
                numbers[3] == "X" && numbers[10] == "X" && numbers[17] == "X" && numbers[24] == "X" ||
                numbers[10] == "X" && numbers[17] == "X" && numbers[24] == "X" && numbers[31] == "X" ||
                numbers[17] == "X" && numbers[24] == "X" && numbers[31] == "X" && numbers[38] == "X" ||
                numbers[4] == "X" && numbers[11] == "X" && numbers[18] == "X" && numbers[25] == "X" ||
                numbers[11] == "X" && numbers[18] == "X" && numbers[25] == "X" && numbers[32] == "X" ||
                numbers[18] == "X" && numbers[25] == "X" && numbers[32] == "X" && numbers[39] == "X" ||
                numbers[5] == "X" && numbers[12] == "X" && numbers[18] == "X" && numbers[25] == "X" ||
                numbers[12] == "X" && numbers[19] == "X" && numbers[26] == "X" && numbers[33] == "X" ||
                numbers[19] == "X" && numbers[26] == "X" && numbers[33] == "X" && numbers[40] == "X" ||
                numbers[6] == "X" && numbers[13] == "X" && numbers[20] == "X" && numbers[27] == "X" ||
                numbers[13] == "X" && numbers[20] == "X" && numbers[27] == "X" && numbers[34] == "X" ||
                numbers[20] == "X" && numbers[27] == "X" && numbers[34] == "X" && numbers[41] == "X" ) {
                    Console.WriteLine("Player 1 wins by horizonal connect four!!");
                    j = 42;
                } else if (numbers[0] == "X" && numbers[8] == "X" && numbers[16] == "X" && numbers[24] == "X" ||
                numbers[1] == "X" && numbers[9] == "X" && numbers[17] == "X" && numbers[25] == "X" ||
                numbers[2] == "X" && numbers[10] == "X" && numbers[18] == "X" && numbers[26] == "X" ||
                numbers[3] == "X" && numbers[11] == "X" && numbers[19] == "X" && numbers[27] == "X" ||
                numbers[7] == "X" && numbers[15] == "X" && numbers[23] == "X" && numbers[31] == "X" ||
                numbers[8] == "X" && numbers[16] == "X" && numbers[24] == "X" && numbers[32] == "X" ||
                numbers[9] == "X" && numbers[17] == "X" && numbers[25] == "X" && numbers[33] == "X" ||
                numbers[10] == "X" && numbers[18] == "X" && numbers[26] == "X" && numbers[34] == "X" ||
                numbers[14] == "X" && numbers[22] == "X" && numbers[30] == "X" && numbers[38] == "X" ||
                numbers[15] == "X" && numbers[23] == "X" && numbers[31] == "X" && numbers[39] == "X" ||
                numbers[16] == "X" && numbers[24] == "X" && numbers[32] == "X" && numbers[40] == "X" ||
                numbers[17] == "X" && numbers[25] == "X" && numbers[33] == "X" && numbers[41] == "X" ||
                numbers[6] == "X" && numbers[12] == "X" && numbers[18] == "X" && numbers[24] == "X" ||
                numbers[5] == "X" && numbers[11] == "X" && numbers[17] == "X" && numbers[23] == "X" ||
                numbers[4] == "X" && numbers[10] == "X" && numbers[16] == "X" && numbers[22] == "X" ||
                numbers[3] == "X" && numbers[9] == "X" && numbers[15] == "X" && numbers[21] == "X" ||
                numbers[13] == "X" && numbers[19] == "X" && numbers[25] == "X" && numbers[31] == "X" ||
                numbers[12] == "X" && numbers[18] == "X" && numbers[24] == "X" && numbers[30] == "X" ||
                numbers[11] == "X" && numbers[17] == "X" && numbers[23] == "X" && numbers[29] == "X" ||
                numbers[10] == "X" && numbers[16] == "X" && numbers[22] == "X" && numbers[28] == "X" ||
                numbers[20] == "X" && numbers[26] == "X" && numbers[32] == "X" && numbers[38] == "X" ||
                numbers[19] == "X" && numbers[25] == "X" && numbers[31] == "X" && numbers[37] == "X" ||
                numbers[18] == "X" && numbers[24] == "X" && numbers[30] == "X" && numbers[36] == "X" ||
                numbers[17] == "X" && numbers[23] == "X" && numbers[29] == "X" && numbers[35] == "X"){
                    Console.WriteLine("Player 1 wins by diagnal connect four!!");
                    j = 42;
                } else if (numbers[0] == "O" && numbers[1] == "O" && numbers[2] == "O" && numbers[3] == "O" ||
                numbers[1] == "O" && numbers[2] == "O" && numbers[3] == "O" && numbers[4] == "O" ||
                numbers[2] == "O" && numbers[3] == "O" && numbers[4] == "O" && numbers[5] == "O" ||
                numbers[3] == "O" && numbers[4] == "O" && numbers[5] == "O" && numbers[6] == "O" ||
                numbers[7] == "O" && numbers[8] == "O" && numbers[9] == "O" && numbers[10] == "O" ||
                numbers[8] == "O" && numbers[9] == "O" && numbers[10] == "O" && numbers[11] == "O" ||
                numbers[9] == "O" && numbers[10] == "O" && numbers[11] == "O" && numbers[12] == "O" ||
                numbers[10] == "O" && numbers[11] == "O" && numbers[12] == "O" && numbers[13] == "O" ||
                numbers[14] == "O" && numbers[15] == "O" && numbers[16] == "O" && numbers[17] == "O" ||
                numbers[15] == "O" && numbers[16] == "O" && numbers[17] == "O" && numbers[18] == "O" ||
                numbers[16] == "O" && numbers[17] == "O" && numbers[18] == "O" && numbers[19] == "O" ||
                numbers[17] == "O" && numbers[18] == "O" && numbers[19] == "O" && numbers[20] == "O" ||
                numbers[21] == "O" && numbers[22] == "O" && numbers[23] == "O" && numbers[24] == "O" ||
                numbers[22] == "O" && numbers[23] == "O" && numbers[24] == "O" && numbers[25] == "O" ||
                numbers[23] == "O" && numbers[24] == "O" && numbers[25] == "O" && numbers[26] == "O" ||
                numbers[24] == "O" && numbers[25] == "O" && numbers[26] == "O" && numbers[27] == "O" ||
                numbers[28] == "O" && numbers[29] == "O" && numbers[30] == "O" && numbers[31] == "O" ||
                numbers[29] == "O" && numbers[30] == "O" && numbers[31] == "O" && numbers[32] == "O" ||
                numbers[30] == "O" && numbers[31] == "O" && numbers[32] == "O" && numbers[33] == "O" ||
                numbers[31] == "O" && numbers[32] == "O" && numbers[33] == "O" && numbers[34] == "O" ||
                numbers[35] == "O" && numbers[36] == "O" && numbers[37] == "O" && numbers[38] == "O" ||
                numbers[36] == "O" && numbers[37] == "O" && numbers[38] == "O" && numbers[39] == "O" ||
                numbers[37] == "O" && numbers[38] == "O" && numbers[39] == "O" && numbers[40] == "O" ||
                numbers[38] == "O" && numbers[39] == "O" && numbers[40] == "O" && numbers[41] == "O"){
                    Console.WriteLine("Player 2 wins by horizonal connect four!!");
                    j = 42;
            } else if ( numbers[0] == "O" && numbers[7] == "O" && numbers[14] == "O" && numbers[21] == "O" ||
                numbers[7] == "O" && numbers[14] == "O" && numbers[21] == "O" && numbers[28] == "O" ||
                numbers[14] == "O" && numbers[21] == "O" && numbers[28] == "O" && numbers[35] == "O" ||
                numbers[1] == "O" && numbers[8] == "O" && numbers[15] == "O" && numbers[22] == "O" ||
                numbers[8] == "O" && numbers[15] == "O" && numbers[22] == "O" && numbers[29] == "O" ||
                numbers[15] == "O" && numbers[22] == "O" && numbers[29] == "O" && numbers[36] == "O" ||
                numbers[2] == "O" && numbers[9] == "O" && numbers[16] == "O" && numbers[23] == "O" ||
                numbers[9] == "O" && numbers[16] == "O" && numbers[23] == "O" && numbers[30] == "O" ||
                numbers[16] == "O" && numbers[23] == "O" && numbers[30] == "O" && numbers[37] == "O" ||
                numbers[3] == "O" && numbers[10] == "O" && numbers[17] == "O" && numbers[24] == "O" ||
                numbers[10] == "O" && numbers[17] == "O" && numbers[24] == "O" && numbers[31] == "O" ||
                numbers[17] == "O" && numbers[24] == "O" && numbers[31] == "O" && numbers[38] == "O" ||
                numbers[4] == "O" && numbers[11] == "O" && numbers[18] == "O" && numbers[25] == "O" ||
                numbers[11] == "O" && numbers[18] == "O" && numbers[25] == "O" && numbers[32] == "O" ||
                numbers[18] == "O" && numbers[25] == "O" && numbers[32] == "O" && numbers[39] == "O" ||
                numbers[5] == "O" && numbers[12] == "O" && numbers[18] == "O" && numbers[25] == "O" ||
                numbers[12] == "O" && numbers[19] == "O" && numbers[26] == "O" && numbers[33] == "O" ||
                numbers[19] == "O" && numbers[26] == "O" && numbers[33] == "O" && numbers[40] == "O" ||
                numbers[6] == "O" && numbers[13] == "O" && numbers[20] == "O" && numbers[27] == "O" ||
                numbers[13] == "O" && numbers[20] == "O" && numbers[27] == "O" && numbers[34] == "O" ||
                numbers[20] == "O" && numbers[27] == "O" && numbers[34] == "O" && numbers[41] == "O" ) {
                    Console.WriteLine("Player 2 wins by vertical connect four!!");
                    j = 42;
                } else if (numbers[0] == "O" && numbers[8] == "O" && numbers[16] == "O" && numbers[24] == "O" ||
                numbers[1] == "O" && numbers[9] == "O" && numbers[17] == "O" && numbers[25] == "O" ||
                numbers[2] == "O" && numbers[10] == "O" && numbers[18] == "O" && numbers[26] == "O" ||
                numbers[3] == "O" && numbers[11] == "O" && numbers[19] == "O" && numbers[27] == "O" ||
                numbers[7] == "O" && numbers[15] == "O" && numbers[23] == "O" && numbers[31] == "O" ||
                numbers[8] == "O" && numbers[16] == "O" && numbers[24] == "O" && numbers[32] == "O" ||
                numbers[9] == "O" && numbers[17] == "O" && numbers[25] == "O" && numbers[33] == "O" ||
                numbers[10] == "O" && numbers[18] == "O" && numbers[26] == "O" && numbers[34] == "O" ||
                numbers[14] == "O" && numbers[22] == "O" && numbers[30] == "O" && numbers[38] == "O" ||
                numbers[15] == "O" && numbers[23] == "O" && numbers[31] == "O" && numbers[39] == "O" ||
                numbers[16] == "O" && numbers[24] == "O" && numbers[32] == "O" && numbers[40] == "O" ||
                numbers[17] == "O" && numbers[25] == "O" && numbers[33] == "O" && numbers[41] == "O" ||
                numbers[6] == "O" && numbers[12] == "O" && numbers[18] == "O" && numbers[24] == "O" ||
                numbers[5] == "O" && numbers[11] == "O" && numbers[17] == "O" && numbers[23] == "O" ||
                numbers[4] == "O" && numbers[10] == "O" && numbers[16] == "O" && numbers[22] == "O" ||
                numbers[3] == "O" && numbers[9] == "O" && numbers[15] == "O" && numbers[21] == "O" ||
                numbers[13] == "O" && numbers[19] == "O" && numbers[25] == "O" && numbers[31] == "O" ||
                numbers[12] == "O" && numbers[18] == "O" && numbers[24] == "O" && numbers[30] == "O" ||
                numbers[11] == "O" && numbers[17] == "O" && numbers[23] == "O" && numbers[29] == "O" ||
                numbers[10] == "O" && numbers[16] == "O" && numbers[22] == "O" && numbers[28] == "O" ||
                numbers[20] == "O" && numbers[26] == "O" && numbers[32] == "O" && numbers[38] == "O" ||
                numbers[19] == "O" && numbers[25] == "O" && numbers[31] == "O" && numbers[37] == "O" ||
                numbers[18] == "O" && numbers[24] == "O" && numbers[30] == "O" && numbers[36] == "O" ||
                numbers[17] == "O" && numbers[23] == "O" && numbers[29] == "O" && numbers[35] == "O"){
                    Console.WriteLine("Player 2 wins by diagnal connect four!!");
                    j = 42;
                //the game board is full and nobody wins
                } else if (j == 41) {
                    Console.WriteLine("There is no winner.");
                    j++;
                }
            //increments the game progression
            j++;
            player++;
        }
        //wait 8 seconds, and pass to playagain class
        Thread.Sleep(8000);
        PlayAgain playagain = new PlayAgain();
        playagain.playagain();
    }
}

//this is just a display of the empty board used in the first round
class Display
{
    public void display()
    {
        for (int i = 1; i < 43; i++)
        {
            
            if (i == 1){
                Console.WriteLine("_____________________________");
            }
                Console.Write($"|   ");
            if (i % 7 == 0){
            Console.WriteLine("|\n_____________________________");
            }
            if (i == 42) {
            Console.WriteLine("  1   2   3   4   5   6   7   ");
            }
        }
    }
}