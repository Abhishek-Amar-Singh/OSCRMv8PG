
Console.Write("Enter nth_element: ");
int nth_element = int.Parse(Console.ReadLine()!);
int from = 1, to = 20, i = 1, h=0;
bool status = false;
do
{
    for (int j = from; j <= to; j++)
    {
        if (i % j == 0)
        {
            if (j == to)
            {
                h++;
                if (h == nth_element)
                {
                    status = true;
                    break;
                }
            }
        }
        else break;
    }

    i++;
} while (status == false);
Console.WriteLine($"The smallest number which is divisible by numbers (1-20) is {i-1}.");