using System;
public class Board
{ 
    static public void Write(int Width, int Height)
    {
        for (int i = 1; i <= Width; i++)
        {
            WriteChar(i, 0, '─');
            WriteChar(i, (Height + 1), '─');
        }
        for (int i = 1; i <= (Height); i++)
        {
            WriteChar(0, i, '│');
            WriteChar((Width + 1), i, '│');
        }

        WriteChar(0, 0, '┌');
        WriteChar((Width + 1), 0, '┐');
        WriteChar(0, (Height + 1), '└');
        WriteChar((Width + 1), (Height + 1), '┘');
    }

    static void WriteChar(int x,int y, char znak)
    {
        Console.SetCursorPosition(x, y);
        Console.Write(znak);
    }
}