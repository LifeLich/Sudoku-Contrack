using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers.Internal;
using Microsoft.Extensions.WebEncoders.Testing;

namespace Backend.Controllers
{
    [Route("api/sudoku")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values/5
        [HttpGet("{value}")]
        public ActionResult<string> Get(string value)
        {
            if (value == null)
            {
                return BadRequest();
            }

            int[,] map = new int[9, 9];
            var charr = value.ToCharArray();
            for (int i = 0; i < charr.Length; i++)
            {
                int k = 0;
                for (int j = 0; j < 9 && i % 8 == 0; j++)
                {
                    map[k, j] = Int32.Parse(charr[i].ToString());
                    k++;
                }
            }

            //var storage = value.Clone();
            var solver = new Solver();
            if (solver.solve(map))
                return new OkObjectResult(value);
            return StatusCode(418);
        }
    }
}
