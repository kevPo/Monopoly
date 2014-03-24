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
        
        private IJailRoster jailRoster;

        public TraditionalBoardFactory(IDice dice)
        {
            jailRoster = new JailRoster();
            Board = new GameBoard(dice, jailRoster);
        }

        protected override void CreateCardDraws()
        {
            Board.AddLocation(new CardDraw(2, "Community Chest"));
            Board.AddLocation(new CardDraw(17, "Community Chest"));
            Board.AddLocation(new CardDraw(33, "Community Chest"));
            Board.AddLocation(new CardDraw(7, "Chance"));
            Board.AddLocation(new CardDraw(22, "Chance"));
            Board.AddLocation(new CardDraw(36, "Chance"));
        }

        protected override void CreateTaxables()
        {
            Board.AddLocation(new Taxable(4, "Income Tax", IncomeTaxEquation));
            Board.AddLocation(new Taxable(38, "Luxury Tax", LuxuryTaxEquation));
        }

        private Int32 IncomeTaxEquation(Int32 balance)
        {
            return Math.Min(balance / incomeTaxPercentage, baseIncomeTax);
        }

        private Int32 LuxuryTaxEquation(Int32 balance)
        {
            return luxuryTax;
        }

        protected override void CreateJailRelated()
        {
            var jail = new Jail(10, "Jail/ Just Visiting");
            Board.AddLocation(jail);
            Board.AddLocation(new GoToJail(30, "Go To Jail", 10, jailRoster));
        }

        protected override void CreateGo()
        {
            Board.AddLocation(new Go(0, "Go"));
        }

        protected override void CreateFreeParking()
        {
            Board.AddLocation(new FreeParking(20, "Free Parking"));
        }

        protected override void CreatePropertyGroups()
        {
            BuildRailroads();
            BuildUtilities();
            BuildStreets();
        }

        private void BuildRailroads()
        {
            var railroads = new List<Railroad>();
            var readingRailroad = new Railroad(5, "Reading Railroad", 200, 25, railroads);
            var pennsylvaniaRailroad = new Railroad(15, "Pennsylvania Railroad", 200, 25, railroads);
            var bAndORailroad = new Railroad(25, "B. & O. Railroad", 200, 25, railroads);
            var shortLineRailroad = new Railroad(35, "Short Line Railroad", 200, 25, railroads);

            railroads.AddRange(new Railroad[] { readingRailroad, pennsylvaniaRailroad, bAndORailroad, shortLineRailroad });
            AddLocations(railroads);
        }

        private void BuildUtilities()
        {
            var utilities = new List<Utility>();

            var electric = new Utility(12, "Electric Company", 150, 0, utilities, Board.Dice);
            var waterWorks = new Utility(28, "Water Works", 150, 0, utilities, Board.Dice);

            utilities.AddRange(new Utility[] { electric, waterWorks });
            AddLocations(utilities);
        }

        private void BuildStreets()
        {
            BuildPurpleStreets();
            BuildLightBlueStreets();
            BuildPinkStreets();
            BuildOrangeStreets();
            BuildRedStreets();
            BuildYellowStreets();
            BuildGreenStreets();
            BuildBlueStreets();
        }

        private void BuildPurpleStreets()
        {
            var purpleStreets = new List<Street>();
            var mediterraneanAve = new Street(1, "Mediterranean Avenue", 60, 2, purpleStreets);
            var balticAve = new Street(3, "Baltic Avenue", 60, 4, purpleStreets);

            purpleStreets.AddRange(new Street[] { mediterraneanAve, balticAve });
            AddLocations(purpleStreets);
        }

        private void BuildLightBlueStreets()
        {
            var lightBlueStreets = new List<Street>();
            var orientalAve = new Street(6, "Oriental Avenue", 100, 6, lightBlueStreets);
            var vermontAve = new Street(8, "Vermont Avenue", 100, 6, lightBlueStreets);
            var connecticutAve = new Street(9, "Connecticut Avenue", 120, 8, lightBlueStreets);

            lightBlueStreets.AddRange(new Street[] { orientalAve, vermontAve, connecticutAve });
            AddLocations(lightBlueStreets);
        }

        private void BuildPinkStreets()
        {
            var pinkStreets = new List<Street>();
            var stCharlesPlace = new Street(11, "St. Charles Place", 140, 10, pinkStreets);
            var statesAve = new Street(13, "States Avenue", 140, 10, pinkStreets);
            var virginiaAve = new Street(14, "Virginia Avenue", 160, 12, pinkStreets);

            pinkStreets.AddRange(new Street[] { stCharlesPlace, statesAve, virginiaAve });
            AddLocations(pinkStreets);
        }

        private void BuildOrangeStreets()
        {
            var orangeStreets = new List<Street>();
            var stJamesPlace = new Street(16, "St. James Place", 180, 14, orangeStreets);
            var tennesseeAve = new Street(18, "Tennessee Avenue", 180, 14, orangeStreets);
            var newYorkAve = new Street(19, "New York Avenue", 200, 16, orangeStreets);

            orangeStreets.AddRange(new Street[] { stJamesPlace, tennesseeAve, newYorkAve });
            AddLocations(orangeStreets);
        }

        private void BuildRedStreets()
        {
            var redStreets = new List<Street>();
            var kentuckyAve = new Street(21, "Kentucky Avenue", 220, 18, redStreets);
            var indianaAve = new Street(23, "Indiana Avenue", 220, 18, redStreets);
            var illinoisAve = new Street(24, "Illinois Avenue", 240, 20, redStreets);

            redStreets.AddRange(new Street[] { kentuckyAve, indianaAve, illinoisAve });
            AddLocations(redStreets);
        }

        private void BuildYellowStreets()
        {
            var yellowStreets = new List<Street>();
            var atlanticAve = new Street(26, "Atlantic Avenue", 260, 22, yellowStreets);
            var ventnorAve = new Street(27, "Ventnor Avenue", 260, 22, yellowStreets);
            var marvinGardens = new Street(29, "Marvin Gardens", 280, 24, yellowStreets);

            yellowStreets.AddRange(new Street[] { atlanticAve, ventnorAve, marvinGardens });
            AddLocations(yellowStreets);
        }

        private void BuildGreenStreets()
        {
            var greenStreets = new List<Street>();
            var pacificAve = new Street(31, "Pacific Avenue", 300, 26, greenStreets);
            var northCarolinaAve = new Street(32, "North Carolina Avenue", 300, 26, greenStreets);
            var pennsylvaniaAve = new Street(34, "Pennsylvania Avenue", 320, 28, greenStreets);

            greenStreets.AddRange(new Street[]{ pacificAve, northCarolinaAve, pennsylvaniaAve });
            AddLocations(greenStreets);
        }

        private void BuildBlueStreets()
        {
            var blueStreets = new List<Street>();
            var parkPlace = new Street(37, "Park Place", 350, 35, blueStreets);
            var boardwalk = new Street(39, "Boardwalk", 400, 50, blueStreets);

            blueStreets.AddRange(new Street[] { parkPlace, boardwalk });
            AddLocations(blueStreets);
        }

        private void AddLocations(IEnumerable<Location> locations)
        {
            foreach (var location in locations)
                Board.AddLocation(location);
        }
    }
}
