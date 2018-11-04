using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using SWApi;

namespace SWAUnitTest
{
    [TestClass]
    public class UnitTest1
    {

        /**************************************************/
        /*               STOPS FOR RESUPPLY               */
        /**************************************************/
        [TestMethod]
        public void Jump_Calculations_Exactly()
        {
            var resultJumps = SWAHellper.CalculateStopsForDestination("30", "15");

            Assert.AreEqual("1", resultJumps);
        }

        [TestMethod]
        public void Jump_Calculations_Over()
        {
            var resultJumps = SWAHellper.CalculateStopsForDestination("40", "15");

            Assert.AreEqual("2", resultJumps);
        }

        [TestMethod]
        public void Jump_Calculations_Below()
        {
            var resultJumps = SWAHellper.CalculateStopsForDestination("15", "22");

            Assert.AreEqual("0", resultJumps);
        }


        [TestMethod]
        public void Jump_Calculations_No_Go()
        {
            var resultJumps = SWAHellper.CalculateStopsForDestination("15", "unknown");

            Assert.AreEqual("Can not calculate number of stops!", resultJumps);
        }



        /*************************************/
        /*           CONSOLE INPUT           */
        /*             SHIP MGTL             */
        /*************************************/
        [TestMethod]
        public void String_Is_Positive_Integer()
        {
            var resultIsPositive = SWAHellper.IsStringPositiveInteger("5");

            Assert.AreEqual(true, resultIsPositive);
        }

        [TestMethod]
        public void String_Is_Max_Positive_Integer()
        {
            var resultIsPositive = SWAHellper.IsStringPositiveInteger("2147483647");

            Assert.AreEqual(true, resultIsPositive);
        }

        [TestMethod]
        public void String_Is_Not_Positive_Integer()
        {
            var resultIsPositive = SWAHellper.IsStringPositiveInteger("-5");

            Assert.AreEqual(false, resultIsPositive);
        }

        [TestMethod]
        public void String_Zero_Is_Not_Positive_Integer()
        {
            var resultIsPositive = SWAHellper.IsStringPositiveInteger("0");

            Assert.AreEqual(false, resultIsPositive);
        }

        [TestMethod]
        public void String_Over_Max_Positive_Integer()
        {
            var resultIsPositive = SWAHellper.IsStringPositiveInteger("100000000000000000000000000000000000000000");

            Assert.AreEqual(false, resultIsPositive);
        }

        [TestMethod]
        public void String_Is_Not_Integer()
        {
            var resultIsPositive = SWAHellper.IsStringPositiveInteger("");

            Assert.AreEqual(false, resultIsPositive);
        }
    }
}
