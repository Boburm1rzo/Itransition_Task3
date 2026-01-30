using Microsoft.AspNetCore.Mvc;
using System.Numerics;

namespace Task3.Controllers;

[ApiController]
[Route("boburboboyev3_gmail_com")]
public class HomeController : ControllerBase
{
    [HttpGet]
    public string Index([FromQuery] string x, [FromQuery] string y)
    {
        if (BigInteger.TryParse(x, out var n1) && BigInteger.TryParse(y, out var n2))
        {
            if (n1 >= 1 && n2 >= 1)
            {
                BigInteger gcd = BigInteger.GreatestCommonDivisor(n1, n2);
                BigInteger lcm = (n1 * n2) / gcd;

                return lcm.ToString();
            }
        }

        return "NaN";
    }
}