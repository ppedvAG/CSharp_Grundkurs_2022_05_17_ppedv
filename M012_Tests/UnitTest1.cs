using M012;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace M012_Tests
{
	[TestClass]
	public class UnitTest1
	{
		Rechner r;

		[TestInitialize] //Wird aufgerufen vor jedem Test
		public void Initialize()
		{
			r = new Rechner();
			System.Console.WriteLine("Rechner wurde erzeugt");
		}

		[TestCleanup] //Wird aufgerufen vor jedem Test
		public void Cleanup()
		{
			r = null;
		}

		[TestCategory("Erfolgstest")]
		[TestMethod]
		public void TesteAddiere()
		{
			int sum = r.Addiere(5, 2);
			Assert.AreEqual(7, sum);
		}

		[TestCategory("Fehlertest")]
		[TestMethod]
		public void TesteAddiereFehler()
		{
			int sum = r.Addiere(4, 8);
			Assert.AreNotEqual(7, sum);
		}
	}
}