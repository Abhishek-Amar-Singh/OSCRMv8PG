using System.Text;

DateTime startTime;
DateTime endTime;
TimeSpan totalTime;
string s = "";
startTime = DateTime.Now;
for (int i = 0; i < 1000; i++)
{
    s += i.ToString();
}
endTime = DateTime.Now;
totalTime = endTime - startTime;
Console.WriteLine($"Total time taken (with string)::{totalTime.TotalMilliseconds}");


StringBuilder sb = new StringBuilder();
startTime = DateTime.Now;
for (int i = 0; i < 1000; i++)
{
    sb.Append(i.ToString());
}
endTime = DateTime.Now;
totalTime = endTime - startTime;
Console.WriteLine($"Total time taken (with StringBuilder)::{totalTime.TotalMilliseconds}");