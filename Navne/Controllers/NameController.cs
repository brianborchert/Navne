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

            //if (erDetEnDreng(navn))
            //{
            //    return "Dreng";
            //}
            //else if (erDetEnPige(navn))
            //{
            //    return "Pige";
            //}
            //else if (erDetUnisex(navn))
            //{
            //    return "Unisex";
            //}
            //else
            //{
            //    return "Ukendt navn";
            //}
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

        //private String PrintSomething()
        //{
        //    List<List<string>> allLinesList = new List<List<string>>();
        //    using (var reader = new StreamReader(@"wwwroot\navne-d.csv"))
        //    {
        //        while (!reader.EndOfStream)
        //        {
        //            var line = reader.ReadLine();
        //            var values = line.Split(';');

        //            List<string> oneLineList = new List<string>();
        //            oneLineList.Add(values[0]);
        //            oneLineList.Add(values[1]);
        //            oneLineList.Add(values[2]);

        //            allLinesList.Add(oneLineList);
        //        }
        //    }

        //    return allLinesList[0][0] + "-" + allLinesList[0][1] + "-" + allLinesList[0][2];

        //    //return "Hello";
        //}

        private string WhatGenderIsIt(String navn)
        {
            List<List<string>> allLinesList = AllLinesList();
            string response = "";

            foreach (List<string> line in allLinesList)
            {
                if (line[0] == navn)
                {
                    response += "\nDreng: " + line[1] + " - " + "Pige: " + line[2];
                }
            }
            return response;

            //return allLinesList[0][0] + "-" + allLinesList[0][1] + "-" + allLinesList[0][2];
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

