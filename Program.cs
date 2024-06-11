namespace TicTacToeProject {
    internal class Program {
        static void Main(string[] args) {


            //funciotn being call

            TicTacToeProject();

            //SPACE
            space(4);

        }//end main

        static void TicTacToeProject() {
            //VARAIABLES
            string[,] TicTacToeBoard = new string[3, 3];
            TicTacToeBoard = CreateBoard();
            int currentPlayer = 1; // Player 1 starts (X)
            bool gameEnded = false;

            while (gameEnded == false) {
                Console.Clear();
                ColorText("===============================\n-------------------------------\n\tTic-Tac-Toe Game\n-------------------------------\n===============================\n", ConsoleColor.Cyan);
                for (int chose = 1; chose < 10; chose++) {

                    //loop to when they enter wrong it start agian here 
                    if (currentPlayer == 1) {
                        Console.ForegroundColor = ConsoleColor.Red;
                    } if (currentPlayer == 2) {
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                    }//end if for collor

                    // Display the current player's turn
                    Console.WriteLine($"\nPlayer {currentPlayer}: {(currentPlayer == 1 ? "X" : "O")}\n");
                    Console.ResetColor();
                    DisplayBoard(TicTacToeBoard);

                    // Get user input for row and column
                    Console.ForegroundColor = ConsoleColor.White;
                    int col = PromptIntTry("\nEnter col (left to right)(0,1,2) :");
                    int row = PromptIntTry("Enter row (up to down)(0,1,2)    :");
                    Console.ResetColor();

                    if ((row == 0 || row == 1 || row == 2) && (col == 0 || col == 1 || col == 2)) {
                        // Check if the chosen cell is empty
                        if (TicTacToeBoard[col, row] == "*") {
                            TicTacToeBoard[col, row] = (currentPlayer == 1) ? "X" : "O";
                            currentPlayer = (currentPlayer == 1) ? 2 : 1;
                            Console.Clear();
                        } else {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine("That cell is already taken. Try again.");
                            chose--;
                            Console.ResetColor();
                        }//end if else to right "X" or "O" and check if that spote is taken
                    }else {
                        Console.Clear();
                        ColorText("ERROR!!!!\nPlease enter a 0,1,or 2\n", ConsoleColor.Magenta);
                        chose--;
                    }//end if else to determing good input

                    //check wins and tie 
                    if (CheckWin(TicTacToeBoard)) {
                        Console.Clear();
                        DisplayBoard(TicTacToeBoard);
                        Console.WriteLine($"\nPlayer {(currentPlayer == 1 ? "O" : "X")} wins!");

                        //char that ask if they wnat to play agian 
                        ColorText("Do you want to play agian?", ConsoleColor.DarkYellow);
                        Console.Write(" (y/n): ");

                        if (Console.ReadKey().KeyChar.ToString().ToLower() == "y") {
                            for (int y = 0; y < TicTacToeBoard.GetLength(1); y++) {
                                for (int x = 0; x < TicTacToeBoard.GetLength(0); x++) {
                                    TicTacToeBoard[x, y] = "*";
                                }//end for x
                            }//end for y
                            break;
                        }if (Console.ReadKey().KeyChar.ToString().ToLower() == "n") {
                            gameEnded = true;
                        }else {
                            for (int y = 0; y < TicTacToeBoard.GetLength(1); y++) {
                                for (int x = 0; x < TicTacToeBoard.GetLength(0); x++) {
                                    TicTacToeBoard[x, y] = "*";
                                }//end for x
                            }//end for y
                            break;
                        }//end if else to end game
                    }//end if Check Win
                    else if (IsTie(TicTacToeBoard)) {
                        Console.Clear();
                        DisplayBoard(TicTacToeBoard);
                        Console.WriteLine("\nIt's a tie!");

                        //char that ask if they wnat to play agian 
                        ColorText("Do you want to play agian?", ConsoleColor.DarkYellow);
                        Console.Write(" (y/n): ");

                        if (Console.ReadKey().KeyChar.ToString().ToLower() == "y") {
                            for (int y = 0; y < TicTacToeBoard.GetLength(1); y++) {
                                for (int x = 0; x < TicTacToeBoard.GetLength(0); x++) {
                                    TicTacToeBoard[x, y] = "*";
                                }//end for x
                            }//end for y
                            break;
                        }if (Console.ReadKey().KeyChar.ToString().ToLower() == "n") {
                            gameEnded = true;
                        }else {
                            for (int y = 0; y < TicTacToeBoard.GetLength(1); y++) {
                                for (int x = 0; x < TicTacToeBoard.GetLength(0); x++) {
                                    TicTacToeBoard[x, y] = "*";
                                }//end for x
                            }//end for y
                            break;
                        }//end if else to end game
                    }//end if tie
                }//end for to loop 
            }//end while loop 
        }//end funtion


        static void DisplayBoard(string[,] board) {
            //for loop to white the sting
            for (int y = 0; y < board.GetLength(1); y++) {
                for (int x = 0; x < board.GetLength(0); x++) {
                    if (x == 0) {
                        Console.Write("\t ");
                    }if (board[x, y] == "X" || board[x,y] == "x"){
                        Console.ForegroundColor = ConsoleColor.Red;
                    }if (board[x, y] == "O" || board[x,y] == "o") {
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                    }//end if tree
                    Console.Write(board[x, y]);
                    Console.ResetColor();
                    if (x != 2) {
                        Console.Write(" | ");
                    }//en if to " | "
                }//end x
                if (y != 2) {
                    Console.WriteLine("\n\t---|---|---");
                }//end if to draw lines
            }//end y
            space(1);
        }//end funciton display board

        static string[,] CreateBoard() {
            string[,] board = new string[3, 3];
            Console.Clear();
            //for loop to white the sting
            for (int y = 0; y < board.GetLength(1); y++) {
                for (int x = 0; x < board.GetLength(0); x++) {
                    board[x, y] = "*";
                }//end x
            }//end y
            return board;
        }//end function


        static bool CheckWin(string[,] board) {
            for (int y = 0; y < board.GetLength(1); y++) {
                for (int x = 0; x < board.GetLength(0); x++) {
                    if ((board[x, 0] != "*" ) && board[x, 0] == board[x, 1] && board[x, 1] == board[x, 2]) {
                        Console.Clear();
                        return true;
                    }//end if
                    if ((board[0, y] != "*" ) && board[0, y] == board[1, y] && board[1, y] == board[2, y]) {
                        Console.Clear();
                        return true;
                    }//end if
                }//end for x
            }//end for y
            if ((board[0, 0] != "*" ) && board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2]) {
                Console.Clear() ;
                return true;
            }//end if diagnal
            if ((board[0, 2] != "*" ) && board[0, 2] == board[1, 1] && board[1, 1] == board[0, 0]) {
                Console.Clear() ;
                return true;
            }//end if diagnal
            return false;
        }//end funciton

        static bool IsTie(string[,]board) {
            for (int y = 0;y<board.GetLength(1);y++) {
                for (int x = 0; x<board.GetLength(0);x++) {
                    if (board[x,y] == "*" ) { 
                        return false;
                    }//end if
                }//end x
            }//end y
            return true;
        }//end bool is tie


        static void space (int num) {
            for (int i = 0; i < num; i++) {
                Console.WriteLine();
            }//end for 
        }//end fucntion



        #region ColorFullMonths
        static void RainFallColorfulDays() {
            //variables
            string[] days = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
            string[] months = { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };
            ConsoleColor[] colors = { ConsoleColor.Blue, ConsoleColor.Red, ConsoleColor.Green, ConsoleColor.Cyan, ConsoleColor.White, ConsoleColor.DarkCyan, ConsoleColor.DarkRed, ConsoleColor.DarkGray, ConsoleColor.Yellow, ConsoleColor.Magenta, ConsoleColor.DarkYellow, ConsoleColor.DarkGreen };
            double[] monthlyRain;
            double avgRainfall = 0;
            double totalRain = 0;
            int years = 0;
            int t = 0;
            //input
            years = PromptInt("How many years will we be tracking rainfall?: ");
            Console.WriteLine();
            monthlyRain = new double[years * 12];
            ///for
            for (int y = 0; y < years; y++) {
                for (int m = 0; m < 12; m++) {
                    //input
                    monthlyRain[t] = ColorTextDoulbe($"What was rain in month {months[m]}: ", colors[m]);
                    totalRain += monthlyRain[t++];
                    Console.WriteLine();
                }//end month for loop
            }//end  year for loop
            avgRainfall = totalRain / (years * 12);
            Console.WriteLine($"The average monthly rainfall for {years} years was {avgRainfall}\nTotal Rain Fall {totalRain}");
        }//end fucnton

        #endregion



        #region COLOR TEXT, INT, DOUBLE 

        static string ColorText(string message, ConsoleColor color) {
            string value = "";
            Console.ForegroundColor = color;
            Console.Write(message);
            Console.ResetColor();
            //value = Console.ReadLine();
            //return
            return value;
        }//end funciton


        static int ColorTextInt(string messege, ConsoleColor color) {
            int value = 0;
            Console.ForegroundColor = color;
            Console.Write(messege);
            Console.ResetColor();
            value = int.Parse(Console.ReadLine());
            //return
            return value;

        }//end funciton


        static double ColorTextDoulbe(string messege, ConsoleColor color) {
            double value = 0.0;
            Console.ForegroundColor = color;
            Console.Write(messege);
            Console.ResetColor();
            value = double.Parse(Console.ReadLine());
            //return
            return value;
        }//end funciton

        #endregion



        #region COLORFUL DAYS
        static void ColorfulDays() {
            string[] days = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
            ConsoleColor[] colors = { ConsoleColor.Blue, ConsoleColor.DarkYellow, ConsoleColor.Red, ConsoleColor.Green, ConsoleColor.Magenta, ConsoleColor.Cyan, ConsoleColor.White };
            //for loop output
            for (int i = 0; i < days.Length; i++) {
                ColorText(days[i], colors[i]);
            }//end for
            #region USLESS TEXT
            /*
            //ouput like for but expanded
            ColorText(days[0], colors[0]);
            ColorText(days[1], colors[1]);
            ColorText(days[2], colors[2]);
            ColorText(days[3], colors[3]);
            ColorText(days[4], colors[4]);
            ColorText(days[5], colors[5]);
            ColorText(days[6], colors[6]);
            */
            /*
            //output but all writen out for show
            Console.Write("In my mind, ");
            ColorText(days[0], ConsoleColor.Blue, false);
            Console.WriteLine(" is always blue.");
            ColorText($"{days[1]} are brown for Taco {days[1]}s", ConsoleColor.DarkYellow);
            ColorText($"Red is the color of {days[2]}", ConsoleColor.Red);
            ColorText($"And {days[3]} is definitely green!", ConsoleColor.Green);
            ColorText($"{days[4]} is the last day of the work-week, so it's purple", ConsoleColor.Magenta);
            Console.BackgroundColor = ConsoleColor.White;
            ColorText($" And {days[5]}s are black", ConsoleColor.Black);
            Console.BackgroundColor = ConsoleColor.Black;
            ColorText($"Finally, {days[6]} are while because fuck you, I said so." , ConsoleColor.White);
            */
            #endregion
        }//end funciton
        #endregion



        #region TRY FUNCITON 
        // biging funciton int try
        static int PromptIntTry(string dataRequest) {

            //variabels
            int userInput = 0;
            bool isValid = false;
            //do while loop
            do {
                Console.Write(dataRequest);
                isValid = int.TryParse(Console.ReadLine(), out userInput);
            } while (isValid == false);
            //retun
            return userInput;
        }// end funtion int




        // biging funciton dulbe try
        static double PromptDoulbeTry(string dataRequest) {

            //variabels
            double userInput = 0;
            bool isValid = false;
            //do while loop
            do {
                Console.Write(dataRequest);
                isValid = double.TryParse(Console.ReadLine(), out userInput);
            } while (isValid == false);
            //retun
            return userInput;
        }// end funtion doulbe tyr
        #endregion  



        #region PROMPT FUNCTIONS

        //begin funstion string
        static string Prompt(string dataRequest) {

            //color
            //Console.ForegroundColor = ConsoleColor.Cyan;

            //variables
            string userInput = "";

            //request information from user
            Console.Write(dataRequest);

            //recive respones
            userInput = Console.ReadLine();

            //return
            return userInput;

        }//end funtion



        // biging funciton int
        static int PromptInt(string dataRequest) {

            //variabels
            int userInput = 0;

            //input
            userInput = int.Parse(Prompt(dataRequest));

            //return
            return userInput;

        }// end funtion int



        //regin funtion double
        static double PromptDouble(string dataRequest) {

            //variables 
            double userInput = 0.0;

            //input
            userInput = double.Parse(Prompt(dataRequest));

            //return
            return userInput;
        }// end funciton double 

        #endregion

    


    }//end class
}//end namespace
