using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L2SGoodies.Data
{
	public partial class TestDataContext
	{		
		public TestDataContext() : this(@"Data Source=.;Initial Catalog=Test;Integrated Security=True") { }
		
	}
}
