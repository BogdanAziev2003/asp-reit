using System.IO;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", async (context) =>
{
    context.Response.ContentType = "text/html; charset=utf-8";
    await context.Response.SendFileAsync("html/index.html");
});

app.MapGet("/weight/{gramm}", WeightRequest);
app.MapGet("/know/{s}/{r}/{k}", KnowRequest);
app.Run();


string WeightRequest(string gramm)
{
    StreamWriter sr = new StreamWriter("./log.txt", true);

    string kilo = Convert.ToString(int.Parse(gramm) / 1000);
    string tonna = Convert.ToString(int.Parse(kilo) / 1000);
    sr.WriteLine("gramm - "  + gramm + ", kilo - " + kilo + ", tonn - " + tonna);
    sr.Close();

    return $"Килограмм: {kilo}, Тонн: {tonna}";
}

string KnowRequest(string s, string r, string k)
{
    StreamWriter sr = new StreamWriter("./log.txt", true);

    int a = Convert.ToInt32(Math.Sqrt(int.Parse(s)));
    if (int.Parse(r) * 2 + int.Parse(k) <= a)
    {
        sr.WriteLine("s - " + s + ", r - " + r + ", k - " + k + ", answer - Можно");
        sr.Close();
        return "Можно";
    }
    sr.WriteLine("s - " + s + ", r - " + r + ", k - " + k + ", answer - Нельзя");
    sr.Close();
    return "Нельзя";
}