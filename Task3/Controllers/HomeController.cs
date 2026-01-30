using Microsoft.AspNetCore.Mvc;
using System.Numerics;

namespace Task3.Controllers;

[ApiController]
[Route("/boburboboyev3_gmail_com")]
public class HomeController : Controller
{
    [HttpGet]
    public ActionResult<string> Index([FromQuery] string x, [FromQuery] string y)
    {
        if (BigInteger.TryParse(x, out var n1) && BigInteger.TryParse(y, out var n2))
        {
            if (n1 >= 1 && n2 >= 1)
            {
                BigInteger gcd = GCD(n1, n2);

                return (n1 * n2 / gcd).ToString();
            }
        }

        return "NaN";
    }

    private BigInteger GCD(BigInteger x, BigInteger y)
    {
        while (y != 0)
        {
            var r = x % y;
            x = y;
            y = r;
        }

        return x;
    }
}
