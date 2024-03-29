﻿using System;
using System.Linq;

namespace _5._Date_Modifier

{
    public class DateModifier
    {
        public int DateModifierMethod(string date1, string date2)
        {


            var date1Arr = date1.Split()
                .Select(int.Parse)
                .ToArray();

            DateTime dateTime1 = new DateTime(date1Arr[0], date1Arr[1], date1Arr[2]);

            var date2Arr = date2.Split()
                .Select(int.Parse)
                .ToArray();

            DateTime dateTime2 = new DateTime(date2Arr[0], date2Arr[1], date2Arr[2]);





            return Math.Abs((dateTime1 - dateTime2).Days);
        }
    }
}
