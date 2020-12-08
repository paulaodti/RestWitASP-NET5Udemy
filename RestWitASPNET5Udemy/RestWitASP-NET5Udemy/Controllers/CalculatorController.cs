using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWitASP_NET5Udemy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {

        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult Soma(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sum = ConvertToDouble(firstNumber) + ConvertToDouble(secondNumber);
                return Ok(sum.ToString());

            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("sub/{firstNumber}/{secondNumber}")]
        public IActionResult Subtracao(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sum = ConvertToDouble(firstNumber) - ConvertToDouble(secondNumber);
                return Ok(sum.ToString());

            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("div/{firstNumber}/{secondNumber}")]
        public IActionResult Divisao(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber) && ConvertToDouble(secondNumber) != 0)
            {
                var sum = ConvertToDouble(firstNumber)/ConvertToDouble(secondNumber);
                return Ok(sum.ToString());

            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("multi/{firstNumber}/{secondNumber}")]
        public IActionResult Multiplicacao(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sum = ConvertToDouble(firstNumber) * ConvertToDouble(secondNumber);
                return Ok(sum.ToString());

            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("avg/{firstNumber}/{secondNumber}")]
        public IActionResult Media(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sum = (ConvertToDouble(firstNumber) + ConvertToDouble(secondNumber))/2;
                return Ok(sum.ToString());

            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("sqrt/{firstNumber}")]
        public IActionResult RaizQuarada(string firstNumber)
        {
            if (IsNumeric(firstNumber))
            {
                double number = ConvertToDouble(firstNumber);
                if (IsNaturalNumber(number))
                {
                    var sum = Math.Sqrt(ConvertToDouble(firstNumber));
                    return Ok(sum.ToString());
                }
            }
            return BadRequest("Invalid Input");
        }

        private double ConvertToDouble(string srtNumber)
        {
            return Double.Parse(srtNumber);
        }

        private bool IsNumeric(string srtNumber)
        {
            double number;
            return double.TryParse(srtNumber, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out number);
        }

        private bool IsNaturalNumber(double number)
        {
            return number >= 0;    
        }
    }
}
