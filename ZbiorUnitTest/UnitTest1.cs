using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZbiorBiblioteka;
using System;

namespace ZbiorUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestDodaj()
        {
            Zbior TestZbior = new Zbior();
            int liczba1 = 5;
            int liczba2 = 50;

            TestZbior.dodaj(liczba1);
            TestZbior.dodaj(liczba1);
            TestZbior.dodaj(liczba2);

            PrivateObject po = new PrivateObject(TestZbior);
            int[] zbior = (int[])po.GetField("zbior");

            Assert.AreEqual(liczba1, zbior[0], "B��d dodawania elementu");
            Assert.AreEqual(liczba1, zbior[1], "B��d dodawania elementu");
            Assert.AreEqual(liczba2, zbior[2], "B��d dodawania elementu");
        }
        [TestMethod]
        public void TestUsun()
        {
            Zbior TestZbior = new Zbior();
            int liczba1 = 5;
            int liczba2 = 50;

            TestZbior.dodaj(liczba1);
            TestZbior.dodaj(liczba2);
            TestZbior.usun(liczba1);

            bool usuniety = TestZbior.sprawdz(liczba1);

            Assert.IsFalse(usuniety, "B��d usuwania elementu");
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestUsunException()
        {
            Zbior TestZbior = new Zbior();
            int liczba1 = 5;
            int liczba2 = 50;

            TestZbior.dodaj(liczba1);
            TestZbior.usun(liczba2);
        }
        [TestMethod]
        public void TestLosuj()
        {
            Zbior TestZbior = new Zbior();
            int liczba1 = 5;
            int liczba2 = 50;

            TestZbior.dodaj(liczba1);
            TestZbior.dodaj(liczba2);
            int elementLosowy = TestZbior.losuj();

            bool usuniety = TestZbior.sprawdz(elementLosowy);

            Assert.IsFalse(usuniety, "B��d losowego usuwania elementu");
        }
        [TestMethod]
        public void TestSuma()
        {
            Zbior TestZbior = new Zbior();
            int suma0 = TestZbior.pobierzSume();
            int liczba1 = 5;
            int liczba2 = 50;

            TestZbior.dodaj(liczba1);
            TestZbior.dodaj(liczba2);
            int suma55 = TestZbior.pobierzSume();

            Assert.AreEqual(0, suma0, "B��d sumowania zbioru bez element�w");
            Assert.AreEqual(55, suma55, "B��d sumowania element�w");
        }
        [TestMethod]
        public void TestIloraz()
        {
            Zbior TestZbior = new Zbior();
            int liczba1 = 5;
            int liczba2 = 50;

            TestZbior.dodaj(liczba1);
            TestZbior.dodaj(liczba2);
            TestZbior.iloraz_elem(3);

            PrivateObject po = new PrivateObject(TestZbior);
            int[] zbior = (int[])po.GetField("zbior");
            liczba1 /= 3;
            liczba2 /= 3;

            Assert.AreEqual(liczba1, zbior[0], "B��d dzielenia element�w");
            Assert.AreEqual(liczba2, zbior[1], "B��d dzielenia element�w");
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestIlorazException()
        {
            Zbior TestZbior = new Zbior();
            
            TestZbior.iloraz_elem(0);
        }
        [TestMethod]
        public void TestSprawdz()
        {
            Zbior TestZbior = new Zbior();
            int liczba1 = 5;
            int liczba2 = 50;

            TestZbior.dodaj(liczba1);
            TestZbior.dodaj(liczba2);

            bool sprawdzliczba1 = TestZbior.sprawdz(liczba1);
            bool sprawdzliczba2 = TestZbior.sprawdz(liczba2);
            bool sprawdznieliczba = TestZbior.sprawdz(-10);
            
            Assert.IsTrue(sprawdzliczba1, "B��d sprawdzania istnienia istniej�cego elementu");
            Assert.IsTrue(sprawdzliczba2, "B��d sprawdzania istnienia istniej�cego elementu");
            Assert.IsFalse(sprawdznieliczba, "B��d sprawdzania istnienia nieistniej�cego elementu");
        }
        [TestMethod]
        public void TestRozmiar()
        {
            Zbior TestZbior = new Zbior();
            int rozmiarstart = TestZbior.pobierz_rozmiar();
            int liczba1 = 5;
            int liczba2 = 50;

            TestZbior.dodaj(liczba1);
            TestZbior.dodaj(liczba2);
            int rozmiarkoniec = TestZbior.pobierz_rozmiar();

            Assert.AreEqual(0, rozmiarstart, "B��dny rozmiar nowego zbioru");
            Assert.AreEqual(2, rozmiarkoniec, "B��dny rozmiar zbioru z dodanymi elementami");
        }
    }
}
