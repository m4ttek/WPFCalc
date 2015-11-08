using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calc.viewmodel;

namespace Calc.test
{
    [TestClass]
    public class ViewModelTest
    {
        private MainWindowViewModel vm;

        [TestInitialize()]
        public void Initialize()
        {
            vm = new MainWindowViewModel();
        }

        [TestCleanup()]
        public void Cleanup()
        {
        }

        [TestMethod]
        public void TestAddTwoNumbers()
        {
            vm.ButtonCommand.Execute("5");
            vm.ButtonCommand.Execute("+");
            vm.ButtonCommand.Execute("4");
            vm.ButtonCommand.Execute("+");
            vm.ButtonCommand.Execute("3");
            vm.ButtonCommand.Execute("=");
            Assert.AreEqual("12", vm.CalculatorDisplay);
        }

        [TestMethod]
        public void TestDivideTwoNumbers()
        {
            vm.ButtonCommand.Execute("5");
            vm.ButtonCommand.Execute("/");
            vm.ButtonCommand.Execute("5");
            vm.ButtonCommand.Execute("/");
            vm.ButtonCommand.Execute("1");
            vm.ButtonCommand.Execute("=");
            Assert.AreEqual("1", vm.CalculatorDisplay);
        }

        [TestMethod]
        public void TestMultiplyTwoNumbers()
        {
            vm.ButtonCommand.Execute("5");
            vm.ButtonCommand.Execute("*");
            vm.ButtonCommand.Execute("4");
            vm.ButtonCommand.Execute("+/-");
            vm.ButtonCommand.Execute("*");
            vm.ButtonCommand.Execute("3");
            vm.ButtonCommand.Execute("=");
            Assert.AreEqual("-60", vm.CalculatorDisplay);
        }

        [TestMethod]
        public void TestSquareRoot()
        {
            vm.ButtonCommand.Execute("9");
            vm.ButtonCommand.Execute("sqrt");
            Assert.AreEqual("3", vm.CalculatorDisplay);
        }

        [TestMethod]
        public void TestPercentage()
        {
            vm.ButtonCommand.Execute("9");
            vm.ButtonCommand.Execute("%");
            Assert.AreEqual("0,09", vm.CalculatorDisplay);
        }

        [TestMethod]
        public void TestNumberInput()
        {
            vm.ButtonCommand.Execute("0");
            vm.ButtonCommand.Execute("9");
            vm.ButtonCommand.Execute("0");
            vm.ButtonCommand.Execute(".");
            vm.ButtonCommand.Execute(".");
            vm.ButtonCommand.Execute("0");
            vm.ButtonCommand.Execute("2");
            vm.ButtonCommand.Execute(".");
            Assert.AreEqual("90,02", vm.CalculatorDisplay);
        }

        [TestMethod]
        public void TestClearDisplay()
        {
            vm.CalculatorDisplay = "23";
            vm.ButtonCommand.Execute("+");
            vm.ButtonCommand.Execute("23");
            vm.ButtonCommand.Execute("C");
            Assert.AreEqual("0", vm.CalculatorDisplay);
        }

        [TestMethod]
        public void TestShowError()
        {
            vm.ButtonCommand.Execute("5");
            vm.ButtonCommand.Execute("/");
            Assert.IsTrue(vm.IsEnabled);

            vm.ButtonCommand.Execute("0");
            vm.ButtonCommand.Execute("=");
            Assert.AreEqual("ERR", vm.CalculatorDisplay);
            Assert.IsFalse(vm.IsEnabled);
        }

        [TestMethod]
        public void TestShowErrorFromSquareRoot()
        {
            vm.ButtonCommand.Execute("5");
            vm.ButtonCommand.Execute("+/-");
            Assert.IsTrue(vm.IsEnabled);

            vm.ButtonCommand.Execute("sqrt");
            Assert.AreEqual("ERR", vm.CalculatorDisplay);
            Assert.IsFalse(vm.IsEnabled);
        }

        [TestMethod]
        public void TestTryToCalculateAfterError()
        {
            TestShowErrorFromSquareRoot();
            vm.ButtonCommand.Execute("0");
            Assert.AreEqual("ERR", vm.CalculatorDisplay);
            Assert.IsFalse(vm.IsEnabled);
            vm.ButtonCommand.Execute("+");
            Assert.AreEqual("ERR", vm.CalculatorDisplay);
            Assert.IsFalse(vm.IsEnabled);
            vm.ButtonCommand.Execute("1");
            Assert.AreEqual("ERR", vm.CalculatorDisplay);
            Assert.IsFalse(vm.IsEnabled);
            vm.ButtonCommand.Execute("=");
            Assert.AreEqual("ERR", vm.CalculatorDisplay);
            Assert.IsFalse(vm.IsEnabled);
        }

    }
}
