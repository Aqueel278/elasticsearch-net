﻿using System.Threading.Tasks;
using Elastic.Xunit.XunitPlumbing;
using Nest;
using Tests.Domain;
using Tests.Framework;
using static Nest.Indices;
using static Nest.Types;
using static Tests.Framework.UrlTester;

namespace Tests.Indices.IndexManagement.TypeExists
{
	public class TypeExistsUrlTests
	{
		[U] public async Task Urls()
		{
			var indices = Index<Project>().And<Developer>();
			var index = "project%2Cdevs";
			var types = Type<Project>().And<Developer>();
			var type = "doc%2Cdeveloper";
			await HEAD($"/{index}/_mapping/{type}")
					.Fluent(c => c.TypeExists(indices, types))
					.Request(c => c.TypeExists(new TypeExistsRequest(indices, types)))
					.FluentAsync(c => c.TypeExistsAsync(indices, types))
					.RequestAsync(c => c.TypeExistsAsync(new TypeExistsRequest(indices, types)))
				;
		}
	}
}
