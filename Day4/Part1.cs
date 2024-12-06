namespace Day4;

public class Part1(string inputFileName)
{
    private string[] WordSearch { get; set; } = File.ReadAllLines(inputFileName);
    private string WordToFind { get; } = "XMAS";

    public int Resolve()
    {
        var result = 0;
        for (var y = 0; y < WordSearch.Length; y++)
        {
            for (var x = 0; x < WordSearch[y].Length; x++)
            {
                if (WordSearch[y][x] != 'X')
                {
                    continue;
                }

                var t = new List<bool>
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
                result += t.Count(e => e);
            }
        }

        return result;
    }

    private bool CheckBottomRight(int x, int y)
    {
        if (x + WordToFind.Length > WordSearch[y].Length || y + WordToFind.Length > WordSearch.Length)
        {
            return false;
        }

        for (var i = 0; i < WordToFind.Length; i++)
        {
            if (WordSearch[y + i][x + i] != WordToFind[i])
            {
                return false;
            }
        }

        return true;
    }

    private bool CheckBottomLeft(int x, int y)
    {
        if (x - WordToFind.Length < 0 || y + WordToFind.Length > WordSearch.Length)
        {
            return false;
        }

        for (var i = 0; i < WordToFind.Length; i++)
        {
            if (WordSearch[y + i][x - i] != WordToFind[i])
            {
                return false;
            }
        }

        return true;
    }

    private bool CheckTopRight(int x, int y)
    {
        if (x + WordToFind.Length > WordSearch[y].Length || y - WordToFind.Length < 0)
        {
            return false;
        }

        for (var i = 0; i < WordToFind.Length; i++)
        {
            if (WordSearch[y - i][x + i] != WordToFind[i])
            {
                return false;
            }
        }

        return true;
    }

    private bool CheckTopLeft(int x, int y)
    {
        if (x - WordToFind.Length + 1 < 0 || y - WordToFind.Length < 0)
        {
            return false;
        }

        for (var i = 0; i < WordToFind.Length; i++)
        {
            if (WordSearch[y - i][x - i] != WordToFind[i])
            {
                return false;
            }
        }

        return true;
    }

    private bool CheckLeft(int x, int y)
    {
        if (x - WordToFind.Length < 0)
        {
            return false;
        }

        for (var i = 0; i < WordToFind.Length; i++)
        {
            if (WordSearch[y][x - i] != WordToFind[i])
            {
                return false;
            }
        }

        return true;
    }

    private bool CheckRight(int x, int y)
    {
        if (x + WordToFind.Length > WordSearch[y].Length)
        {
            return false;
        }

        for (var i = 0; i < WordToFind.Length; i++)
        {
            if (WordSearch[y][x + i] != WordToFind[i])
            {
                return false;
            }
        }

        return true;
    }

    private bool CheckBottom(int x, int y)
    {
        if (y + WordToFind.Length > WordSearch.Length)
        {
            return false;
        }

        for (var i = 0; i < WordToFind.Length; i++)
        {
            if (WordSearch[y + i][x] != WordToFind[i])
            {
                return false;
            }
        }

        return true;
    }

    private bool CheckTop(int x, int y)
    {
        if (y - WordToFind.Length < 0)
        {
            return false;
        }

        for (var i = 0; i < WordToFind.Length; i++)
        {
            if (WordSearch[y - i][x] != WordToFind[i])
            {
                return false;
            }
        }

        return true;
    }
}