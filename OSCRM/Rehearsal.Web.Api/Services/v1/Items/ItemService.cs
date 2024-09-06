
using System.Text.Json.Nodes;//JsonNode, JsonArray

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


    }
}
