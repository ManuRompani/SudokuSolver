using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolution.Modelo
{
    public class Tablero
    {
        private const int filas = 9;
        private const int columnas = 9;

        public int[,] tablero = new int[filas, columnas];
        public int[,] tableroResuelto = new int[filas, columnas];

        public string mission { get; set; }
        public string solution { get; set; }

        public void ConstruirMatriz()
        {
            int cont = 0;
            for (int i = 0; i < filas; i++)
            {
                for (int j = 0; j < columnas; j++)
                {
                    tablero[i, j] = int.Parse(mission[cont].ToString());
                    cont++;
                }
            }
        }

        public void ConstruirSolucion()
        {
            int cont = 0;
            for (int i = 0; i < filas; i++)
            {
                for (int j = 0; j < columnas; j++)
                {
                    tableroResuelto[i, j] = int.Parse(solution[cont].ToString());
                    cont++;
                }
            }
        }

        public void Solucion()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < filas; i++)
            {
                if (i % 3 == 0 && i != 0)
                {
                    sb.Append("      ");
                    sb.AppendLine(new string('-', 21));  // Línea separadora
                }

                sb.Append("      ");

                for (int j = 0; j < columnas; j++)
                {
                    sb.Append(tableroResuelto[i, j] == 0 ? "x" : tableroResuelto[i, j].ToString());

                    if (j < columnas - 1)
                    {
                        sb.Append((j + 1) % 3 == 0 ? " | " : " ");
                    }
                }

                sb.AppendLine();
            }

            Console.Write(sb.ToString());
        }

        public void Dibujar()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < filas; i++)
            {
                if (i % 3 == 0 && i != 0)
                {
                    sb.Append("      ");
                    sb.AppendLine(new string('-', 21));  // Línea separadora
                }

                sb.Append("      ");

                for (int j = 0; j < columnas; j++)
                {
                    sb.Append(tablero[i, j] == 0 ? "x" : tablero[i, j].ToString());

                    if (j < columnas - 1)
                    {
                        sb.Append((j + 1) % 3 == 0 ? " | " : " ");
                    }
                }

                sb.AppendLine();
            }

            Console.Write(sb.ToString());
        }
    }
}
