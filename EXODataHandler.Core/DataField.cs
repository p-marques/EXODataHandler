namespace EXODataHandler.Core
{
    public struct DataField<T> : IDataField
    {
        public string Id { get; }

        public T Value { get; }

        object IDataField.Data => Value;

        public override string ToString() => Value.ToString();
    }
}
