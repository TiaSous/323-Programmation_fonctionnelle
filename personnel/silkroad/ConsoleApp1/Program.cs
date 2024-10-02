bool[,] silkyWay = new bool[8, 8];

silkyWay[0, 0] = true; // A1
silkyWay[7, 7] = true; // H8

void DrawBoard(bool[,] board)
{
    Console.WriteLine("  12345678");
    Console.WriteLine(" ┌────────┐");
    for (char row = 'A'; row <= 'H'; row++)
    {
        Console.Write(row + "│");
        for (int col = 1; col <= 8; col++)
        {
            if (board[row - 'A', col - 1])
            {
                Console.Write("█");
            }
            else
            {
                Console.Write(" ");
            }
        }
        Console.WriteLine("│");
    }
    Console.WriteLine(" └────────┘");
}

bool[,] AddSilk(bool[,] board)
{
    Random random = new Random();
    int x;
    int y;
    int counter = 2;
    while (counter < 28) 
    {
        x = random.Next(0, 8);
        y = random.Next(0, 8);
        if (!board[x, y]) 
        {
            board[x, y] = true;
            counter++;
        }
    }
    return board;
    
}

// TODO Put silk on 30 more squares
silkyWay = AddSilk(silkyWay);
DrawBoard(silkyWay);


// TODO Create a data structure that allow us to remember which square has already been tested
bool[,] caseTest = new bool[8, 8] ;
caseTest[0, 0] = true;
// TODO Create a data structure that allow us to remember the successful steps
bool[,] exitPath = new bool[8, 8];
exitPath[7, 7] = true;
// TODO Write the recursive function
// Recursive function that tells if we can reach H8 from the given position
// The algorithm is in fact simple to spell out (even in french ;)):
//
//      Je peux sortir depuis cette case si:
//          1. Je suis sur H8
//
//              ou
//
//          2. Je peux sortir depuis une des cases où je peux aller (et où je ne suis pas encore allé)

bool Algoritm(int x, int y)
{
    if (x == 7 &&  y == 7) return true;
    if (x < 0 || y < 0 || x > 7|| y > 7 || !silkyWay[x, y] || (caseTest[x,y] && (y != 0 || x != 0))) return false;
    caseTest[x, y] = true;
    if (Algoritm(x + 1, y) || Algoritm(x - 1, y) || Algoritm(x, y + 1) || Algoritm(x, y - 1) ||
        Algoritm(x + 1, y + 1) || Algoritm(x - 1, y - 1) || Algoritm(x - 1, y + 1) || Algoritm(x + 1, y - 1))
    {
        exitPath[x, y] = true;
        return true;
    }
    else
    {
        return false;
    }
    
}

if(Algoritm(0, 0))
{
    Console.SetCursorPosition(0, 15);
    DrawBoard(exitPath);
}

// TODO Call the function and show the results

Console.ReadLine();