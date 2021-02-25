using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace ConsoleApp1
{
	class Program
	{
		static List<ItemTest> items = new List<ItemTest>()
		{
			new ItemTest(1,"Item1","Item1Desc",true),
			new ItemTest(2,"Item2","Item2Desc",true),
			new ItemTest(3,"Item3","Item3Desc",true),
			new ItemTest(4,"Item4","Item4Desc",true),
			new ItemTest(5,"Item5","Item5Desc",true)
		};

		static List<Func<ItemTest, bool>> filters;

		static void Main(string[] args)

		{
			filters = new List<Func<ItemTest, bool>>();

			var found = new List<ItemTest>();

			filters.Add(i => i.Id > 2);
			filters.Add(i => i.Name == "Item3");

			filters.ForEach(f => found.AddRange(items.Where(f).ToList()));

			found = found.Distinct().ToList();
			//var found = items.Where(_filter).ToList();
			
			found.ForEach(i => Console.WriteLine(i.Name));
		}

		private IQueryable TestFilter<T>(IQueryable source, T term)
		{
			if (term is null) return source;

			Type elementType = source.ElementType;

			var termProperties =
				elementType.GetProperties()
					.Where(x => x.PropertyType == typeof(T))
					.ToArray();
			if (!termProperties.Any()) return source;

			string filterExpr = string.Join(" || ", termProperties.Select(p => $"{p.Name}.Contains({term})"));

			return source;
		}
	}

	class ItemTest
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public bool IsForSale { get; set; }

		public ItemTest(int id, string name, string description, bool isForSale)
		{
			Id = id;
			Name = name;
			Description = description;
			IsForSale = isForSale;
		}
	}
}
