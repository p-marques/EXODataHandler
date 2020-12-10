namespace EXODataHandler.Parser.Entities
{
    /// <summary>
    /// Struct used to save the basic informartion of a Header
    /// </summary>
    public struct EXODataHeader
    {
        /// <summary>
        /// Property used to get header's ID
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// Property used to get header's Position
        /// </summary>
        public short PositionIndex { get; }

        /// <summary>
        /// Constructor for EXODataHeader
        /// </summary>
        /// <param name="id">Header's ID</param>
        /// <param name="positionIndex">Header's Position</param>
        public EXODataHeader(string id, short positionIndex)
        {
            Id = id;
            PositionIndex = positionIndex;
        }
    }
}
