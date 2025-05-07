using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolution.DTOs
{
    public class TableroDTO
    {
        public int id { get; set; }
        public string mission { get; set; }
        public string solution { get; set; }
        public float win_rate { get; set; }
    }
}
