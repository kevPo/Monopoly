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
        
        private IBanker banker;
        private IPropertyManager propertyManager;
        private List<TitleDeed> titleDeeds;

        public TraditionalBoardFactory(IDice dice)
        {
            titleDeeds = new List<TitleDeed>();
            propertyManager = new PropertyManager();
            Board = new GameBoard(dice);
        }

        protected override void CreateBank()
        {
            banker = new TraditionalBanker(titleDeeds, propertyManager);
            Board.InitializeBanker(banker);
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
            return balance > incomeTaxBalanceSeperator ? baseIncomeTax : Convert.ToInt32(balance / incomeTaxPercentage);
        }

        private Int32 LuxuryTaxEquation(Int32 balance)
        {
            return luxuryTax;
        }

        protected override void CreateJailRelated()
        {
            var jail = new Jail(10, "Jail/ Just Visiting");
            Board.AddLocation(jail);
            Board.AddLocation(new GoToJail(30, "Go To Jail", jail));
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

            var readingRailroad = new Railroad(5, "Reading Railroad", banker, propertyManager);
            var pennsylvaniaRailroad = new Railroad(15, "Pennsylvania Railroad", banker, propertyManager);
            var bAndORailroad = new Railroad(25, "B. & O. Railroad", banker, propertyManager);
            var shortLineRailroad = new Railroad(35, "Short Line Railroad", banker, propertyManager);

            titleDeeds.Add(new TitleDeed(readingRailroad, 200, 25, PropertyGroup.Railroad));
            titleDeeds.Add(new TitleDeed(pennsylvaniaRailroad, 200, 25, PropertyGroup.Railroad));
            titleDeeds.Add(new TitleDeed(bAndORailroad, 200, 25, PropertyGroup.Railroad));
            titleDeeds.Add(new TitleDeed(shortLineRailroad, 200, 25, PropertyGroup.Railroad));

            var railroads = new Property[]
                {
                   readingRailroad, pennsylvaniaRailroad, bAndORailroad, shortLineRailroad
                };

            AddLocations(railroads);
        }

        private void BuildUtilities()
        {
            var electric = new Utility(12, "Electric Company", banker, propertyManager, Board.Dice);
            var waterWorks = new Utility(28, "Water Works", banker, propertyManager, Board.Dice);

            titleDeeds.Add(new TitleDeed(electric, 150, 0, PropertyGroup.Utility));
            titleDeeds.Add(new TitleDeed(waterWorks, 150, 0, PropertyGroup.Utility));

            var utilities = new Property[]
                {
                    electric, waterWorks
                };

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
            var mediterraneanAve = new Street(1, "Mediterranean Avenue", banker, propertyManager);
            var balticAve = new Street(3, "Baltic Avenue", banker, propertyManager);

            titleDeeds.Add(new TitleDeed(mediterraneanAve, 60, 2, PropertyGroup.Purple));
            titleDeeds.Add(new TitleDeed(balticAve, 60, 4, PropertyGroup.Purple));

            var purpleStreets = new Property[]
            {
                mediterraneanAve, balticAve
            };

            AddLocations(purpleStreets);
        }

        private void BuildLightBlueStreets()
        {
            var orientalAve = new Street(6, "Oriental Avenue", banker, propertyManager);
            var vermontAve = new Street(8, "Vermont Avenue", banker, propertyManager);
            var connecticutAve = new Street(9, "Connecticut Avenue", banker, propertyManager);

            titleDeeds.Add(new TitleDeed(orientalAve, 100, 6, PropertyGroup.LightBlue));
            titleDeeds.Add(new TitleDeed(vermontAve, 100, 6, PropertyGroup.LightBlue));
            titleDeeds.Add(new TitleDeed(connecticutAve, 120, 8, PropertyGroup.LightBlue));

            var lightBlueStreets = new Property[]
            {
                orientalAve, vermontAve, connecticutAve
            };

            AddLocations(lightBlueStreets);
        }

        private void BuildPinkStreets()
        {
            var stCharlesPlace = new Street(11, "St. Charles Place", banker, propertyManager);
            var statesAve = new Street(13, "States Avenue", banker, propertyManager);
            var virginiaAve = new Street(14, "Virginia Avenue", banker, propertyManager);

            titleDeeds.Add(new TitleDeed(stCharlesPlace, 140, 10, PropertyGroup.Pink));
            titleDeeds.Add(new TitleDeed(statesAve, 140, 10, PropertyGroup.Pink));
            titleDeeds.Add(new TitleDeed(virginiaAve, 160, 12, PropertyGroup.Pink));

            var pinkStreets = new Property[]
            {
                stCharlesPlace, statesAve, virginiaAve
            };

            AddLocations(pinkStreets);
        }

        private void BuildOrangeStreets()
        {
            var stJamesPlace = new Street(16, "St. James Place", banker, propertyManager);
            var tennesseeAve = new Street(18, "Tennessee Avenue", banker, propertyManager);
            var newYorkAve = new Street(19, "New York Avenue", banker, propertyManager);

            titleDeeds.Add(new TitleDeed(stJamesPlace, 180, 14, PropertyGroup.Orange));
            titleDeeds.Add(new TitleDeed(tennesseeAve, 180, 14, PropertyGroup.Orange));
            titleDeeds.Add(new TitleDeed(newYorkAve, 200, 16, PropertyGroup.Orange));

            var orangeStreets = new Property[]
            {
                stJamesPlace, tennesseeAve, newYorkAve
            };

            AddLocations(orangeStreets);
        }

        private void BuildRedStreets()
        {
            var kentuckyAve = new Street(21, "Kentucky Avenue", banker, propertyManager);
            var indianaAve = new Street(23, "Indiana Avenue", banker, propertyManager);
            var illinoisAve = new Street(24, "Illinois Avenue", banker, propertyManager);

            titleDeeds.Add(new TitleDeed(kentuckyAve, 220, 18, PropertyGroup.Red));
            titleDeeds.Add(new TitleDeed(indianaAve, 220, 18, PropertyGroup.Red));
            titleDeeds.Add(new TitleDeed(illinoisAve, 240, 20, PropertyGroup.Red));

            var redStreets = new Property[]
            {
                kentuckyAve, indianaAve, illinoisAve
            };

            AddLocations(redStreets);
        }

        private void BuildYellowStreets()
        {
            var atlanticAve = new Street(26, "Atlantic Avenue", banker, propertyManager);
            var ventnorAve = new Street(27, "Ventnor Avenue", banker, propertyManager);
            var marvinGardens = new Street(29, "Marvin Gardens", banker, propertyManager);

            titleDeeds.Add(new TitleDeed(atlanticAve, 260, 22, PropertyGroup.Yellow));
            titleDeeds.Add(new TitleDeed(ventnorAve, 260, 22, PropertyGroup.Yellow));
            titleDeeds.Add(new TitleDeed(marvinGardens, 280, 24, PropertyGroup.Yellow));

            var yellowStreets = new Property[]
            {
                atlanticAve, ventnorAve, marvinGardens
            };

            AddLocations(yellowStreets);
        }

        private void BuildGreenStreets()
        {
            var pacificAve = new Street(31, "Pacific Avenue", banker, propertyManager);
            var northCarolinaAve = new Street(32, "North Carolina Avenue", banker, propertyManager);
            var pennsylvaniaAve = new Street(34, "Pennsylvania Avenue", banker, propertyManager);

            titleDeeds.Add(new TitleDeed(pacificAve, 300, 26, PropertyGroup.Green));
            titleDeeds.Add(new TitleDeed(northCarolinaAve, 300, 26, PropertyGroup.Green));
            titleDeeds.Add(new TitleDeed(pennsylvaniaAve, 320, 28, PropertyGroup.Green));

            var greenStreets = new Property[]
            {
                pacificAve, northCarolinaAve, pennsylvaniaAve
            };

            AddLocations(greenStreets);
        }

        private void BuildBlueStreets()
        {
            var parkPlace = new Street(37, "Park Place", banker, propertyManager);
            var boardwalk = new Street(39, "Boardwalk", banker, propertyManager);

            titleDeeds.Add(new TitleDeed(parkPlace, 350, 35, PropertyGroup.Blue));
            titleDeeds.Add(new TitleDeed(boardwalk, 400, 50, PropertyGroup.Blue));

            var blueStreets = new Property[]
            {
                parkPlace, boardwalk   
            };

            AddLocations(blueStreets);
        }

        private void AddLocations(IEnumerable<Location> locations)
        {
            foreach (var location in locations)
                Board.AddLocation(location);
        }
    }
}
