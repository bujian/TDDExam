using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDExam
{
    class TestTexiPriceCalcular
    {
        [Test]
        public void Input_1_0_Should_Return_6()
        {
            TexiPriceCalculor cal = new TexiPriceCalculor();
            Assert.AreEqual(cal.GetPrice(new TexiPriceArgs(1, 0)), 6);
        }

        [Test]
        public void Input_3_0_Should_Return_7()
        {
            TexiPriceCalculor cal = new TexiPriceCalculor();
            Assert.AreEqual(cal.GetPrice(new TexiPriceArgs(3, 0)), 7);
        }

        [Test]
        public void Input_10_0_Should_Return_13()
        {
            TexiPriceCalculor cal = new TexiPriceCalculor();
            Assert.AreEqual(cal.GetPrice(new TexiPriceArgs(10, 0)), 13);
        }

        [Test]
        public void Input_2_0_Should_Return_7()
        {
            TexiPriceCalculor cal = new TexiPriceCalculor();
            Assert.AreEqual(cal.GetPrice(new TexiPriceArgs(2, 3)), 7);
        }
    }
}
