//using Rehearsal.Web.Api.Extensions;
//using Rehearsal.Web.Api.Models.Values.ImplicitOperator;
//using System.Collections.Concurrent;
//using System.Collections.Frozen;
//using System.Diagnostics;
//using System.Text.Json.Nodes;

//namespace Rehearsal.Web.Api.Services.Values
//{
//    public class ValueService : IValueService
//    {
//        private List<string> threadIdsList, processingList;
//        private ConcurrentDictionary<string, int[]> threadMaps;

//        public ValueService()
//        {
//            threadIdsList = [];
//            threadMaps = [];
//            processingList = [];
//        }

//        public IEnumerable<string> Random_Yield()
//        {
//            string[] musicians =
//            {
//                "Lucky Ali",
//                "Mohit Chauhan",
//                "Jagjit Singh",
//                "Vishal Mishra",
//                "Abhijit Sawant",
//                "Arijit Singh",
//                "Atif Aslam",
//                "Kishore Kumar",
//                "Papon"
//            };

//            for (int i = 0; i < 5; i++)
//            {
//                string[] choices =
//                    Random.Shared.GetItems(musicians, 2);

//                yield return string.Join(",", choices);
//            }
//        }

//        public dynamic SpreadOperator()
//        {
//            int[] a = [1, 2, 3];
//            int[] b = [4, 5, 6];

//            //1st way
//            int[] e = new int[a.Length + b.Length];
//            a.CopyTo(e, 0);
//            b.CopyTo(e, a.Length);

//            //2nd way
//            int[] f = [];
//            f = a.ToArray().Concat(b).ToArray();

//            //3rd way
//            int[] d = [.. a, .. b];

//            return new
//            {
//                using_CopyTo = e,
//                using_Concat = f,
//                using_spread = d
//            };
//        }

//        #region use-minimum-null-statement
//        public record ClassA();
//        public bool MinimumNullStatement()
//        {
//            ClassA a = null;

//            if (a is null) a = new();

//            a = a is null ? new() : a;

//            a = a ?? new();

//            a ??= new();

//            return true;
//        }
//        #endregion

//        public IDictionary<string, dynamic> JsonNode_JsonArray()
//        {
//            var json = """
//                {
//                "name": "DotNet Core",
//                "version": [3.1, 5, 6, 7, 8],
//                "language": "C#"
//                }
//                """;

//            JsonNode? node = JsonNode.Parse(json);
//            JsonNode other = node!.DeepClone();
//            var flag = JsonNode.DeepEquals(node, other);

//            JsonArray jsonArray = new JsonArray(1, 2, 5, 4, 7, 8);
//            IEnumerable<int> values = jsonArray.GetValues<int>().Where(i => i % 2 == 0);

//            return new Dictionary<string, dynamic>
//            {
//                { "DeepEquals O/P", flag},
//                { "jsonArray O/P", values }
//            };

//        }

//        public IEnumerable<string> RandomShuffle()
//        {
//            string[] musicians =
//            {
//                "Lucky Ali",
//                "Mohit Chauhan",
//                "Jagjit Singh",
//                "Vishal Mishra",
//                "Abhijit Sawant",
//                "Arijit Singh",
//                "Atif Aslam",
//                "Kishore Kumar",
//                "Papon"
//            };

//            Random.Shared.Shuffle(musicians);

//            return musicians;
//        }

//        public FrozenDictionary<int, string> FrozenDictCollection()
//        {
//            var frozenDict = new Dictionary<int, string>()
//            {
//                {2001, "The Fast and the Furious" },
//                {2003, "2 Fast 2 Furious" },
//                {2006, "The Fast and the Furious: Tokyo Drift" },
//                {2009, "Fast & Furious" },
//                {2011, "Fast Five" },
//                {2013, "Fast & Furious 6" },
//                {2015, "Furious 7" },
//                {2017, "The Fate of the Furious" },
//                {2021, "F9" },
//                {2023, "Fast X"}
//            }.ToFrozenDictionary();

//            return frozenDict;
//        }

//        public FrozenSet<int> FrozenSetCollection()
//        {
//            var frozenSet = new List<int>() { 1, 2, 3, 4, 5 }.ToFrozenSet();

//            return frozenSet;
//        }

//        public IEnumerable<int> CustomLinqWhereEven()
//        {
//            var numbers = new List<int> { 1, 2, 3, 4, 5, 6 };

//            var evenNumbers = numbers.WhereEven();

//            return evenNumbers;
//        }

//        #region throw-and-throwEx
//        public bool Foo(string parameter)
//        {
//            try
//            {
//                return Bar();
//            }
//            catch (Exception e)
//            {
//                if (parameter == "throw")
//                {
//                    throw;
//                }
//                else
//                {
//                    throw e;
//                }
//            }
//        }
//        private bool Bar() =>
//            throw new Exception("Exception occurs in Rehearsal.Web.Api.Services.ValueService.Bar()");
//        #endregion

//        public double LambdaExample1(double baseNum, double? exp)
//        {
//            var todayLambda = double (double baseNumber, double exponent = 2) =>
//                Math.Pow(baseNumber, exponent);

//            return exp is null ? todayLambda(baseNum) : todayLambda(baseNum, exp??0);
//        }

//        public string RelationalPattern1(float score)
//        {
//            if (score is >= 60 and <= 100)
//            {
//                return "Passed the exam.";
//            }
//            return "unused.";
//        }

//        #region property-pattern-matching-1
//        class Person
//        {
//            public string name { get; set; } = null!;
//            public Location? location { get; set; }
//        }
//        class Location
//        {
//            public string? country { get; set; }
//        }
//        public string PropertyPatternMatching1()
//        {
//            Person person = new()
//            {
//                name = "Doraemon",
//                location = new() { country = "Japan" }
//            };

//            if (person is { name: "Doraemon", location.country: "Japan" })
//            {
//                return "It's me.";
//            }

//            return "It's not me.";
//        }
//        #endregion

//        public (string category, int amount)[] LINQMethodAggregate1()
//        {
//            (string category, int amount)[] data =
//            {
//                ("A", 2),
//                ("B", 3),
//                ("A", 10),
//                ("B", 58),
//                ("C", 72),
//            };

//            var aggregatedData = data
//                .GroupBy(d => d.category)
//                .Select(g => (g.Key, g.Sum(d => d.amount)))
//                .ToArray();

//            /*
//            // .NET 9
//            var aggregatedData =
//                data.AggregateBy(
//                    keySelector: entry => entry.Category,
//                    seed: 0,
//                    (totalLength, currentItem) => totalLength + currentItem.amount
//                );
//            */

//            return aggregatedData;
//        }

//        public dynamic EndsWithWithStringAndChar(string text) => new
//        {
//            slow_with_str = text.EndsWith("/"),
//            fast_with_char = text.EndsWith('/')
//        };

//        public List<string> ParallelForEach()
//        {
//            List<int> numbers = Enumerable.Range(1, 1000).ToList();
//            List<string> strings = new();

//            Parallel.ForEach(numbers, num =>
//            {
//                strings.Add($"Processing number: {num}");
//            });

//            return strings;
//        }

//        public dynamic MathClamp() => new
//        {
//            a = Math.Clamp(55,50,60),
//            b = Math.Clamp(12,50,60),
//            c = Math.Clamp(92,50,60)
//        };

//        public bool ContainsDuplicates()
//        {
//            List<int> numbers = [1, 2, 3, 3, 4, 5];

//            return numbers.ContainsDuplicates();
//        }

//        public IQueryable<float> LinqPagination()
//        {
//            List<float> floats = [2.4F, 1.3F, 78F, 0.98F, 78F, 18.9231F, 558.009F, 53.7F, 65.65F, 79.544F];

//            return floats.AsQueryable().Page(index: 2, size: 3);
//        }

//        public dynamic All_TrueForAll()
//        {
//            List<float> floats = [2.4F, 1.3F, -78F, 0.98F, 78F, 18.9231F, 558.009F, 53.7F, 65.65F, 79.544F];

//            return new
//            {
//                all_isSlow = floats.All(num => num > 0),
//                trueForAll_isFast = floats.TrueForAll(num => num > 0)
//            };
//        }

//        public IEnumerable<int> GetEnumeratorExtension()
//        {
//            foreach (int n in 3..5)
//            {
//                yield return n;
//            }
//            yield return 11118;
//            foreach (int n in ..3)
//            {
//                yield return n;
//            }
//            yield return 11118;
//            foreach (int n in ^3..)
//            {
//                yield return n;
//            }
//            yield return 11118;
//        }

//        public string SwitchCase(int number)
//        {
//            return number switch
//            {
//                1 => "one",
//                2 => "two",
//                3 => "three",
//                _ => "default case"
//            };
//        }

//        #region parallel-linq-heavy-computation
//        public (long, List<string>, ConcurrentDictionary<string, int[]>) ParallelLINQ(bool executeParallel)
//        {
//            return (executeParallel) ?
//                (WithParallel(), threadIdsList, threadMaps) :
//                (WithoutParallel(), threadIdsList, threadMaps);
//        }
//        private long WithoutParallel()
//        {
//            var stopWatch = Stopwatch.StartNew();

//            var collection = Enumerable.Range(0, 10)
//                .Select(HeavyComputation);

//            foreach (var _ in collection) ;

//            stopWatch.Stop();

//            return stopWatch.ElapsedMilliseconds;
//        }
//        private long WithParallel()
//        {
//            var stopWatch = Stopwatch.StartNew();

//            var collection = Enumerable.Range(0, 10)
//                .AsParallel()
//                .Select(HeavyComputation);

//            foreach (var _ in collection) ;

//            stopWatch.Stop();

//            return stopWatch.ElapsedMilliseconds;
//        }
//        private int HeavyComputation(int n)
//        {
//            threadIdsList.Add($"Working on thread {Environment.CurrentManagedThreadId}.");

//            threadMaps.AddOrUpdate(
//                key: $"thread {Environment.CurrentManagedThreadId}",
//                addValue: [n],
//                updateValueFactory: (keys, values) => [..values, n]);

//            for (int i = 0; i < 100_000_000; i++)
//            {
//                n += 1;
//            }

//            return n;
//        }
//        #endregion

//        #region sequential-linq-heavy-computation
//        public (long, List<string>, ConcurrentDictionary<string, int[]>) SequentialLINQ()
//        {
//            //--1
//            //return (WithAsSequential(), threadIdsList, threadMaps);

//            //--2
//            return (With_AsParallel_AsSequential(), threadIdsList, threadMaps);
//        }
//        private long WithAsSequential()
//        {
//            var stopWatch = Stopwatch.StartNew();


//            var collection = ParallelEnumerable.Range(0, 10)
//                .AsSequential()
//                .Select(HeavyComputation2);

//            foreach (var _ in collection) ;

//            stopWatch.Stop();

//            return stopWatch.ElapsedMilliseconds;
//        }
//        private long With_AsParallel_AsSequential()
//        {
//            var stopWatch = Stopwatch.StartNew();

//            var collection = Enumerable.Range(0, 10)
//                .AsParallel()
//                .Select(HeavyComputation2) // in parallel
//                .AsSequential()
//                .Select(HeavyComputation2); // sequentially

//            foreach (var _ in collection) ;

//            stopWatch.Stop();

//            return stopWatch.ElapsedMilliseconds;
//        }
//        private int HeavyComputation2(int n)
//        {
//            threadIdsList.Add($"Working on thread {Environment.CurrentManagedThreadId}: value is {n}");

//            threadMaps.AddOrUpdate(
//                key: $"thread {Environment.CurrentManagedThreadId}",
//                addValue: [n],
//                updateValueFactory: (keys, values) => [.. values, n]);

//            for (int i = 0; i < 100_000_000; i++)
//            {
//                n += 1;
//            }

//            return n;
//        }
//        #endregion

//        #region with-merge-options
//        public IEnumerable<string> WithMergeOptions1() => WithParallel3();
//        private IEnumerable<string> WithParallel3()
//        {
//            //var collection = MyRange(0, 10)
//            //    .Select(HeavyComputation3);

//            //var collection =  MyRange(0, 10)
//            //    .AsParallel()
//            //    .Select(HeavyComputation3);

//            var collection = MyRange(0, 10)
//                .AsParallel()
//                .WithMergeOptions(ParallelMergeOptions.NotBuffered)
//                .Select(HeavyComputation3);

//            foreach (var c in collection)
//            {
//                processingList.Add($"Consuming: {c}");
//            }

//            return processingList;
//        }
//        static IEnumerable<int> MyRange(int start, int count)
//        {
//            for (int i = start; i < start + count; i++)
//            {
//                yield return i;
//            }
//        }
//        private int HeavyComputation3(int n)
//        {
//            int c = n;
//            processingList.Add($"Processing: {n}");

//            for (int i = 0; i < 100_000_000; i++)
//            {
//                n += 1;
//            }

//            return c;
//        }
//        #endregion

//        #region partioning-withParallelExecution
//        public (long, List<string>, ConcurrentDictionary<string, int[]>) PartioningWithParallelExecution()
//        {
//            return (WithParallel4(), threadIdsList, threadMaps);
//        }
//        private long WithParallel4()
//        {
//            var stopWatch = Stopwatch.StartNew();

//            var collection = Enumerable.Range(0, 100)
//                .AsParallel()
//                .WithExecutionMode(ParallelExecutionMode.ForceParallelism)
//                .WithDegreeOfParallelism(2)
//                .Select((i, index) => HeavyComputation(i));//this is sequential in nature suppose then use WithExecutionMode(ParallelExecutionMode.ForceParallelism)

//            foreach (var  c in collection) ;

//            stopWatch.Stop();

//            return stopWatch.ElapsedMilliseconds;
//        }
//        #endregion

//        public (int, int[]) SortAscendingAndGet2ndLowest()
//        {
//            int[] arr = [12, 35, 1, 7, 1, 34, 35];

//            for(int i=0; i < arr.Length; i++)
//            {
//                for(int j=i+1; j<arr.Length; j++)
//                {
//                    if (arr[i] >= arr[j])
//                    {
//                        var temp = arr[i];
//                        arr[i] = arr[j];
//                        arr[j] = temp;
//                    }
//                }
//            }
//            HashSet<int> set = new(arr);
//            return (set.ToArray()[1], set.ToArray());
//        }

//        public List<int> AscendingSortFromMid()
//        {
//            int[] arr = [12, 35, 1, 7, 1, 34, 35];

//            List<int> arrList = new(), resList = new();
//            arrList.AddRange(arr);

//            var isOdd = arr.Length % 2 != 0;

//            if (!isOdd)
//            {
//                arrList.Add(0);
//            }

//            int midIndex = (int)Math.Ceiling(arrList.Count / 2.0) - 1;
            
//            for (int i=midIndex-1,j=midIndex+1, c=0; c < midIndex; c++)
//            {
//                int smallest = Math.Min(arrList[midIndex], Math.Min(arrList[i], arrList[j]));
//                int largest = Math.Max(arrList[midIndex], Math.Min(arrList[i], arrList[j]));

//                i--;
//                j++;
//            }

//            return arrList;
//        }

//        public UserResponse ImplicitOperatorExample()
//        {
//            User user = new()
//            {
//                id = 1362,
//                name = "Viru"
//            };

//            UserResponse userResponse = user;
//            userResponse.other = "Csharp";

//            return user;
//        }
//    }
//}
