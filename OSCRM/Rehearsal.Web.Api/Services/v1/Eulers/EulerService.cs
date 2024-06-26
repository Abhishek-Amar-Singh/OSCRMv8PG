using Shared.Lib.Extensions;

namespace Rehearsal.Web.Api.Services.v1.Eulers
{
    public class EulerService : IEulerService
    {
        public dynamic SolveProblem1()
        {
            #region ordinary solution
            int s = 0, maxi = 1000, nofIters = 0;
            for (int i = 3; i < maxi; i++)
            {
                if (i % 3 == 0 || i % 5 == 0)
                {
                    s += i;
                }
                nofIters++;
            }
            #endregion

            #region optimized solution
            int sum = 0, nOfIters = 0, max = 1000;
            for (int i = 1; (3 * i < max) || (5 * i < max); i++)
            {
                if (3 * i < max) sum += 3 * i;
                if ((5 * i < max) && (5 * i % 3 != 0)) sum += 5 * i;
                nOfIters = i;
            }
            #endregion

            return new
            {
                ordinary_solution = $"The sum of numbers that are divisible by 3 and 5 is {s} and nOfIters={nofIters}.",
                optimum_solution = $"The sum of numbers that are divisible by 3 and 5 is {sum} and nOfIters={nOfIters}."
            };
        }

        public dynamic SolveProblem2()
        {
            List<int> fibSeries = new();

            int f0 = 0, f1 = 1, f = f0 + f1, maxReach = 4000000, sum_even = 0, nOfIters = 0;
            fibSeries.AddRange(new int[] { f0, f1, f });
            for (int i = 1; i < maxReach; i++)
            {
                f0 = f1;
                f1 = f;
                f = f0 + f1;
                sum_even += f % 2 == 0 ? f : 0;
                if (f >= maxReach)
                {
                    nOfIters = i - 1;
                    break;
                }
                fibSeries.Add(f);
            }

            return new
            {
                sum_even_obj = new { sum_even = sum_even, nOfIters = nOfIters },
                sum_even_linq = fibSeries.Skip(2).Where(x => x % 2 == 0).Sum()
            };
        }

        public dynamic SolveProblem3()
        {
            //List<long> primes = new() { 2 };
            List<long> prime_factors = new();
            long find_pf = 600851475143;//13195;
            //long result = 1;

            int till = (int)Math.Sqrt(find_pf) + 1;
            for (long i = 3; i <= till; i += 2) // Start from 3 and increment by 2 to check only odd numbers
            {
                bool isPrime = true;
                int sqrt = (int)Math.Sqrt(i) + 1; // Calculate square root once

                for (int j = 3; j <= sqrt; j += 2) // Check only odd divisors up to square root
                {
                    if (i % j == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }

                if (isPrime)
                {
                    //primes.Add(i);
                    if (find_pf % i == 0)
                    {
                        prime_factors.Add(i);
                        //result *= i;
                    }
                }
            }

            return new { prime_factors, largest_prime_factor = $"The largest prime factor of {find_pf} is {prime_factors.Last()}." };
            //return new { primes, prime_factors, result, is_eq = result == find_pf};
        }

        public string SolveProblem4(int h)
        {
            if (h > 0)
            {
                return "400: Invalid input";
            }

            int largest2DigitNum = 999, smallest2DigitNum = 100, n = largest2DigitNum;
            Dictionary<int, string> spalindromes = new();

            for (int i = largest2DigitNum; i >= smallest2DigitNum && n >= smallest2DigitNum; i--)
            {
                if (i == smallest2DigitNum)
                {
                    i = largest2DigitNum;
                    n--;
                }

                var result = Convert.ToString(n * i);
                var reversed_res = result.ReverseString();
                if (result == reversed_res)
                {
                    int reverse_res = int.Parse(reversed_res);
                    if (!spalindromes.ContainsKey(reverse_res))
                    {
                        spalindromes.Add(reverse_res, $"{n} x {i} = {result} ({reverse_res})");
                    }
                }
            }
            spalindromes = spalindromes.OrderByDescending(x => x.Key).ToDictionary();

            return $"{spalindromes.ElementAt(h - 1)}";
        }

        public string SolveProblem5(int nth_element)
        {
            int from = 1, to = 20, i = 1, h = 0;
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

            return $"The smallest number which is divisible by numbers (1-20) is {i-1}.";
        }

        public string SolveProblem6()
        {
            int sum_of_squares = 0;
            int square_of_sum = 0;
            for (int i = 1; i <= 100; i++)
            {
                sum_of_squares += (int)Math.Pow(i, 2);
                square_of_sum += i;
            }

            square_of_sum = (int)Math.Pow(square_of_sum, 2);

            return $"sum_of_squares:: {sum_of_squares}, square_of_sum:: {square_of_sum} and difference:: {square_of_sum - sum_of_squares}";
        }

        public string SolveProblem7(int nth_prime)
        {
            long i = 3;
            int prime_counter = 1;
            if (nth_prime == prime_counter)
            {
                return $"{2}";
            }

            for (i = 3; nth_prime != prime_counter; i += 2) // Start from 3 and increment by 2 to check only odd numbers
            {
                bool isPrime = true;
                int sqrt = (int)Math.Sqrt(i) + 1; // Calculate square root once

                for (int j = 3; j <= sqrt; j += 2) // Check only odd divisors up to square root
                {
                    if (i % j == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }

                if (isPrime)
                {
                    prime_counter++;
                    if (nth_prime == prime_counter)
                    {
                        break;
                    }
                }
            }

            return $"The {nth_prime} prime is {i}.";
        }

        public dynamic SolveProblem8(int adj)
        {
            string str = "7316717653133062491922511967442657474235534919493496983520312774506326239578318016984801869478851843858615607891129494954595017379583319528532088055111254069874715852386305071569329096329522744304355766896648950445244523161731856403098711121722383113622298934233803081353362766142828064444866452387493035890729629049156044077239071381051585930796086670172427121883998797908792274921901699720888093776657273330010533678812202354218097512545405947522435258490771167055601360483958644670632441572215539753697817977846174064955149290862569321978468622482839722413756570560574902614079729686524145351004748216637048440319989000889524345065854122758866688116427171479924442928230863465674813919123162824586178664583591245665294765456828489128831426076900422421902267105562632111110937054421750694165896040807198403850962455444362981230987879927244284909188845801561660979191338754992005240636899125607176060588611646710940507754100225698315520005593572972571636269561882670428252483600823257530420752963450";
            int[] intArray = str.Select(c => int.Parse(c.ToString())).ToArray();
            
            List<long> alist = new();

            for (int i = 0; i < intArray.Length; i++)
            {
                long result = intArray[i], j = i+1, k = i+adj;
                if (k > intArray.Length)
                {
                    for (i = intArray.Length - 1; i >= intArray.Length - 1 - adj; i--)
                    {
                        result = intArray[i];
                        j = i - 1;
                        k = i - adj;
                        if (k < intArray.Length - 2 - adj)
                        {
                            break;
                        }

                        while (k < j && result != 0)
                        {
                            result *= intArray[j];
                            if (result == 0) break;
                            j--;
                        }

                        alist.Add(result);
                    }
                    break;
                }

                while (j < k && result != 0)
                {
                    result *= intArray[j];
                    if (result == 0) break;
                    j++;
                }

                alist.Add(result);
            }

            HashSet<long> set = new(alist);

            return new { arr = set.ToArray().OrderByDescending(x => x), arr_len = set.Count};
        }
    }
}
