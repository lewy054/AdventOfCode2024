namespace Infrastructure;

public class WordSearch(string[] input, string wordToFind)
{
    public int GetWordOccurrencesInAllDimensions(int x, int y)
    {
        var results = new List<bool>()
        {
            CheckTop(x, y),
            CheckBottom(x, y),
            CheckRight(x, y),
            CheckLeft(x, y),
            CheckTopLeft(x, y),
            CheckTopRight(x, y),
            CheckBottomLeft(x, y),
            CheckBottomRight(x, y),
        };
        return results.Count(e=> e);
    }
    
    public int GetWordOccurrencesInXShape(int x, int y)
    {
        var results = new List<bool>()
        {
            CheckTopLeft(x, y),
            CheckTopRight(x, y),
            CheckBottomLeft(x, y),
            CheckBottomRight(x, y),
        };
        if (results.Count(e => e) == 2)
        {
            return 1;
        }
        return 0;
    }
    
     private bool CheckBottomRight(int x, int y)
    {
        if (x + wordToFind.Length > input[y].Length || y + wordToFind.Length > input.Length)
        {
            return false;
        }

        for (var i = 0; i < wordToFind.Length; i++)
        {
            if (input[y + i][x + i] != wordToFind[i])
            {
                return false;
            }
        }

        return true;
    }

    private bool CheckBottomLeft(int x, int y)
    {
        if (x - wordToFind.Length + 1 < 0 || y + wordToFind.Length > input.Length)
        {
            return false;
        }

        for (var i = 0; i < wordToFind.Length; i++)
        {
            if (input[y + i][x - i] != wordToFind[i])
            {
                return false;
            }
        }

        return true;
    }

    private bool CheckTopRight(int x, int y)
    {
        if (x + wordToFind.Length > input[y].Length || y - wordToFind.Length + 1 < 0)
        {
            return false;
        }

        for (var i = 0; i < wordToFind.Length; i++)
        {
            if (input[y - i][x + i] != wordToFind[i])
            {
                return false;
            }
        }

        return true;
    }

    private bool CheckTopLeft(int x, int y)
    {
        if (x - wordToFind.Length + 1 < 0 || y - wordToFind.Length + 1 < 0)
        {
            return false;
        }

        for (var i = 0; i < wordToFind.Length; i++)
        {
            if (input[y - i][x - i] != wordToFind[i])
            {
                return false;
            }
        }

        return true;
    }

    private bool CheckLeft(int x, int y)
    {
        if (x - wordToFind.Length + 1 < 0)
        {
            return false;
        }

        for (var i = 0; i < wordToFind.Length; i++)
        {
            if (input[y][x - i] != wordToFind[i])
            {
                return false;
            }
        }

        return true;
    }

    private bool CheckRight(int x, int y)
    {
        if (x + wordToFind.Length > input[y].Length)
        {
            return false;
        }

        for (var i = 0; i < wordToFind.Length; i++)
        {
            if (input[y][x + i] != wordToFind[i])
            {
                return false;
            }
        }

        return true;
    }

    private bool CheckBottom(int x, int y)
    {
        if (y + wordToFind.Length > input.Length)
        {
            return false;
        }

        for (var i = 0; i < wordToFind.Length; i++)
        {
            if (input[y + i][x] != wordToFind[i])
            {
                return false;
            }
        }

        return true;
    }

    private bool CheckTop(int x, int y)
    {
        if (y - wordToFind.Length + 1 < 0)
        {
            return false;
        }

        for (var i = 0; i < wordToFind.Length; i++)
        {
            if (input[y - i][x] != wordToFind[i])
            {
                return false;
            }
        }

        return true;
    }
}