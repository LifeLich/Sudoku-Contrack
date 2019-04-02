using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Server.Controllers
{
    [Route("api/Sudoku")]
    [ApiController]
    public class SudokuController : Controller
    {
        // POST api/Sudoku/4
        [HttpGet("{value}")]
        public string Post(string value)
        {
            return "Simon var dum "+value;
        }
    }
}