namespace Rehearsal.Web.Api.Services.v1.Eulers
{
    public class EulerService : IEulerService
    {
        public dynamic SolveProblem1()
        {
            #region ordinary solution
            int s = 0, maxi = 1000, nofIters = 0;
            for (int i=3; i < maxi; i++)
            {
                if (i%3 == 0 || i%5 == 0)
                {
                    s += i;
                }
                nofIters++;
            }
            #endregion

            #region optimized solution
            int sum = 0, nOfIters = 0, max = 1000;
            for (int i=1; (3 * i < max) || (5 * i < max); i++)
            {
                if (3 * i < max) sum += 3 * i;
                if ((5 * i < max) && (5*i%3 != 0)) sum += 5 * i;
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
            fibSeries.AddRange(new int[]{ f0, f1, f});
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
    }
}
