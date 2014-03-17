using System;
using System.Collections.Generic;
using Monopoly.Board;
using Monopoly.Locations;
using Monopoly.PropertyGroups;
using Monopoly.PropertyGroups.RentCalculators;

namespace Monopoly.TraditionalMonopoly
{
    public class TraditionalBoardFactory : BoardFactory
    {
        private const Int32 incomeTaxBalanceSeperator = 2000;
        private const Int32 baseIncomeTax = 200;
        private const Int32 incomeTaxPercentage = 10;
        private const Int32 luxuryTax = 75;
        private IBanker banker;

        public TraditionalBoardFactory(IDice dice)
        {
            banker = new TraditionalBanker();
            Board = new GameBoard(dice);
        }

        protected override void CreateBank()
        {
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
            var railroads = new Property[]
                {
                    new Property(5, "Reading Railroad", 200, 25, banker),
                    new Property(15, "Pennsylvania Railroad", 200, 25, banker),
                    new Property(25, "B. & O. Railroad", 200, 25, banker),
                    new Property(35, "Short Line Railroad", 200, 25, banker)
                };

            AddLocations(railroads);
            Board.AddPropertyGroup(new PropertyGroup("Railroads", railroads, new RailroadRentCalculator()));
        }

        private void BuildUtilities()
        {
            var utilities = new Property[]
                {
                    new Property(12, "Electric Company", 150, 0, banker),
                    new Property(28, "Water Works", 150, 0, banker)
                };

            AddLocations(utilities);
            Board.AddPropertyGroup(new PropertyGroup("Utilities", utilities, new UtilityRentCalculator(Board.Dice)));
        }

        private void BuildStreets()
        {
            var streetRentCalculator = new StreetRentCalculator();
            BuildPurpleStreets(streetRentCalculator);
            BuildLightBlueStreets(streetRentCalculator);
            BuildPinkStreets(streetRentCalculator);
            BuildOrangeStreets(streetRentCalculator);
            BuildRedStreets(streetRentCalculator);
            BuildYellowStreets(streetRentCalculator);
            BuildGreenStreets(streetRentCalculator);
            BuildBlueStreets(streetRentCalculator);
        }

        private void BuildPurpleStreets(StreetRentCalculator rentCalculator)
        {
            var purpleStreets = new Property[]
            {
                new Property(1, "Mediterranean Avenue", 60, 2, banker),
                new Property(3, "Baltic Avenue", 60, 4, banker)
            };

            AddLocations(purpleStreets);
            Board.AddPropertyGroup(new PropertyGroup("Purple Streets", purpleStreets, rentCalculator));
        }

        private void BuildLightBlueStreets(StreetRentCalculator rentCalculator)
        {
            var lightBlueStreets = new Property[]
            {
                new Property(6, "Oriental Avenue", 100, 6, banker),
                new Property(8, "Vermont Avenue", 100, 6, banker),
                new Property(9, "Connecticut Avenue", 120, 8, banker)
            };

            AddLocations(lightBlueStreets);
            Board.AddPropertyGroup(new PropertyGroup("Light Blue Streets", lightBlueStreets, rentCalculator));
        }

        private void BuildPinkStreets(StreetRentCalculator rentCalculator)
        {
            var pinkStreets = new Property[]
            {
                new Property(11, "St. Charles Place", 140, 10, banker),
                new Property(13, "States Avenue", 140, 10, banker),
                new Property(14, "Virginia Avenue", 160, 12, banker)
            };

            AddLocations(pinkStreets);
            Board.AddPropertyGroup(new PropertyGroup("Pink Streets", pinkStreets, rentCalculator));
        }

        private void BuildOrangeStreets(StreetRentCalculator rentCalculator)
        {
            var orangeStreets = new Property[]
            {
                new Property(16, "St. James Place", 180, 14, banker),
                new Property(18, "Tennessee Avenue", 180, 14, banker),
                new Property(19, "New York Avenue", 200, 16, banker)
            };

            AddLocations(orangeStreets);
            Board.AddPropertyGroup(new PropertyGroup("Orange Streets", orangeStreets, rentCalculator));
        }

        private void BuildRedStreets(StreetRentCalculator rentCalculator)
        {
            var redStreets = new Property[]
            {
                new Property(21, "Kentucky Avenue", 220, 18, banker),
                new Property(23, "Indiana Avenue", 220, 18, banker),
                new Property(24, "Illinois Avenue", 240, 20, banker)
            };

            AddLocations(redStreets);
            Board.AddPropertyGroup(new PropertyGroup("Red Streets", redStreets, rentCalculator));
        }

        private void BuildYellowStreets(StreetRentCalculator rentCalculator)
        {
            var yellowStreets = new Property[]
            {
                new Property(26, "Atlantic Avenue", 260, 22, banker),
                new Property(27, "Ventnor Avenue", 260, 22, banker),
                new Property(29, "Marvin Gardens", 280, 24, banker)
            };

            AddLocations(yellowStreets);
            Board.AddPropertyGroup(new PropertyGroup("Yellow Streets", yellowStreets, rentCalculator));
        }

        private void BuildGreenStreets(StreetRentCalculator rentCalculator)
        {
            var greenStreets = new Property[]
            {
                new Property(31, "Pacific Avenue", 300, 26, banker),
                new Property(32, "North Carolina Avenue", 300, 26, banker),
                new Property(34, "Pennsylvania Avenue", 320, 28, banker)
            };

            AddLocations(greenStreets);
            Board.AddPropertyGroup(new PropertyGroup("Green Streets", greenStreets, rentCalculator));
        }

        private void BuildBlueStreets(StreetRentCalculator rentCalculator)
        {
            var blueStreets = new Property[]
            {
                new Property(37, "Park Place", 350, 35, banker),
                new Property(39, "Boardwalk", 400, 50, banker)
            };

            AddLocations(blueStreets);
            Board.AddPropertyGroup(new PropertyGroup("Blue Streets", blueStreets, rentCalculator));
        }

        private void AddLocations(IEnumerable<Location> locations)
        {
            foreach (var location in locations)
                Board.AddLocation(location);
        }

    }
}
