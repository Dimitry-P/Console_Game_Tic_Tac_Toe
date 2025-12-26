using System;
using static System.Net.Mime.MediaTypeNames;

class Program
{
    static void DrawCross(int x, int y, int size)
    {
        // Метод, рисующий крестик
        int m = 0;
        m = x;
        for (int i = 0; i < 8; i++)
        {
            Console.SetCursorPosition(x, y);
            Console.Write("█");
            Console.SetCursorPosition((m + size) - i, y);
            Console.Write("█");
            x++;
            y++;
        }
    }

    static void DrawRectangle(int x, int y, int size)
    {
        // Метод, рисующий нолик
        for (int i = x; i <= x + size; i++)
        {
            for (int j = y; j <= y + size; j++)
            {
                if (i == x || i == x + size || j == y || j == y + size)
                {
                    Console.SetCursorPosition(i, j);
                    Console.Write("█");
                }
            }
        }
    }

    // Метод, рисующий поле
    static void DrawField(int width, int height, int cellSize)
    {
        for (int i = 0; i < width; i += cellSize)
        {
            for (int j = 0; j < height; j++)
            {
                Console.SetCursorPosition(i, j);
                Console.Write("█");
            }
        }

        for (int i = 0; i < width; i += cellSize)
        {
            for (int j = 0; j < height; j++)
            {
                Console.SetCursorPosition(j, i);
                Console.Write("█");
            }
        }
    }

    // Метод, рисующий цифры
    static void DrawNumbers(int x, int y, int gapSize)
    {
        int number = 1;
        for (int j = y; j <= 23; j += 11)
        {
            for (int i = x; i <= 28; i += gapSize)
            {
                Console.SetCursorPosition(i, j);
                Console.Write(number++);
            }
        }
    }

    // Отображение истории ходов

    static void History(int vivod, int n)
    {
        string word = "";
        if (n % 2 == 0)
        {
            word = " ноликом";
        }
        else
        {
            word = " крестиком";
        }
        Console.SetCursorPosition(35, 1 + n);
        Console.WriteLine("Вами был сделан следующий ход: " + vivod + word);
    }

    static void Main(string[] args)
    {
        Console.SetWindowSize(90, 34);
        Console.SetBufferSize(90, 34);

        DrawField(34, 34, 11);
        DrawNumbers(6, 1, 11);
        //DrawCross(50, 50, 7);
        //DrawRectangle(50, 50, 7);

        //Главный цикл игр
        int choiseOfFigure = 0;
        int c1, c2, c3, c4, c5, c6, c7, c8, c9;
        c1 = -22; c2 = -23; c3 = -24; c4 = -25; c5 = -26; c6 = -27; c7 = -28; c8 = -29; c9 = -30;
        int win = -1;
        int input;
        int n = 0;

        for (int i = 0; i < 9; i++)
        {
            n++;
            // Пользовательский ввод
            Console.SetCursorPosition(35, 0);
            Console.Write("                                                      ");
            Console.SetCursorPosition(35, 0);
            Console.Write("Введите номер клетки: ");

            //Проверка корректности ввода:
            bool ErrorInput = !int.TryParse(Console.ReadLine(), out input);
            History(input, n);

            if (input > 9 || input < 1) ErrorInput = true;
            if (input == 1 && c1 >= 0) ErrorInput = true;
            if (input == 2 && c2 >= 0) ErrorInput = true;
            if (input == 3 && c3 >= 0) ErrorInput = true;
            if (input == 4 && c4 >= 0) ErrorInput = true;
            if (input == 5 && c5 >= 0) ErrorInput = true;
            if (input == 6 && c6 >= 0) ErrorInput = true;
            if (input == 7 && c7 >= 0) ErrorInput = true;
            if (input == 8 && c8 >= 0) ErrorInput = true;
            if (input == 9 && c9 >= 0) ErrorInput = true;

            if (ErrorInput == true)
            {
                i--;
                continue;
            }

            // Определение куда поставить фигуру
            int xx = 0;
            int yy = 0;
            if (input == 1) Console.SetCursorPosition(xx = 2, yy = 2);
            if (input == 2) Console.SetCursorPosition(xx = 13, yy = 2);
            if (input == 3) Console.SetCursorPosition(xx = 24, yy = 2);
            if (input == 4) Console.SetCursorPosition(xx = 2, yy = 13);
            if (input == 5) Console.SetCursorPosition(xx = 13, yy = 13);
            if (input == 6) Console.SetCursorPosition(xx = 24, yy = 13);
            if (input == 7) Console.SetCursorPosition(xx = 2, yy = 24);
            if (input == 8) Console.SetCursorPosition(xx = 13, yy = 24);
            if (input == 9) Console.SetCursorPosition(xx = 24, yy = 24);
            if (choiseOfFigure % 2 == 0)
            {
                DrawCross(xx, yy, 7);
            }
            else
            {
                DrawRectangle(xx, yy, 7);
            }
            choiseOfFigure++;

            // Определение кто победил

            if (input == 1) c1 = i % 2;
            if (input == 2) c2 = i % 2;
            if (input == 3) c3 = i % 2;
            if (input == 4) c4 = i % 2;
            if (input == 5) c5 = i % 2;
            if (input == 6) c6 = i % 2;
            if (input == 7) c7 = i % 2;
            if (input == 8) c8 = i % 2;
            if (input == 9) c9 = i % 2;

            if (c1 == c2 && c2 == c3) win = c2;
            if (c4 == c5 && c5 == c6) win = c5;
            if (c7 == c8 && c8 == c9) win = c8;
            if (c1 == c4 && c4 == c7) win = c7;
            if (c2 == c5 && c5 == c8) win = c5;
            if (c3 == c6 && c6 == c9) win = c6;
            if (c1 == c5 && c5 == c9) win = c5;
            if (c3 == c5 && c5 == c7) win = c5;

            if (win == 0)
            {
                Console.SetCursorPosition(35, 0);
                Console.Write("                                                      ");
                Console.SetCursorPosition(35, 0);
                Console.Write("Победили крестики");
                break;
            }
            if (win == 1)
            {
                Console.SetCursorPosition(35, 0);
                Console.Write("                                                      ");
                Console.SetCursorPosition(35, 0);
                Console.Write("Победили нолики");
                break;
            }
            // Определение какую фигуру рисовать и отрисовка
        }

        if (win == -1)
        {
            Console.SetCursorPosition(35, 0);
            Console.Write("                                                      ");
            Console.SetCursorPosition(35, 0);
            Console.Write("Ничья!!!");
        }
        Console.ReadLine();
    }
}
