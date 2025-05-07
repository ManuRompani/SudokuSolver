using Newtonsoft.Json;
using SudokuSolution.DTOs;
using SudokuSolution.Modelo;
using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolution.Negocio
{
    public class TableroNegocio
    {
        public async Task<Tablero?> Get()
        {
            Tablero? tablero = null;

            using (HttpClient client = new HttpClient())
            {
                // Establecer encabezados para emular la solicitud de un navegador
                client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.124 Safari/537.36");
                client.DefaultRequestHeaders.Add("Accept", "*/*");
                client.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate, br");
                client.DefaultRequestHeaders.Add("Accept-Language", "es-419,es;q=0.9,en;q=0.8");
                client.DefaultRequestHeaders.Add("DNT", "1");
                client.DefaultRequestHeaders.Add("X-Requested-With", "XMLHttpRequest");
                client.DefaultRequestHeaders.Add("X-Easy-Locale", "en");

                string url = "https://sudoku.com/api/v2/level/Expert";

                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    // Leer la respuesta comprimida
                    byte[] compressedResponse = await response.Content.ReadAsByteArrayAsync();

                    // Descomprimir los datos (Brotli en este caso)
                    using (MemoryStream compressedStream = new MemoryStream(compressedResponse))
                    using (BrotliStream brotliStream = new BrotliStream(compressedStream, CompressionMode.Decompress))
                    using (StreamReader reader = new StreamReader(brotliStream))
                    {
                        string jsonResponse = await reader.ReadToEndAsync();

                        try
                        {
                            TableroDTO sudokuResponse = JsonConvert.DeserializeObject<TableroDTO>(jsonResponse);

                            tablero = new Tablero()
                            {
                                mission = sudokuResponse.mission,
                                solution = sudokuResponse.solution
                            };
                        }
                        catch (JsonReaderException e)
                        {
                            //nothing
                        }
                    }
                }
            }

            return tablero;
        }
    }
}
