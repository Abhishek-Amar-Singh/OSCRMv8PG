
using System.Text;

int k = 1;
int largest2DigitNum = 999, smallest2DigitNum = 100, n = largest2DigitNum;
Dictionary<int, string> spalindromes = new();

for (int i = largest2DigitNum; i >= smallest2DigitNum && n >= smallest2DigitNum; i--)
{
    if (i == smallest2DigitNum)
    {
        i = largest2DigitNum;
        n--;
    }

    string res = Convert.ToString(n * i), rev_res = ReverseString(res);
    
    if (res == rev_res)
    {
        if (!spalindromes.ContainsKey(int.Parse(rev_res)))
        {
            //palindromes.Add(int.Parse(rev_res));
            //Console.WriteLine($"{n} x {i} = {res} ({rev_res})");
            spalindromes.Add(int.Parse(rev_res), $"{n} x {i} = {res} ({rev_res})");
        }
    }
}

spalindromes = spalindromes.OrderByDescending(x => x.Key).ToDictionary();

Console.WriteLine($"{spalindromes.ElementAt(k - 1)}");

string ReverseString(string input)
{
    char[] chars = input.ToCharArray();
    StringBuilder reversed_input = new StringBuilder();
    for (int i = chars.Length - 1; i >= 0; i--)
    {
        reversed_input.Append(chars[i]);
    }

    return reversed_input.ToString();
}