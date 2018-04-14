namespace Testdrive.Graph.Models
{
    public interface IEntity<TKey>
    {
        TKey Id { get; set; }
    }
}
