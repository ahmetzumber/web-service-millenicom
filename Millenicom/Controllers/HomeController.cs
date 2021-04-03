using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Millenicom.Controllers
{
    public class HomeController : Controller
    {

        public static int countRandom = 0, countPattern = 0;

        public int RandomNumberGenerator()
        {
            return new Random().Next(1000,10000);
        }
        public string findPattern(string param1, string param2)
        {
            string newStr = "", blockChar = "";
            if (param1.Contains(param2))
            {
                for (int i = 0; i < param1.Length; i++)
                {
                    for (int j = 0; j < param2.Length; j++)
                    {
                        blockChar += "#";
                    }
                    newStr = param1.Replace(param2, blockChar);
                    return "true " + newStr;
                }
            }
            else
            {
                return "false";
            }
            return "";
        }
        public string functionCounter(string funcName)
        {
            if (funcName != null)
            {
                if (funcName.Equals("RandomNumberGenerator"))
                {
                    return "RandomNumberGenerator function called " + countRandom + " times";
                }
                else if (funcName.Equals("findPattern"))
                {
                    return "findPattern function called" + countPattern + " times";
                }
                else if (!funcName.Equals("RandomNumberGenerator") || !funcName.Equals("findPattern"))
                {
                    return "The function you were looking for does not exist !!";
                }
            }
    
            return "RandomNumberGenerator: " + countRandom + " -- " + "findPattern: " + countPattern;
        }

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Service01()
        {
            countRandom++;
            string result = RandomNumberGenerator().ToString();
            ViewBag.RandomNumberMessage = result;
            return View();
        }    
        public ActionResult Service02()
        {     
            return View();
        }

        [HttpPost]
        public ActionResult Service02(string param1, string param2)
        {
            countPattern++;
            string result = findPattern(param1, param2);
            ViewBag.findPatternMessage = result;
            return View();
        }

        // GET: 
        public ActionResult Service03()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Service03(string funcName)
        {
            string result = functionCounter(funcName); 
            ViewBag.functionCounterMessage = result;
            return View();
        }
    }
}