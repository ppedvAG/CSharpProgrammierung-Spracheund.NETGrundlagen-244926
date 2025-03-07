using M013_Exception;

namespace M013_Test;

[TestClass]
public class RechnerTests
{
    private Rechner r;

    [TestInitialize]
    public void Startup() => r = new Rechner();

    [TestCleanup]
    public void CleanUp() => r = null;

    ////////////////////////
    [TestMethod]
    [TestCategory("Addiere")]
    public void TesteAddiere()
    {
        double ergebnis = r.Addieren(4, 5);
        Assert.AreEqual(9, ergebnis);
    }

    [TestMethod]
    public void TesteSubtrahiere()
    {
        double ergebnis = r.Subtrahieren(4, 5);
        Assert.AreEqual(-1, ergebnis);
    }
}
