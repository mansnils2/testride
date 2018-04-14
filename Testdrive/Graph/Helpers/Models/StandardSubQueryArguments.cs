namespace Testdrive.Graph.Helpers.Models
{
    public class StandardSubQueryArguments
    {
        public StandardSubQueryArguments(int? offset, int? take, string where, string order)
        {
            Offset = offset;
            Take = take;
            Where = where;
            Order = order;
        }

        public int? Offset { get; }
        public int? Take { get; }

        public string Where { get; }
        public string Order { get; }
    }
}
