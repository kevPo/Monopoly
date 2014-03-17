namespace Monopoly.Board
{
    public abstract class BoardFactory
    {
        public GameBoard Board { get; protected set; }

        public void Create()
        {
            CreateBank();
            CreatePropertyGroups();
            CreateCardDraws();
            CreateTaxables();
            CreateJailRelated();
            CreateGo();
            CreateFreeParking();  
        }

        protected abstract void CreateBank();
        protected abstract void CreatePropertyGroups();
        protected abstract void CreateCardDraws();
        protected abstract void CreateTaxables();
        protected abstract void CreateJailRelated();
        protected abstract void CreateGo();
        protected abstract void CreateFreeParking();
    }
}
