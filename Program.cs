using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

int GCD(int a, int b)
{
    while (b != 0)
    {
        int temp = b;
        b = a % b;
        a = temp;
    }
    return a;
}

int LCM(int a, int b)
{
    return (a * b) / GCD(a, b);
}

app.MapGet("/amirhamzabadal2477_gmail_com", (HttpRequest request) =>
{
    string? xStr = request.Query["x"];
    string? yStr = request.Query["y"];

    if (!int.TryParse(xStr, out int x) || !int.TryParse(yStr, out int y))
        return Results.Text("NaN");

    if (x <= 0 || y <= 0)
        return Results.Text("NaN");

    return Results.Text(LCM(x, y).ToString());
});

app.Run();
