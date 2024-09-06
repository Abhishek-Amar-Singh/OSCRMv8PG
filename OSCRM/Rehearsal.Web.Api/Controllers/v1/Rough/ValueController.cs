
//using Microsoft.AspNetCore.Mvc;
//using Rehearsal.Web.Api.Services.Values;

//namespace Rehearsal.Web.Api.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ValueController : ControllerBase
//    {
//        private readonly IValueService _valueService;

//        public ValueController(IValueService _valueService) =>
//            this._valueService = _valueService;

//        #region random-yield
//        [HttpGet]
//        [Route("random-yield")]
//        public ActionResult Random_Yield()
//        {
//            var response = this._valueService.Random_Yield();

//            return Ok(response);
//        }
//        #endregion

//        #region spread-operator
//        [HttpGet]
//        [Route("spread-operator")]
//        public ActionResult SpreadOperator()
//        {
//            var response = this._valueService.SpreadOperator();

//            return Ok(response);
//        }
//        #endregion

//        #region use-minimum-null-statement
//        [HttpGet]
//        [Route("use-minimum-null-statement")]
//        public ActionResult MinimumNullStatement()
//        {
//            var response = this._valueService.MinimumNullStatement();

//            return Ok(response);
//        }
//        #endregion

//        #region jsonNode-and-jsonArray
//        [HttpGet]
//        [Route("jsonNode-and-jsonArray")]
//        public ActionResult JsonNode_JsonArray()
//        {
//            var response = this._valueService.JsonNode_JsonArray();

//            return Ok(response);
//        }
//        #endregion

//        #region random-shuffle
//        [HttpGet]
//        [Route("random-shuffle")]
//        public ActionResult RandomShuffle()
//        {
//            var response = this._valueService.RandomShuffle();

//            return Ok(response);
//        }
//        #endregion

//        #region frozen-dict-collection
//        [HttpGet]
//        [Route("frozen-dict-collection")]
//        public ActionResult FrozenDictCollection()
//        {
//            var response = this._valueService.FrozenDictCollection();

//            return Ok(response);
//        }
//        #endregion

//        #region frozen-set-collection
//        [HttpGet]
//        [Route("frozen-set-collection")]
//        public ActionResult FrozenSetCollection()
//        {
//            var response = this._valueService.FrozenSetCollection();

//            return Ok(response);
//        }
//        #endregion

//        #region custom-linq-whereEven
//        [HttpGet]
//        [Route("custom-linq-whereEven")]
//        public ActionResult CustomLinqWhereEven()
//        {
//            var response = this._valueService.CustomLinqWhereEven();

//            return Ok(response);
//        }
//        #endregion

//        #region throw-and-throwEx
//        [HttpGet]
//        [Route("throw-and-throwEx")]
//        public ActionResult Throw_ThrowEx(string parameter = "throw")
//        {
//            try
//            {
//                var response = this._valueService.Foo(parameter);

//                return Ok(response);
//            }
//            catch (Exception e)
//            {
//                return BadRequest(e);
//            }
//        }
//        #endregion

//        #region lambda-example-1
//        [HttpGet]
//        [Route("lambda-example-1")]
//        public ActionResult LambdaExample1(double baseNumber, double? exponent)
//        {
//            var response = this._valueService.LambdaExample1(baseNumber, exponent);

//            return Ok(response);
//        }
//        #endregion

//        #region relational-pattern-1
//        [HttpGet]
//        [Route("relational-pattern-1")]
//        public ActionResult RelationalPattern1(float score) =>
//            Ok(this._valueService.RelationalPattern1(score));
//        #endregion

//        #region property-pattern-matching-1
//        [HttpGet]
//        [Route("property-pattern-matching-1")]
//        public ActionResult PropertyPatternMatching1() =>
//            Ok(this._valueService.PropertyPatternMatching1());
//        #endregion

//        #region linq-method-aggregate-1
//        [HttpGet]
//        [Route("linq-method-aggregate-1")]
//        public ActionResult LINQMethodAggregate1() =>
//            Ok(this._valueService.LINQMethodAggregate1());
//        #endregion

//        #region endsWith-with-string-and-char
//        [HttpGet]
//        [Route("endsWith-with-string-and-char")]
//        public ActionResult EndsWithWithStringAndChar(string text) =>
//            Ok(this._valueService.EndsWithWithStringAndChar(text));
//        #endregion

//        #region parallel-foreach
//        [HttpGet]
//        [Route("parallel-foreach")]
//        public ActionResult ParallelForEach() =>
//            Ok(this._valueService.ParallelForEach());
//        #endregion

//        #region math-clamp
//        [HttpGet]
//        [Route("math-clamp")]
//        public ActionResult MathClamp() =>
//            Ok(this._valueService.MathClamp());
//        #endregion

//        #region efficient-dataStructures-containsDuplicates
//        [HttpGet]
//        [Route("contains-duplicates")]
//        public ActionResult ContainsDuplicates() =>
//            Ok(this._valueService.ContainsDuplicates());
//        #endregion

//        #region linq-pagination
//        [HttpGet]
//        [Route("linq-pagination")]
//        public ActionResult LinqPagination() =>
//            Ok(this._valueService.LinqPagination());
//        #endregion

//        #region all-and-trueForAll
//        [HttpGet]
//        [Route("all-and-trueForAll")]
//        public ActionResult All_TrueForAll() =>
//            Ok(this._valueService.All_TrueForAll());
//        #endregion

//        #region get-enumerator-extension
//        [HttpGet]
//        [Route("get-enumerator-extension")]
//        public ActionResult GetEnumeratorExtension() =>
//            Ok(this._valueService.GetEnumeratorExtension());
//        #endregion

//        #region switch-case
//        [HttpGet]
//        [Route("switch-case")]
//        public ActionResult SwitchCase(int number) =>
//            Ok(this._valueService.SwitchCase(number));
//        #endregion

//        #region parallel-linq-heavy-computation
//        //--use of concurrent dictionary
//        //--use of threads
//        //--use of AsParallel() method for linq
//        //--In parallelism what happend is result ramdomly goes to output-buffer and based on that we get the o/p.
//        //--AsParallel().AsOrdered().AsUnordered()
//        //--ParallelEnumerable.Range, ParallelEnumerable.Repeat, ParallelEnumerable.Empty
//        //--AsSequential is the opposite of AsParallel
//        /*
//         * 
//            var collection = Enumerable.Range(0, 10)
//                .AsParallel()
//                .WithDegreeOfParallelism(2)//creat 2 tasks //Partioning
//                .Select(HeavyComputation);
//        */
//        [HttpGet]
//        [Route("parallel-linq-heavy-computation")]
//        public ActionResult ParallelLINQ(bool executeParallel) =>
//            Ok(this._valueService.ParallelLINQ(executeParallel));
//        #endregion

//        #region sequential-linq-heavy-computation
//        //--use of ParallelEnumerable.Range, AsSequential()
//        //--use of Enumerable.Range, AsParallel(), AsSequential()
//        /*
//        var cts = new CancellationTokenSource();
//        var collection = Enumerable.Range(0, 10)
//            .AsParallel()
//            .WithCancellation(cts.Token)
//            .Select(HeavyComputation2) // in parallel
//            .AsSequential()
//            .Select(HeavyComputation2); // sequentially
//        cts.Cancel();
//        */
//        [HttpGet]
//        [Route("sequential-linq-heavy-computation")]
//        public ActionResult SequentialLINQ() =>
//            Ok(this._valueService.SequentialLINQ());
//        #endregion

//        #region with-merge-options
//        [HttpGet]
//        [Route("with-merge-options")]
//        public ActionResult WithMergeOptions1() =>
//            Ok(this._valueService.WithMergeOptions1());
//        #endregion

//        #region partioning-withParallelExecution
//        [HttpGet]
//        [Route("partioning-withParallelExecution")]
//        public ActionResult PartioningWithParallelExecution() =>
//            Ok(this._valueService.PartioningWithParallelExecution());
//        #endregion

//        #region sort-ascending-and-get-2nd-lowest
//        [HttpGet]
//        [Route("sort-ascending-and-get-2nd-lowest")]
//        public ActionResult SortAscendingAndGet2ndLowest() =>
//            Ok(this._valueService.SortAscendingAndGet2ndLowest());
//        #endregion

//        #region ascending-sort-from-mid
//        [HttpGet]
//        [Route("ascending-sort-from-mid")]
//        public ActionResult AscendingSortFromMid() =>
//            Ok(this._valueService.AscendingSortFromMid());
//        #endregion

//        #region implicit-operator-example
//        [HttpGet]
//        [Route("implicit-operator-example")]
//        public ActionResult ImplicitOperatorExample() =>
//            Ok(this._valueService.ImplicitOperatorExample());
//        #endregion
//    }
//}
