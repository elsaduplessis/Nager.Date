﻿using Nager.Date.Contract;
using Nager.Date.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    /// <summary>
    /// Ireland
    /// https://en.wikipedia.org/wiki/Public_holidays_in_the_Republic_of_Ireland
    /// </summary>
    public class IrelandProvider : IPublicHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// IrelandProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public IrelandProvider(ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="year">The year</param>
        /// <returns></returns>
        public IEnumerable<PublicHoliday> Get(int year)
        {
            var countryCode = CountryCode.IE;
            var easterSunday = this._catholicProvider.EasterSunday(year);

            var firstMondayInMay = DateSystem.FindDay(year, 5, DayOfWeek.Monday, 1);
            var firstMondayInJune = DateSystem.FindDay(year, 6, DayOfWeek.Monday, 1);
            var firstMondayInAugust = DateSystem.FindDay(year, 8, DayOfWeek.Monday, 1);
            var lastMondayInOctober = DateSystem.FindLastDay(year, 10, DayOfWeek.Monday);

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "Lá Caille", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(year, 3, 17, "Lá Fhéile Pádraig", "Saint Patrick's Day", countryCode, 1903));
            items.Add(new PublicHoliday(easterSunday.AddDays(1), "Luan Cásca", "Easter Monday", countryCode));
            items.Add(new PublicHoliday(firstMondayInMay, "Lá Bealtaine", "May Day", countryCode, 1994));
            items.Add(new PublicHoliday(firstMondayInJune, "Lá Saoire i mí an Mheithimh", "June Holiday", countryCode, 1973));
            items.Add(new PublicHoliday(firstMondayInAugust, "Lá Saoire i mí Lúnasa", "August Holiday", countryCode));
            items.Add(new PublicHoliday(lastMondayInOctober, "Lá Saoire i mí Dheireadh Fómhair", "October Holiday", countryCode, 1977));
            items.Add(new PublicHoliday(year, 12, 25, "Lá Nollag", "Christmas Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 26, "Lá Fhéile Stiofáin", "St. Stephen's Day", countryCode));

            return items.OrderBy(o => o.Date);
        }
    }
}
