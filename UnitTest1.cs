using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

public class HerniPostava
{
    private string jmeno;
    private int level;
    private int poziceX;
    private int poziceY;

    public string Jmeno
    {
        get { return jmeno; }
        set
        {
            if (value.Length > 10)
            {
                Console.WriteLine("Příliš dlouhé jméno!");
                jmeno = null;
            }
            else
            {
                jmeno = value;
            }
        }
    }

    public int Level
    {
        get { return level; }
        set { }
    }

    public int PoziceX
    {
        get { return poziceX; }
    }

    public int PoziceY
    {
        get { return poziceY; }
    }

    public HerniPostava(string jmeno = "")
    {
        this.Jmeno = jmeno;
        this.level = 1;
        this.poziceX = 0;
        this.poziceY = 0;
    }

    public void ZmenaPozice(int novaPoziceX, int novaPoziceY)
    {
        // Simulace kliknutí levým tlačítkem myši a přepočítání souřadnic
        this.poziceX = novaPoziceX;
        this.poziceY = novaPoziceY;
    }

    public string ToString()
    {
        return $"Jméno: {Jmeno}, Level: {Level}, Pozice X: {PoziceX}, Pozice Y: {PoziceY}";
    }
}

namespace HerniPostavaTests
{
    [TestClass]
    public class HerniPostavaTests
    {
        /*[TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Jmeno_SetToNull_ShouldNotThrowException()
        {
            // Arrange
            HerniPostava tonda = new HerniPostava();

            // Act
            tonda.Jmeno = null;
        }*/

        [TestMethod]
        public void Level_SetToNegative_ShouldNotChangeLevel()
        {
            // Arrange
            HerniPostava tonda = new HerniPostava();

            // Act
            tonda.Level = -5;

            // Assert
            Assert.AreEqual(1, tonda.Level);
        }

        [TestMethod]
        public void ToString_EmptyName_ShouldIncludeDefaultName()
        {
            // Arrange
            HerniPostava tonda = new HerniPostava();

            // Act
            string result = tonda.ToString();

            // Assert
            StringAssert.Contains(result, "Jméno: , Level: 1, Pozice X: 0, Pozice Y: 0");
        }

        [TestMethod]
        public void ToString_CustomName_ShouldIncludeCustomName()
        {
            // Arrange
            HerniPostava tonda = new HerniPostava("CustomName");

            // Act
            string result = tonda.ToString();

            // Assert
            Assert.AreEqual("Jméno: CustomName, Level: 1, Pozice X: 0, Pozice Y: 0", result);
        }
        [TestMethod]
        public void level1je()
        {
            HerniPostava tonda = new HerniPostava();
            int level = tonda.Level;
            Assert.AreEqual(1, level);
        }
        [TestMethod]
        public void level1neni()
        {
            HerniPostava tonda = new HerniPostava();
            int level = tonda.Level;
            Assert.AreNotEqual(1, level);
        }
        [TestMethod]
        public void Jmeno10Kratsi()
        {
            // Arrange
            HerniPostava tonda = new HerniPostava();

            // Act
            tonda.Jmeno = "Tonda";

            // Assert
            Assert.IsTrue(tonda.Jmeno.Length <= 10);
        }
        [TestMethod]
        public void Jmeno10Delsi ()
        {
            // Arrange
            HerniPostava tonda = new HerniPostava();

            // Act
            tonda.Jmeno = "Tonda";

            // Assert
            Assert.IsTrue(tonda.Jmeno.Length > 10);
        }
        [TestMethod]
        public void PoziceX_InitializedToZero()
        {
            // Arrange
            HerniPostava tonda = new HerniPostava();

            // Act
            int poziceX = tonda.PoziceX;

            // Assert
            Assert.AreEqual(0, poziceX);
        }
        [TestMethod]
        public void PoziceY_InitializedToZero()
        {
            // Arrange
            HerniPostava tonda = new HerniPostava();

            // Act
            int poziceY = tonda.PoziceY;

            // Assert
            Assert.AreEqual(0, poziceY);
        }
        [TestMethod]
        public void PoziceX_InitializedToZeroNo()
        {
            // Arrange
            HerniPostava tonda = new HerniPostava();

            // Act
            int poziceX = tonda.PoziceX;

            // Assert
            Assert.AreNotEqual(0, poziceX);
        }
        [TestMethod]
        public void PoziceY_InitializedToZeroNo()
        {
            // Arrange
            HerniPostava tonda = new HerniPostava();

            // Act
            int poziceY = tonda.PoziceY;

            // Assert
            Assert.AreNotEqual(0, poziceY);
        }
    }
    // Pomocná třída pro zachytávání výstupu na konzoli
    public class TestConsoleWriter : System.IO.TextWriter
    {
        private readonly System.IO.TextWriter _originalConsoleOut;
        private readonly Action<string> _writeAction;

        public TestConsoleWriter(System.IO.TextWriter originalConsoleOut, Action<string> writeAction)
        {
            _originalConsoleOut = originalConsoleOut;
            _writeAction = writeAction;
        }

        public override void Write(string value)
        {
            _originalConsoleOut.Write(value);
            _writeAction(value);
        }

        public override void WriteLine(string value)
        {
            _originalConsoleOut.WriteLine(value);
            _writeAction(value);
        }

        public override System.Text.Encoding Encoding
        {
            get { return System.Text.Encoding.UTF8; }
        }
    }
}