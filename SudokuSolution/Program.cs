using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO.Compression;
using SudokuSolution;
using SudokuSolution.Negocio;
using SudokuSolution.Modelo;
using System.Diagnostics;

class Program
{
    static async Task Main()
    {
        TableroNegocio negocio = new TableroNegocio();
        Tablero? tablero = await negocio.Get();

        if (tablero != null)
        {
            tablero.ConstruirMatriz();
            Console.WriteLine("Mision:");
            tablero.Dibujar();
            Console.WriteLine();
            Console.WriteLine("Solucion por programa:");
            Resolucion resolucion = new Resolucion(tablero.tablero);
            tablero.tablero = resolucion.Resolver();
            Console.WriteLine();
            tablero.Dibujar();
            Console.WriteLine();
            Console.WriteLine("Solucion del juego:");
            Console.WriteLine();
            tablero.ConstruirSolucion();
            tablero.Solucion();
            Console.WriteLine();
            if (SonMatricesIguales(tablero.tableroResuelto, tablero.tablero))
            {
                Console.WriteLine("El programa ha resuelto correctamente. Ambos tableros son iguales.");
            }
            else
            {
                Console.WriteLine("El programa no ha podido resolver correctamente. Ambos tableros no son iguales.");
            }
        }
        else
        {
            Console.WriteLine("No ha sido posible obtener el tablero de juego.");
        }
    }

    static bool SonMatricesIguales(int[,] matriz1, int[,] matriz2)
    {
        int filas = matriz1.GetLength(0);
        int columnas = matriz1.GetLength(1);

        for (int i = 0; i < filas; i++)
        {
            for (int j = 0; j < columnas; j++)
            {
                if (matriz1[i, j] != matriz2[i, j])
                {
                    return false;
                }
            }
        }
        return true;
    }
}

