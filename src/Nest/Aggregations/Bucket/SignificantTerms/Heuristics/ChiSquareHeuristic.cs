using Newtonsoft.Json;

namespace Nest
{
	[JsonObject(MemberSerialization = MemberSerialization.OptIn)]
	[JsonConverter(typeof(ReadAsTypeJsonConverter<ChiSquareHeuristic>))]
	public interface IChiSquareHeuristic
	{
		[JsonProperty("background_is_superset")]
		bool? BackgroundIsSuperSet { get; set; }

		[JsonProperty("include_negatives")]
		bool? IncludeNegatives { get; set; }
	}

	public class ChiSquareHeuristic : IChiSquareHeuristic
	{
		public bool? BackgroundIsSuperSet { get; set; }
		public bool? IncludeNegatives { get; set; }
	}

	public class ChiSquareHeuristicDescriptor
		: DescriptorBase<ChiSquareHeuristicDescriptor, IChiSquareHeuristic>, IChiSquareHeuristic
	{
		bool? IChiSquareHeuristic.BackgroundIsSuperSet { get; set; }
		bool? IChiSquareHeuristic.IncludeNegatives { get; set; }

		public ChiSquareHeuristicDescriptor BackgroundIsSuperSet(bool? backgroundIsSuperSet = true) =>
			Assign(a => a.BackgroundIsSuperSet = backgroundIsSuperSet);

		public ChiSquareHeuristicDescriptor IncludeNegatives(bool? includeNegatives = true) =>
			Assign(a => a.IncludeNegatives = includeNegatives);
	}
}
