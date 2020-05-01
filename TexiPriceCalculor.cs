using System;
using System.Collections.Generic;

namespace TDDExam
{
    internal class TexiPriceCalculor
    {
        private const int BADIC_MIL = 2;
        private const int LONG_DIS_START = 8;
        private const float PRICE_UNIT_OVER_BASIC_MIL = 0.8f;
        private const float PRICE_UNIT_LONG_DIS = 0.5f;
        private const float PRICE_UNIT_WAITING = 0.25f;
        private const int PRICE_BASIC = 6;
        private const int WAITING_TIME_TO_START_PRICE = 0;
        readonly Func<int, bool> overBasicMil = mil => mil > BADIC_MIL;
        readonly Func<int, bool> isLongDis = mil => mil > LONG_DIS_START;
        readonly Func<int, bool> isWaitingTime = time => time > WAITING_TIME_TO_START_PRICE;

        internal int GetPrice(TexiPriceArgs arg)
        {
            int mil = arg.Mileage;
            int waitTime = arg.Waiting;

            float finalPrice = PRICE_BASIC;
            if (overBasicMil(mil)) finalPrice += (mil - BADIC_MIL) * PRICE_UNIT_OVER_BASIC_MIL;
            if (isLongDis(mil)) finalPrice += (mil - LONG_DIS_START) * PRICE_UNIT_LONG_DIS;
            if (isWaitingTime(waitTime)) finalPrice += waitTime * PRICE_UNIT_WAITING;

            return (int)Math.Round(finalPrice);
        }
    }
}