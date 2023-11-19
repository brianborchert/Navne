using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Navne.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NameController : ControllerBase
    {

        private readonly ILogger<NameController> _logger;

        public NameController(ILogger<NameController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{navn}")]
        public string Get(String navn)
        {
            // Kan testes på https://localhost:44395/name/Kristian

            if (erDetEnDreng(navn))
            {
                return "Dreng";
            }
            else if (erDetEnPige(navn))
            {
                return "Pige";
            }
            else if (erDetUnisex(navn))
            {
                return "Unisex";
            }
            else
            {
                return "Ukendt navn";
            }

        }

        private Boolean erDetEnDreng(String navn)
        {
            return navn.Equals("Kristian");
        }

        private Boolean erDetEnPige(String navn)
        {
            // Skriv din egen kode her i stedet for min
            return false;
        }


        private Boolean erDetUnisex(String navn)
        {
            // Skriv din egen kode her i stedet for min
            return false;
        }

    }
}

