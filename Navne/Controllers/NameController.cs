using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
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
            return WhatGenderIsIt(navn);
        }

        private string WhatGenderIsIt(String navn)
        {
            string response = "Navnet '" + navn + "' er et ";
            bool nameFound = false;
            bool boy = false;
            bool girl = false;

            List<List<string>> allLinesList = AllLinesList();
            foreach (List<string> line in allLinesList)
            {
                if (line[0] == navn)
                {
                    nameFound = true;
                    if (line[1] == "Ja") boy = true;
                    if (line[2] == "Ja") girl = true;
                }
            }

            if (nameFound)
            {
                if (boy && girl) response += "unisexnavn";
                else if (boy) response += "drengenavn";
                else if (girl) response += "pigenavn";
            }
            else
            {
                response += "ukendt navn";
            }

            return response;
        }

        private List<List<string>> AllLinesList()
        {
            List<string> paths = new List<string>();
            paths.Add(@"wwwroot\navne-d.csv");
            paths.Add(@"wwwroot\navne-p.csv");
            paths.Add(@"wwwroot\navne-dp.csv");

            List<List<string>> allLinesList = new List<List<string>>();

            foreach (string path in paths)
            {
                using (var reader = new StreamReader(path))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(';');

                        List<string> oneLineList = new List<string>();
                        oneLineList.Add(values[0]);
                        oneLineList.Add(values[1]);
                        oneLineList.Add(values[2]);

                        allLinesList.Add(oneLineList);
                    }
                }
            }
            return allLinesList;
        }
    }
}

