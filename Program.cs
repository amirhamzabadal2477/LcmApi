using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Numerics;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

BigInteger GCD(BigInteger a, BigInteger b)
{
    while (b != 0)
    {
        BigInteger temp = b;
        b = a % b;
        a = temp;
    }
    return a;
}

BigInteger LCM(BigInteger a, BigInteger b)
{
    return (a * b) / GCD(a, b);
}

app.MapGet("/amirhamzabadal2477_gmail_com", (HttpRequest request) =>
{
    string? xStr = request.Query["x"];
    string? yStr = request.Query["y"];

    if (!BigInteger.TryParse(xStr, out BigInteger x) || !BigInteger.TryParse(yStr, out BigInteger y))
        return Results.Text("NaN");

    if (x <= 0 || y <= 0)
        return Results.Text("NaN");

    return Results.Text(LCM(x, y).ToString());
});

app.Run();
