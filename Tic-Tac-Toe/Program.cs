string[,] array2d = new string[,]
{
    {
        "#","#","#"
    },
    {
      "#","#","#"
    },
    {
       "#","#","#"
    },
};
void ShowVisual(string[,] array2d)
{
    Console.WriteLine("     |     |     ");
    Console.WriteLine("  {0}  |  {1}  |  {2}  ", array2d[0,0], array2d[0, 1], array2d[0, 2]);
    Console.WriteLine("_____|_____|_____");
    Console.WriteLine("     |     |     ");
    Console.WriteLine("  {0}  |  {1}  |  {2}  ", array2d[1, 0], array2d[1, 1], array2d[1, 2]);
    Console.WriteLine("_____|_____|_____");
    Console.WriteLine("     |     |     ");
    Console.WriteLine("  {0}  |  {1}  |  {2}  ", array2d[2, 0], array2d[2, 1], array2d[2, 2]);
    Console.WriteLine("     |     |     ");
}
ShowVisual(array2d);
int count = 0;
bool gameOver = false;
string memory = "";
string[] cantBeTypes = new string[] {};
bool checkGameOver(string player)
{
    for (int i = 0, j = 0; i < array2d.GetLength(0); i++)
    {
        if (array2d[i, j] != "#")
        {
            if (array2d[i, j] == array2d[i, j + 1] && (array2d[i, j] == array2d[i, j + 2]))
            {
                gameOver = true;
                Console.WriteLine(player+" Win");
            }
            else if (array2d[j, i] == array2d[j + 1, i] && (array2d[j, i] == array2d[j + 2, i]) && array2d[j, i] != "#")
            {

                gameOver = true;
                Console.WriteLine(player + " Win");

            }
            else
            {
                if ((array2d[0, 2] == array2d[1, 1]) && (array2d[0, 2] == array2d[2, 0]) && array2d[0, 2] != "#")
                {
                    gameOver = true;
                    Console.WriteLine(player + " Win");
                }

                else if (array2d[0, 0] == array2d[1, 1] && array2d[1, 1] == array2d[2, 2] && array2d[1, 1] != "#")
                {
                    gameOver = true;
                    Console.WriteLine(player + " Win");
                }

            }
        }
    }
    if (gameOver)
    {
        return true;
    }
    else return false;
}

while (count < 9 && !gameOver)
{
    if (count % 2 == 0)
    {
        Console.WriteLine("Player 1 : Choose Your Field ");
       
        string field=Console.ReadLine();
        if (!cantBeTypes.Contains(field))
        {
            var tempList = cantBeTypes.ToList();
            tempList.Add(field);
            cantBeTypes = tempList.ToArray();  
            int f = int.Parse(field);
            int row = (f - 1) / 3;
            int column = (f - 1) % 3;
            array2d[row, column] = "O";
            ShowVisual(array2d);
            gameOver = checkGameOver("Player 1");
            count++;
        }
        else if (cantBeTypes.Contains(field))
        {
            Console.WriteLine("Wrong Field");
        }
        
    }
    else if (count % 2 != 0)
    {
        Console.WriteLine("Player 2 : Choose Your Field ");
        string field = Console.ReadLine();
        
        if (!cantBeTypes.Contains(field))
        {
            var tempList = cantBeTypes.ToList();
            tempList.Add(field);
            cantBeTypes = tempList.ToArray();
            int f = int.Parse(field);
            int row = (f - 1) / 3;
            int column = (f - 1) % 3;
            array2d[row, column] = "X";
            ShowVisual(array2d);
            gameOver = checkGameOver("Player 2");
            count++;
        }
       else if (cantBeTypes.Contains(field))
        {
            Console.WriteLine("Wrong Field");
        }
    }
    
}

if(count==9 && !gameOver)
{
    Console.WriteLine("Game Draw");
}


