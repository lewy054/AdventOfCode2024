namespace Infrastructure;

public class WordSearch(string[] input)
{
    public int GetWordOccurrencesInAllDimensions(int x, int y, string wordToFind)
    {
        var results = new List<bool>()
        {
            CheckTop(x, y, wordToFind),
            CheckBottom(x, y, wordToFind),
            CheckRight(x, y, wordToFind),
            CheckLeft(x, y, wordToFind),
            CheckTopLeft(x, y, wordToFind),
            CheckTopRight(x, y, wordToFind),
            CheckBottomLeft(x, y, wordToFind),
            CheckBottomRight(x, y, wordToFind),
        };
        return results.Count(e => e);
    }

    /// <summary>
    /// Finds word in X shape e.g.
    /// M.S
    /// .A.
    /// M.S
    /// where word is MAS 
    /// </summary>
    /// <param name="x">Horizontal point to start search</param>
    /// <param name="y">Vertical point to start search</param>
    /// <param name="wordToFind"></param>
    /// <returns></returns>
    public int  GetWordOccurrencesInXShape(int x, int y, string wordToFind)
    {
        if (wordToFind.Length % 3 != 0)
        {
            throw new InvalidDataException();
        }

        var placeToCut = wordToFind.Length / 2;
        var firstHalf = string.Join("", wordToFind[..(placeToCut+1)].Reverse());
        var secondHalf = wordToFind[placeToCut..];

        if (CheckTopLeft(x, y, firstHalf) && CheckTopRight(x, y, firstHalf) &&
            CheckBottomLeft(x, y, secondHalf) && CheckBottomRight(x, y, secondHalf))
        {
            // M.M
            // .A.
            // S.S
            return 1;
        }

        if (CheckTopLeft(x, y, secondHalf) && CheckTopRight(x, y, secondHalf) &&
            CheckBottomLeft(x, y, firstHalf) && CheckBottomRight(x, y, firstHalf))
        {
            // S.S
            // .A.
            // M.M
            return 1;
        }
        
        
        if (CheckTopLeft(x, y, firstHalf) && CheckTopRight(x, y, secondHalf) &&
            CheckBottomLeft(x, y, firstHalf) && CheckBottomRight(x, y, secondHalf))
        {
            // M.S
            // .A.
            // M.S
            return 1;
        }
        
        if (CheckTopLeft(x, y, secondHalf) && CheckTopRight(x, y, firstHalf) &&
            CheckBottomLeft(x, y, secondHalf) && CheckBottomRight(x, y, firstHalf))
        {
            // S.M
            // .A.
            // S.M
            return 1;
        }

        return 0;
    }

    private bool CheckBottomRight(int x, int y, string wordToFind)
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

    private bool CheckBottomLeft(int x, int y, string wordToFind)
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

    private bool CheckTopRight(int x, int y, string wordToFind)
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

    private bool CheckTopLeft(int x, int y, string wordToFind)
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

    private bool CheckLeft(int x, int y, string wordToFind)
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

    private bool CheckRight(int x, int y, string wordToFind)
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

    private bool CheckBottom(int x, int y, string wordToFind)
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

    private bool CheckTop(int x, int y, string wordToFind)
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