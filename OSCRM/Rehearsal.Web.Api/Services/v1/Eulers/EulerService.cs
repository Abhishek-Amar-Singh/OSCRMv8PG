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
            bool for3, for5;

            for (int i=1; i<max; i++)
            {
                for3 = 3 * i < max;
                for5 = (5 * i < max) && (5*i%3 != 0);
                
                if (for3 == false && for5 == false)
                {
                    nOfIters = i - 1;
                    break;
                }
                sum += (for3 ? 3 * i : 0) + (for5 ? 5 * i : 0);
            }
            #endregion

            return new
            {
                ordinary_solution = $"The sum of numbers that are divisible by 3 and 5 is {s} and nOfIters={nofIters}.",
                optimum_solution = $"The sum of numbers that are divisible by 3 and 5 is {sum} and nOfIters={nOfIters}."
            };
        }
    }
}
