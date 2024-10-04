using Microsoft.AspNetCore.Identity;
using System.Collections.Frozen;
using static Rehearsal.Web.Api.Services.v1.Items.ItemService;

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
        bool Foo(string parameter);
        string RelationalPattern1(float score);
        string PropertyPatternMatching1();
        AggregatedData[]? LINQMethodAggregate1();
        dynamic ProductBuilderPattern();
    }
}
