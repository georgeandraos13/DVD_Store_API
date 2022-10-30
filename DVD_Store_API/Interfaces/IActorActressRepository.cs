using DVD_Store_API.Models;

namespace DVD_Store_API.Interfaces
{
    public interface IActorActressRepository
    {
        public ICollection<ActorActress> GetActorsActreeses();
        public int GetActorId(string Name);
        public ActorActress GetActorActress(int Id);
        public bool Exists(int Id);
        public bool Exists(string Name);
        public void AddActorActress(string Name);
        public void DeleteActorActress(int id);
        public void UpdateActorActress(int id, string NewName);
    }
}
