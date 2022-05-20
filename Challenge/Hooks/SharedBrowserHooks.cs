using BoDi;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace Challenge.Hooks
{
	[Binding]
	public sealed class SharedBrowserHooks
	{
		[BeforeTestRun]
		public static void BeforeTestRun(ObjectContainer testThreadContainer)
		{
			testThreadContainer.BaseContainer.Resolve<InitialHooks>();
		}
	}
}
