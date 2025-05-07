using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolution.Modelo
{
    public class Resolucion
    {
        private const int _filas = 9;
        private const int _columnas = 9;
        private const int _filasColumnasPorSeccion = 3;

        private int[,] _tableroOriginal = new int[_filas, _columnas];

        private List<int>[,] _tableroDeResolucion = new List<int>[9, 9];

        public Resolucion(int[,] matrizTablero)
        {
            _tableroOriginal = matrizTablero;
        }

        private void CrearTableroDeResolucion()
        {
            for (int i = 0; i < _filas; i++)
            {
                for (int j = 0; j < _columnas; j++)
                {
                    int positionValue = _tableroOriginal[i, j];
                    if ( positionValue != 0)
                    {
                        _tableroDeResolucion[i, j] = new List<int> { positionValue };
                    }
                    else
                    {
                        _tableroDeResolucion[i, j] = Enumerable.Range(1, 9).ToList();
                    }
                }
            }
        }

        public int[,] Resolver()
        {
            bool resuelto = false;
            CrearTableroDeResolucion();

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            
            while (!resuelto)
            {
                for (int i = 0; i < _filas; i++)
                {
                    for (int j = 0; j < _columnas; j++)
                    {
                        EliminarPosiblesNumerosEnSeccion(i, j);
                        EliminarPosiblesNumerosEnFila(i, j);
                        EliminarPosiblesNumerosEnColumna(i, j);
                    }
                }

                for(int i=0; i< _filas; i++)
                {
                    for(int j=0; j< _columnas; j++)
                    {
                        if(!CandidatoUnico(i, j))
                            CandidatoOculto(i, j);
                    }
                }

                bool todosResueltos = true;
                for (int i = 0; i < _filas; i++)
                {
                    for (int j = 0; j < _columnas; j++)
                    {
                        if (_tableroDeResolucion[i, j].Count > 1)
                        {
                            todosResueltos = false;
                            break;
                        }
                    }
                    if (!todosResueltos)
                        break;
                }
                resuelto = todosResueltos;

                if (stopwatch.ElapsedMilliseconds > 5000)
                {
                    Console.WriteLine("El algoritmo tardó demasiado. Posible bucle infinito.");
                    break;
                }
            }
            Console.WriteLine(stopwatch.Elapsed);
            return _tableroOriginal;
        }

        private bool CandidatoUnico(int fila, int columna)
        {
            if (_tableroDeResolucion[fila,columna].Count == 1)
            {
                int valor = _tableroDeResolucion[fila, columna][0];
                _tableroOriginal[fila, columna] = valor;

                return true;
            }

            return false;
        }

        private void CandidatoOculto(int fila, int columna)
        {
            int startRow = (fila / _filasColumnasPorSeccion) * _filasColumnasPorSeccion;
            int startCol = (columna / _filasColumnasPorSeccion) * _filasColumnasPorSeccion;

            int contadorCandidato = 0;
            int filaCandidato = -1;
            int columnaCandidato = -1;

            for (int h = 1; h <= _filasColumnasPorSeccion * _filasColumnasPorSeccion; h++)
            {
                for (int i = startRow; i < startRow + _filasColumnasPorSeccion; i++)
                {
                    for (int j = startCol; j < startCol + _filasColumnasPorSeccion; j++)
                    {
                        if (_tableroDeResolucion[i, j].Contains(h))
                        {
                            contadorCandidato++;
                            filaCandidato = i;
                            columnaCandidato = j;

                            if (contadorCandidato > 1)
                            {
                                break;
                            }
                        }
                    }

                    if (contadorCandidato > 1)
                    {
                        break;
                    }
                }

                if (contadorCandidato == 1)
                {
                    _tableroDeResolucion[filaCandidato, columnaCandidato].Clear();
                    _tableroDeResolucion[filaCandidato, columnaCandidato].Add(h);
                    _tableroOriginal[filaCandidato, columnaCandidato] = h;
                }

                contadorCandidato = 0;
            }
        }

        private void EliminarPosiblesNumerosEnSeccion(int fila, int columna)
        {
            int startRow = (fila / _filasColumnasPorSeccion) * _filasColumnasPorSeccion;
            int startCol = (columna / _filasColumnasPorSeccion) * _filasColumnasPorSeccion;

            for (int i = startRow; i < startRow + _filasColumnasPorSeccion; i++)
            {
                for (int j = startCol; j < startCol + _filasColumnasPorSeccion; j++)
                {
                    int positionValue = _tableroOriginal[i, j];
                    if (positionValue != 0 && _tableroDeResolucion[fila, columna].Contains(positionValue)
                        && (i!=fila || j!=columna))
                    {
                        _tableroDeResolucion[fila, columna].Remove(positionValue);
                    }
                }
            }
        }

        private void EliminarPosiblesNumerosEnFila(int fila, int columna)
        {
            for (int col = 0; col < _columnas; col++)
            {
                int positionValue = _tableroOriginal[fila, col];
                if (positionValue != 0 && _tableroDeResolucion[fila, columna].Contains(positionValue)
                    && col != columna)
                {
                    _tableroDeResolucion[fila, columna].Remove(positionValue);
                }
            }
        }

        private void EliminarPosiblesNumerosEnColumna(int fila, int columna)
        {
            for (int fil = 0; fil < _filas; fil++)
            {
                int positionValue = _tableroOriginal[fil, columna];
                if (positionValue != 0 && _tableroDeResolucion[fila, columna].Contains(positionValue)
                    && fil != fila)
                {
                    _tableroDeResolucion[fila, columna].Remove(positionValue);
                }
            }
        }

    }
}
