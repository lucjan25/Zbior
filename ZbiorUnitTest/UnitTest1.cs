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

            Assert.AreEqual(liczba1, zbior[0], "B³¹d dodawania elementu");
            Assert.AreEqual(liczba1, zbior[1], "B³¹d dodawania elementu");
            Assert.AreEqual(liczba2, zbior[2], "B³¹d dodawania elementu");
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

            Assert.IsFalse(usuniety, "B³¹d usuwania elementu");
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

            Assert.IsFalse(usuniety, "B³¹d losowego usuwania elementu");
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

            Assert.AreEqual(0, suma0, "B³¹d sumowania zbioru bez elementów");
            Assert.AreEqual(55, suma55, "B³¹d sumowania elementów");
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

            Assert.AreEqual(liczba1, zbior[0], "B³¹d dzielenia elementów");
            Assert.AreEqual(liczba2, zbior[1], "B³¹d dzielenia elementów");
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
            
            Assert.IsTrue(sprawdzliczba1, "B³¹d sprawdzania istnienia istniej¹cego elementu");
            Assert.IsTrue(sprawdzliczba2, "B³¹d sprawdzania istnienia istniej¹cego elementu");
            Assert.IsFalse(sprawdznieliczba, "B³¹d sprawdzania istnienia nieistniej¹cego elementu");
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

            Assert.AreEqual(0, rozmiarstart, "B³êdny rozmiar nowego zbioru");
            Assert.AreEqual(2, rozmiarkoniec, "B³êdny rozmiar zbioru z dodanymi elementami");
        }
    }
}
