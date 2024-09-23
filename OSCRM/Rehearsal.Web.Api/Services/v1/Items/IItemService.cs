using System.Collections.Frozen;

namespace Rehearsal.Web.Api.Services.v1.Items
{
    public interface IItemService
    {
        IEnumerable<string[]> Random_Yield();
        dynamic SpreadOperator();
        string MinimumNullStatement();
        IDictionary<string, dynamic> JsonNode_JsonArray();
        IEnumerable<string> RandomShuffle();
        FrozenDictionary<int, string> FrozenDictCollection();
        FrozenSet<int> FrozenSetCollection();
    }
}
