using System;
using System.Collections.Generic;
using Monopoly.Board;
using Monopoly.Locations;
using Monopoly.Locations.Propertys;

namespace Monopoly.TraditionalMonopoly
{
    public class TraditionalBoardFactory : BoardFactory
    {
        private const Int32 incomeTaxBalanceSeperator = 2000;
        private const Int32 baseIncomeTax = 200;
        private const Int32 incomeTaxPercentage = 10;
        private const Int32 luxuryTax = 75;

        private List<Location> locations;

        public TraditionalBoardFactory(IDice dice, IEnumerable<IPlayer> players, IJailRoster jailRoster) 
            : base(dice, players, jailRoster)
        {
            locations = new List<Location>();                        
        }

        protected override IEnumerable<Location> GetLocations()
        {
            locations.AddRange(GetCardDraws());
            locations.AddRange(GetTaxables());
            locations.AddRange(GetJailRelated());
            locations.AddRange(GetGo());
            locations.AddRange(GetFreeParking());
            locations.AddRange(GetRailroads());
            locations.AddRange(GetUtilities());
            locations.AddRange(GetStreets());

            return locations;
        }

        private IEnumerable<Location> GetCardDraws()
        {
            return new Location[]
            {
                new CardDraw(2, "Community Chest"),
                new CardDraw(17, "Community Chest"),
                new CardDraw(33, "Community Chest"),
                new CardDraw(7, "Chance"),
                new CardDraw(22, "Chance"),
                new CardDraw(36, "Chance")
            };
        }

        private IEnumerable<Location> GetTaxables()
        {
            return new Location[]
            {
                new Taxable(4, "Income Tax", IncomeTaxEquation),
                new Taxable(38, "Luxury Tax", LuxuryTaxEquation)
            };
        }

        protected override Int32 IncomeTaxEquation(Int32 balance)
        {
            return Math.Min(balance / incomeTaxPercentage, baseIncomeTax);
        }

        protected override Int32 LuxuryTaxEquation(Int32 balance)
        {
            return luxuryTax;
        }

        private IEnumerable<Location> GetJailRelated()
        {
            return new Location[]
            {
                new Jail(10, "Jail/ Just Visiting"),
                new GoToJail(30, "Go To Jail", 10, jailRoster)
            };
        }

        private IEnumerable<Location> GetGo()
        {
            return new Location[] 
            {
                  new Go(0, "Go")
            };
        }

        private IEnumerable<Location> GetFreeParking()
        {
            return new Location[]
            {
                new FreeParking(20, "Free Parking")
            };
        }

        private IEnumerable<Railroad> GetRailroads()
        {
            var railroads = new List<Railroad>();
            var readingRailroad = new Railroad(5, "Reading Railroad", 200, 25, railroads);
            var pennsylvaniaRailroad = new Railroad(15, "Pennsylvania Railroad", 200, 25, railroads);
            var bAndORailroad = new Railroad(25, "B. & O. Railroad", 200, 25, railroads);
            var shortLineRailroad = new Railroad(35, "Short Line Railroad", 200, 25, railroads);

            railroads.AddRange(new Railroad[] 
            { 
                readingRailroad, 
                pennsylvaniaRailroad, 
                bAndORailroad, 
                shortLineRailroad 
            });

            return railroads;
        }

        private IEnumerable<Utility> GetUtilities()
        {
            var utilities = new List<Utility>();
            var electric = new Utility(12, "Electric Company", 150, 0, utilities, dice);
            var waterWorks = new Utility(28, "Water Works", 150, 0, utilities, dice);

            utilities.AddRange(new Utility[] 
            { 
                electric, 
                waterWorks 
            });

            return utilities; 
        }

        private IEnumerable<Street> GetStreets()
        {
            var streets = new List<Street>();
            streets.AddRange(GetPurpleStreets());
            streets.AddRange(GetLightBlueStreets());
            streets.AddRange(GetPinkStreets());
            streets.AddRange(GetOrangeStreets());
            streets.AddRange(GetRedStreets());
            streets.AddRange(GetYellowStreets());
            streets.AddRange(GetGreenStreets());
            streets.AddRange(GetBlueStreets());

            return streets;
        }

        private IEnumerable<Street> GetPurpleStreets()
        {
            var purpleStreets = new List<Street>();
            var mediterraneanAve = new Street(1, "Mediterranean Avenue", 60, 2, purpleStreets);
            var balticAve = new Street(3, "Baltic Avenue", 60, 4, purpleStreets);

            purpleStreets.AddRange(new Street[] { mediterraneanAve, balticAve });

            return purpleStreets;
        }

        private IEnumerable<Street> GetLightBlueStreets()
        {
            var lightBlueStreets = new List<Street>();
            var orientalAve = new Street(6, "Oriental Avenue", 100, 6, lightBlueStreets);
            var vermontAve = new Street(8, "Vermont Avenue", 100, 6, lightBlueStreets);
            var connecticutAve = new Street(9, "Connecticut Avenue", 120, 8, lightBlueStreets);

            lightBlueStreets.AddRange(new Street[] { orientalAve, vermontAve, connecticutAve });

            return lightBlueStreets;
        }

        private IEnumerable<Street> GetPinkStreets()
        {
            var pinkStreets = new List<Street>();
            var stCharlesPlace = new Street(11, "St. Charles Place", 140, 10, pinkStreets);
            var statesAve = new Street(13, "States Avenue", 140, 10, pinkStreets);
            var virginiaAve = new Street(14, "Virginia Avenue", 160, 12, pinkStreets);

            pinkStreets.AddRange(new Street[] { stCharlesPlace, statesAve, virginiaAve });

            return pinkStreets;
        }

        private IEnumerable<Street> GetOrangeStreets()
        {
            var orangeStreets = new List<Street>();
            var stJamesPlace = new Street(16, "St. James Place", 180, 14, orangeStreets);
            var tennesseeAve = new Street(18, "Tennessee Avenue", 180, 14, orangeStreets);
            var newYorkAve = new Street(19, "New York Avenue", 200, 16, orangeStreets);

            orangeStreets.AddRange(new Street[] { stJamesPlace, tennesseeAve, newYorkAve });

            return orangeStreets;
        }

        private IEnumerable<Street> GetRedStreets()
        {
            var redStreets = new List<Street>();
            var kentuckyAve = new Street(21, "Kentucky Avenue", 220, 18, redStreets);
            var indianaAve = new Street(23, "Indiana Avenue", 220, 18, redStreets);
            var illinoisAve = new Street(24, "Illinois Avenue", 240, 20, redStreets);

            redStreets.AddRange(new Street[] { kentuckyAve, indianaAve, illinoisAve });

            return redStreets;
        }

        private IEnumerable<Street> GetYellowStreets()
        {
            var yellowStreets = new List<Street>();
            var atlanticAve = new Street(26, "Atlantic Avenue", 260, 22, yellowStreets);
            var ventnorAve = new Street(27, "Ventnor Avenue", 260, 22, yellowStreets);
            var marvinGardens = new Street(29, "Marvin Gardens", 280, 24, yellowStreets);

            yellowStreets.AddRange(new Street[] { atlanticAve, ventnorAve, marvinGardens });

            return yellowStreets;
        }

        private IEnumerable<Street> GetGreenStreets()
        {
            var greenStreets = new List<Street>();
            var pacificAve = new Street(31, "Pacific Avenue", 300, 26, greenStreets);
            var northCarolinaAve = new Street(32, "North Carolina Avenue", 300, 26, greenStreets);
            var pennsylvaniaAve = new Street(34, "Pennsylvania Avenue", 320, 28, greenStreets);

            greenStreets.AddRange(new Street[]{ pacificAve, northCarolinaAve, pennsylvaniaAve });

            return greenStreets;
        }

        private IEnumerable<Street> GetBlueStreets()
        {
            var blueStreets = new List<Street>();
            var parkPlace = new Street(37, "Park Place", 350, 35, blueStreets);
            var boardwalk = new Street(39, "Boardwalk", 400, 50, blueStreets);

            blueStreets.AddRange(new Street[] { parkPlace, boardwalk });

            return blueStreets;
        }
    }
}
