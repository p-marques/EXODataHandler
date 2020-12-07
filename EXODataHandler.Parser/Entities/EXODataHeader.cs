namespace EXODataHandler.Parser.Entities
{
    public struct EXODataHeader
    {
        public string Id { get; }
        public short PositionIndex { get; }

        public EXODataHeader(string id, short positionIndex)
        {
            Id = id;
            PositionIndex = positionIndex;
        }
    }
}
