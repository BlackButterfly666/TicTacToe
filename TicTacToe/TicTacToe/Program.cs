using System;

namespace TicTacToe
{
	public class Program
	{
		public static void Main()
		{
			bool player = true;
			int flag = 0;
			int turn = 0;
			char[,] field = { { '1', '2', '3' }, { '4', '5', '6' }, { '7', '8', '9' } };

			while (true)
			{
				// -----> Field building
				{
					Console.Clear();
					Console.ForegroundColor = ConsoleColor.White;
					Console.WriteLine("Ziel des Spiels ist es 3 'X' oder 'O' in einer Reihe, Spalte oder Diagonal zu belegen.");

					Console.WriteLine();
					Console.ForegroundColor = ConsoleColor.DarkGreen;
					Console.WriteLine("     |     |      ");
					Console.WriteLine("  {0}  |  {1}  |  {2}", field[0, 0], field[0, 1], field[0, 2]);
					Console.WriteLine("_____|_____|_____ ");
					Console.WriteLine("     |     |      ");
					Console.WriteLine("  {0}  |  {1}  |  {2}", field[1, 0], field[1, 1], field[1, 2]);
					Console.WriteLine("_____|_____|_____ ");
					Console.WriteLine("     |     |      ");
					Console.WriteLine("  {0}  |  {1}  |  {2}", field[2, 0], field[2, 1], field[2, 2]);
					Console.WriteLine("     |     |      ");
					Console.WriteLine("Turn: " + turn);
				}

				// -----> Player swap, parse input for each player, count turns
				player = !player; // player = Spieler 1 & !player = Spieler 2

				do
				{
					if (player)
					{
						Console.WriteLine("Hallo Spieler 2, bitte wähle dein Feld");
						Console.WriteLine("Feldwahl per Zahleneingabe und Bestätigung mit 'Enter'.");

						if (int.TryParse(Console.ReadLine(), out int result) && result >= 1 && result <= 9)
						{
							int x = (result - 1) / 3;
							int y = (result - 1) % 3;

							if (field[x, y] != 'X' && field[x, y] != 'O')
							{
								field[x, y] = 'X';
								flag = 0;
							}
							else
							{
								Console.WriteLine("Das Feld ist bereits belegt. Bitte wähle ein neues");
								flag = 1;
							}
						}
						else
						{
							Console.WriteLine("Bitte wähle eine Zahl und kein anderes Zeichen");
							flag = 1;
						}

					}
					else
					{
						Console.WriteLine("Hallo Spieler 1, bitte wähle dein Feld");
						Console.WriteLine("Feldwahl per Zahleneingabe und Bestätigung mit 'Enter'.");

						if (int.TryParse(Console.ReadLine(), out int result) && result >= 1 && result <= 9)
						{
							int x = (result - 1) / 3;
							int y = (result - 1) % 3;
							if (field[x, y] != 'X' && field[x, y] != 'O')
							{
								field[x, y] = 'O';
								flag = 0;
							}
							else
							{
								Console.WriteLine("Das Feld ist bereits belegt. Bitte wähle ein neues");
								flag = 1;
							}

						}
						else
						{
							Console.WriteLine("Bitte wähle eine Zahl und kein anderes Zeichen");
							flag = 1;
						}
					}
				} while (flag == 1);

				turn++; // Jeden gültigen Spielzug mitzählen

				// -----> Win Check Player 'O'
				if (((field[0, 0] & field[0, 1] & field[0, 2]) == 'O') ||
						((field[1, 0] & field[1, 1] & field[1, 2]) == 'O') ||
						((field[2, 0] & field[2, 1] & field[2, 2]) == 'O') ||

						((field[0, 0] & field[1, 0] & field[2, 0]) == 'O') ||
						((field[0, 1] & field[1, 1] & field[2, 1]) == 'O') ||
						((field[0, 2] & field[1, 2] & field[2, 2]) == 'O') ||

						((field[0, 0] & field[1, 1] & field[2, 2]) == 'O') ||
						((field[2, 0] & field[1, 1] & field[0, 2]) == 'O'))
				{
					Console.WriteLine("\nSpieler 1 hat gewonnen!");
					Console.ReadLine();

					while (true)
					{
						Console.WriteLine("Wiederholen? j/n");
						var info = Console.ReadKey();
						if (info.KeyChar == 'j') { Main(); }
						else if (info.KeyChar != 'n' && info.KeyChar != 'j') { Console.WriteLine("Bitte wiederhole deine Eingabe."); }
						else { return; }
					}
				} // -----> Win Check Player 'X'
				else if (((field[0, 0] & field[0, 1] & field[0, 2]) == 'X') ||
						((field[1, 0] & field[1, 1] & field[1, 2]) == 'X') ||
						((field[2, 0] & field[2, 1] & field[2, 2]) == 'X') ||

						((field[0, 0] & field[1, 0] & field[2, 0]) == 'X') ||
						((field[0, 1] & field[1, 1] & field[2, 1]) == 'X') ||
						((field[0, 2] & field[1, 2] & field[2, 2]) == 'X') ||

						((field[0, 0] & field[1, 1] & field[2, 2]) == 'X') ||
						((field[2, 0] & field[1, 1] & field[0, 2]) == 'X'))
				{
					Console.WriteLine("\nSpieler 2 hat gewonnen!");
					Console.ReadLine();

					while (true)
					{
						Console.WriteLine("Wiederholen? j/n");
						var info = Console.ReadKey();
						if (info.KeyChar == 'j') { Main(); }
						else if (info.KeyChar != 'n' && info.KeyChar != 'j') { Console.WriteLine("Bitte wiederhole deine Eingabe."); }
						else { return; }
					}
				} // -----> Win Check Unentschieden
				else if (turn == 9)
				{
					Console.WriteLine("\nUnentschieden!");
					Console.ReadLine();
					while (true)
					{
						Console.WriteLine("Wiederholen? j/n");
						var info = Console.ReadKey();
						if (info.KeyChar == 'j') { Main(); }
						else if (info.KeyChar != 'n' && info.KeyChar != 'j') { Console.WriteLine("Bitte wiederhole deine Eingabe."); }
						else { return; }
					}
				}
			}
		}
	}
}
