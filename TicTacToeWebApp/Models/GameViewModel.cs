namespace TicTacToeWebApp.Models
{
    public class GameViewModel
    {
        public PlayerViewModel Player1 { get; set; }
        public PlayerViewModel Player2 { get; set; }
        public int BoardSize { get; set; }
        public string Board { get; set; }
        public double Grid { get; set; }
        public int Attempts { get; set; }

        public GameViewModel(PlayerViewModel player1, PlayerViewModel player2, int boardsize, double grid, string board, int attempts)
        {
            Player1 = player1;
            Player2 = player2;
            BoardSize = boardsize;
            Board = board;
            Grid = grid;
            Attempts = attempts;
        }

        private void SetXO(int idx, char val)
        {
            if (Board[idx] != 'X' && Board[idx] != 'O')
                Board = Board.Remove(idx, 1).Insert(idx, val.ToString());
        }

        public bool IsWinner(char ch)
        {
            bool result = false;
            int i = 0;
            int jump = (int)Grid - 1;
            

            for(int j=0; j<BoardSize; j+=(int)Grid) {

                bool[] temp = new bool[(int)Grid];
                for (int k = 0; k < Grid; k++)
                {
                    if (Board[k + j] == ch)
                        temp[k] = true;
                    
                }

                int count = 0;
                foreach(var item in temp)
                {
                    if(item == true)
                        count++;
                }

                if (count == Grid)
                {
                    result = true;
                    break;
                }
                   
            }

            if (result == false)
            {
                
                for(int k = 0; k < Grid; k++)
                {
                    int inx = 0;
                    bool[] temp = new bool[(int)Grid];
                    for (int j=0; j<BoardSize; j += (int)Grid)
                    {
                        if (Board[k + j] == ch)
                        {
                            temp[inx] = true;
                            inx++;
                        }
                    }

                    int count = 0;
                    foreach (var item in temp)
                    {
                        if (item == true)
                            count++;
                    }

                    if (count == Grid)
                    {
                        result = true;
                    }
                }
                
                
            }

            if (result == false)
            {

                
                int diag = (int)Grid + 1;
                for (int k = 0; k < Grid; k++)
                {
                    int inx = 0;
                    bool[] temp = new bool[(int)Grid];
                    
                    for (int j = 0; j < BoardSize; j += diag)
                    {
                        if(k+j < BoardSize)
                        {
                            if (Board[k + j] == ch)
                            {
                                
                                temp[inx] = true;
                                inx++;

                                if (k + j == (int)Grid - 1)
                                    diag-=2;
                                
                            }
                        }
                        
                    }

                    int count = 0;
                    foreach (var item in temp)
                    {
                        if (item == true)
                            count++;
                    }

                    if (count == Grid)
                    {
                        result = true;
                    }
                    
                    
                }


            }

            return result;
        }
        public void Update(int? id)
        {
            if (Board[id.Value] != 'X' && Board[id.Value] != 'O')
            {
                if (Attempts % 2 == 0)
                {
                    SetXO(id.Value, 'X');
                    ++Attempts;
                }
                else
                {
                    SetXO(id.Value, 'O');
                    ++Attempts;
                }
            }
        }
        public void Reset()
        {
            Board = "";
            for (int i = 0; i < BoardSize; i++)
            {
                Board += "_";
            }
            Attempts = 0;
            Player1.NumOfWins = Player2.NumOfWins = 0;
        }
    }
}