using Microsoft.AspNetCore.Mvc;

namespace Task3.Controllers;

[ApiController]
[Route("/boburboboyev3_gmail_com")]
public class HomeController : Controller
{
    [HttpGet]
    public ActionResult<string> Index([FromQuery] string x, [FromQuery] string y)
    {
        if (int.TryParse(x, out int n1) && int.TryParse(y, out int n2))
        {
            if (n1 >= 1 && n2 >= 1)
            {
                int gcd = GCD(n1, n2);

                return (n1 * n2 / gcd).ToString();
            }
        }

        return "NaN";
    }

    private int GCD(int x, int y)
    {
        while (y != 0)
        {
            int r = x % y;
            x = y;
            y = r;
        }

        return x;
    }
}
