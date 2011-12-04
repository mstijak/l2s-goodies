using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetaTest;
using L2SGoodies.Data;
using System.Data.Linq;

namespace L2SGoodies.Tests.Benchmark
{
	[TestFixture]
	class GetByIdBenchmark
	{
		const int N = 1000;
		[Test]
		public void WarmUp()
		{
			using (var db = new TestDataContext())
			{
				var p = db.Persons.FirstOrDefault(a => a.PersonId == 1);
				var p2 = db.FindPersonById(1);
				Assert.AreEqual(p, p2);
			}
		}

		[Test]
		public void CreateAndDisposeContext()
		{
			for (var i = 0; i < N; i++)
			{
				using (var db = new TestDataContext())
				{					
				}
			}
		}

		[Test]
		public void CustomCompiledGetterExistingEntity()
		{
			for (var i = 0; i < N; i++)
			{
				using (var db = new TestDataContext())
				{
					var p = compiledPersonGetter(db, 1).AsEnumerable().FirstOrDefault();
					Assert.IsNotNull(p);
					//Assert.AreEqual(1, p.Length);
				}
			}
		}

		[Test]
		public void FirstOrDefaultNonExistingEntity()
		{
			for (var i = 0; i < N; i++)
			{
				using (var db = new TestDataContext())
				{
					var p = db.Persons.FirstOrDefault(a => a.PersonId == 0);
					Assert.IsNull(p);
				}
			}
		}

		[Test]
		public void FirstOrDefaultExistingEntity()
		{
			for (var i = 0; i < N; i++)
			{
				using (var db = new TestDataContext())
				{
					var p = db.Persons.FirstOrDefault(a => a.PersonId == 1);
					Assert.IsNotNull(p);
				}
			}
		}

		[Test]
		public void FindByIdNonExistingEntity()
		{
			for (var i = 0; i < N; i++)
			{
				using (var db = new TestDataContext())
				{
					var p = db.FindPersonById(0);
					Assert.IsNull(p);
				}
			}
		}

		[Test]
		public void FindByIdExistingEntity()
		{
			for (var i = 0; i < N; i++)
			{
				using (var db = new TestDataContext())
				{
					var p = db.FindPersonById(1);
					Assert.IsNotNull(p);
				}
			}
		}

		static readonly Func<TestDataContext, System.Int32, IQueryable<Person>> compiledPersonGetter = CompiledQuery.Compile((TestDataContext dc, System.Int32 _PersonId) => dc.Persons.Where(a => a.PersonId == _PersonId));

		
	}
}
