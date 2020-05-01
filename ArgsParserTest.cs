using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDExam
{
    class ArgsParserTest
    {
        [Test]
        public void Test_SingleInfo()
        {
            ArgsParser parser = new ArgsParser("1公里,等待0分钟");
            var args = parser.GetArgs();
            Assert.AreEqual(args[0].Mileage, 1);
            Assert.AreEqual(args[0].Waiting, 0);
        }

        [Test]
        public void Test_TwoInfo()
        {
            ArgsParser parser = new ArgsParser("1公里,等待0分钟\n2公里,等待5分钟");
            var args = parser.GetArgs();
            Assert.AreEqual(args[0].Mileage, 1);
            Assert.AreEqual(args[0].Waiting, 0);
            Assert.AreEqual(args[1].Mileage, 2);
            Assert.AreEqual(args[1].Waiting, 5);
        }

        [Test]
        public void Test_InvalidParam_LackOfChars()
        {
            ArgsParser parser = new ArgsParser("1公里,等待0分钟\n2公里,等待5");
            var args = parser.GetArgs();
            Assert.AreEqual(args[0].Mileage, 1);
            Assert.AreEqual(args[0].Waiting, 0);
            Assert.AreEqual(args.Count, 1);
        }

        [Test]
        public void Test_InvalidParam_InvalidSeperator()
        {
            ArgsParser parser = new ArgsParser("1公里,等待0分钟\n2公里，等待5分钟");
            var args = parser.GetArgs();
            Assert.AreEqual(args[0].Mileage, 1);
            Assert.AreEqual(args[0].Waiting, 0);
            Assert.AreEqual(args.Count, 1);
        }
    }
}
