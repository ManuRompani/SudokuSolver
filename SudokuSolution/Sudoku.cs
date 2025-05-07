using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolution
{
    public class Sudoku
    {
        //private const int filas = 9;
        //private const int columnas = 9;

        //int[,] tablero = new int[filas, columnas];

        //public Sudoku()
        //{
        //    Get();
        //}

        //private void CrearTablero(string texto)
        //{
        //    int cont = 0;
        //    for (int i = 0; i < filas; i++)
        //    {
        //        for (int j = 0; j < columnas; j++)
        //        {
        //            tablero[i, j] = int.Parse(texto[cont].ToString());
        //            cont++;
        //        }
        //    }
        //}
        //public void ImprimirTablero()
        //{
        //    int contadorColumnas = 0;
        //    int contadorFilas = 0;

        //    for(int i=0; i<filas; i++)
        //    {
        //        contadorFilas++;
        //        for (int j=0;j<columnas; j++)
        //        {
        //            contadorColumnas++;

        //            if (j == 0)
        //            {
        //                Console.Write("      ");
        //            }

        //            if(tablero[i, j] == 0)
        //            {
        //                Console.Write("x");
        //            }
        //            else
        //            {
        //                Console.Write(tablero[i, j]);
        //            }

        //            if (j == columnas - 1)
        //            {
        //                Console.Write("\n");
        //                contadorColumnas = 0;
        //            }
        //            else if (contadorColumnas == 3)
        //            {
        //                Console.Write(" | ");
        //                contadorColumnas = 0;
        //            }
        //        }

        //        if (contadorFilas == 3 && i != filas-1)
        //        {
        //            Console.Write("      ");
        //            for (int c=0; c<columnas*14; c++)
        //            {
        //                Console.Write("-");
        //            }
        //            Console.Write("\n");
        //            contadorFilas = 0;
        //        }
        //    }
        //}

        //private void Resolver()
        //{
        //    for(int i=0; i<filas; i++)
        //    {
        //        for(int j=0; j<columnas; j++)
        //        {
        //            if (tablero[i, j] == 0)
        //            {

        //            }
        //        }
        //    }
        //}

        //private List<int<> NumberIsValid(int n, int file, int col)
        //{
        //    for(int i = 0; i < 3; i++)
        //    {
        //        if()
        //    }
        //}

        //Recorrer filas y columnas en busca de un numero y guardar su posicion
        //Recorrer en busqueda de las demas posiciones de ese numero.
        //Si existen mas posicion, verificar si la otra posicion es paralela o perpendicular con respecto a la primera
        //En base a estas posiciones definir las posibles posiciones a cubrir de ese numero en la submatriz definida
        //por el estado de paralela o perpendicular.
        //Si existe una sola posible posicion a cubrir dentro de una submatriz, cubrir posicion con numero.

        //Que significa que una posible posicion a curbir?
        //Significa que la posicion no coindice en fila, columna o submatriz con otra posicion

        //Que signica que haya una sola posible posicion a cubrir?
        //Significa que la posicion cumple con los siguientes rquisitos:
        //1_Cumple con la condicion de posible posicion a cubrir.
        //2_Las submatrices en vertical y horizontal no permiten poner un numero en su misma fila o columna ya que no cumplen con la condicion "1"

        //Cuando no exista solo una posible posicion a cubrir en ninguna de las casillas, verficiar que numero falta
        //en las filas o en las columnas, tomar uno de ellos y ejecutar "validacion de numero faltante en fila o columna"

        //Que es validacion de numero faltante en fila o columna?
        //Esta funcion toma un numero faltante en x fila o x columna y en base a la poscion de los demas mismos numeros realiza una
        //evaluacion de si es la unica posicion en la que podria ir, de ser correcto lo coloca


    }
}
