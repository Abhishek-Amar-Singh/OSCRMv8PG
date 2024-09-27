
using System.Text.Json.Nodes;//JsonNode, JsonArray
using System.Collections.Frozen;//FrozenDictionary

namespace Rehearsal.Web.Api.Services.v1.Items
{
    public class ItemService : IItemService
    {
        public IEnumerable<string[]> Random_Yield()
        {
            string[] musicians =
            {
                "Lucky Ali",
                "Mohit Chauhan",
                "Jagjit Singh",
                "Vishal Mishra",
                "Abhijit Sawant",
                "Arijit Singh",
                "Atif Aslam",
                "Kishore Kumar",
                "Papon",
                "Salim Merchant",
                "Rahat Fateh Ali Khan"
            };

            for (int i = 0; i < 5; i++)
            {
                string[] choices = Random.Shared.GetItems(musicians, 2);

                yield return choices;
            }
        }

        public dynamic SpreadOperator()
        {
            int[] a = [1, 2, 3];
            int[] b = [4, 5, 6];

            //1st way
            int[] e = new int[a.Length + b.Length];
            a.CopyTo(e, 0);
            b.CopyTo(e, a.Length);

            //2nd way
            int[] f = [];
            f = a.ToArray().Concat(b).ToArray();

            //3rd way
            int[] d = [.. a, .. b];

            return new
            {
                using_CopyTo = e,
                using_Concat = f,
                using_spread = d
            };
        }

        #region minimum-null-statement
        public record ClassA();
        public string MinimumNullStatement()
        {
            ClassA? a = null;
            if (a is null) a = new();

            ClassA? b = null;
            b = b is null ? new() : b;

            ClassA? c = null;
            c = c ?? new();

            ClassA? d = null;
            d ??= new();//mimiumum null statement

            return "ClassA? d = null; d ??= new();";
        }
        #endregion

        public IDictionary<string, dynamic> JsonNode_JsonArray()
        {
            var json = """
                {
                "name": "DotNet Core",
                "version": [3.1, 5, 6, 7, 8],
                "language": "C#"
                }
                """;

            JsonNode? node = JsonNode.Parse(json);
            JsonNode other = node!.DeepClone();
            var flag = JsonNode.DeepEquals(node, other);

            JsonArray jsonArray = new JsonArray(1, 2, 5, 4, 7, 8);
            IEnumerable<int> values = jsonArray.GetValues<int>().Where(i => i % 2 == 0);

            return new Dictionary<string, dynamic>
            {
                { "Two JsonNodes comparison using DeepEquals() method", flag},
                { "View JsonArray values", values }
            };

        }

        public IEnumerable<string> RandomShuffle()
        {
            string[] musicians =
            {
                "Lucky Ali",
                "Mohit Chauhan",
                "Jagjit Singh",
                "Vishal Mishra",
                "Abhijit Sawant",
                "Arijit Singh",
                "Atif Aslam",
                "Kishore Kumar",
                "Papon"
            };

            Random.Shared.Shuffle(musicians);

            return musicians;
        }


        public FrozenDictionary<int, string> FrozenDictCollection()
        {
            var frozenDict = new Dictionary<int, string>()
                    {
                        {2001, "The Fast and the Furious" },
                        {2003, "2 Fast 2 Furious" },
                        {2006, "The Fast and the Furious: Tokyo Drift" },
                        {2009, "Fast & Furious" },
                        {2011, "Fast Five" },
                        {2013, "Fast & Furious 6" },
                        {2015, "Furious 7" },
                        {2017, "The Fate of the Furious" },
                        {2021, "F9" },
                        {2023, "Fast X"}
                    }.ToFrozenDictionary();

            return frozenDict;
        }

        public FrozenSet<int> FrozenSetCollection()
        {
            var frozenSet = new List<int>() { 1, 2, 3, 4, 5, 100, 200, 100 }.ToFrozenSet();

            return frozenSet;
        }

        #region throw-and-throwEx
        public bool Foo(string parameter)
        {
            try
            {
                if (!new[] { "throw", "throwEx" }.Contains(parameter))
                {
                    throw new Exception("Only throw and throwEx parameters are allowed.");
                }

                return Bar();
            }
            catch (Exception e)
            {
                if (parameter == "throw")
                {
                    throw;
                }
                else
                {
                    throw e;
                }
            }
        }
        private bool Bar() =>
            throw new Exception("Exception occurs in Rehearsal.Web.Api.Services.ValueService.Bar()");
        #endregion

        public string RelationalPattern1(float score)
        {
            if (score is >= 35 and <= 100)
            {
                return "Passed the exam.";
            }
            else if (score is >= 0 and <=34)
            {
                return "Failed the exam.";
            }
            else
            {
                return "Invalid score.";
            }
           
        }

        #region property-pattern-matching-1
        class Person
        {
            public string name { get; set; } = null!;
            public Location? location { get; set; }
        }
        class Location
        {
            public string? country { get; set; }
            public string? city { get; set; }
        }
        public string PropertyPatternMatching1()
        {
            Person person = new()
            {
                name = "Doraemon",
                location = new() { country = "Japan", city = "Tokyo" }
            };

            return (person is { name: "Doraemon", location.country: "Japan" }) ? "It's me." : "It's not me.";
        }
        #endregion

        #region linq-method-aggregate-1
        public class AggregatedData
        {
            public string category { get; set; } = null!;
            public int amount_sum { get; set; }
        }

        public AggregatedData[]? LINQMethodAggregate1()
        {
            (string category, int amount)[] data =
            {
                ("A", 2),
                ("B", 3),
                ("A", 10),
                ("B", 58),
                ("C", 72),
            };

            var aggregatedData = data
                .GroupBy(d => d.category)
                .Select(g => new AggregatedData { category = g.Key, amount_sum = g.Sum(d => d.amount)})
                .ToArray();

            // .NET 9
            //var aggregatedData =
            //    data.AggregateBy(
            //        keySelector: entry => entry.Category,
            //        seed: 0,
            //        (totalLength, currentItem) => totalLength + currentItem.amount
            //    );

            return aggregatedData;
        }
        #endregion
    }
}
