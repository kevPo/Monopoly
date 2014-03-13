namespace Monopoly.Board
{
    public abstract class BoardBuilder
    {
        public GameBoard Board { get; protected set; }

        public void Build()
        {
            BuildBank();
            BuildPropertyGroups();
            BuildCardDraws();
            BuildTaxables();
            BuildJailRelated();
            BuildGo();
            BuildFreeParking();  
        }

        public abstract void BuildBank();
        public abstract void BuildPropertyGroups();
        public abstract void BuildCardDraws();
        public abstract void BuildTaxables();
        public abstract void BuildJailRelated();
        public abstract void BuildGo();
        public abstract void BuildFreeParking();
    }
}
