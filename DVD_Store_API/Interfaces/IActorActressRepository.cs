using DVD_Store_API.Models;

namespace DVD_Store_API.Interfaces
{
    public interface IActorActressRepository
    {
        public ICollection<ActorActress> GetActorsActresses();
        public int GetActorActressId(string Name);
        public ActorActress GetActorActress(int Id);
        public bool Exists(int Id);
        public bool Exists(string Name);
        public void AddActorActress(ActorActress actorActress);
        public void DeleteActorActress(ActorActress actorActress);
        public void UpdateActorActress(int id, ActorActress newActorActress);
    }
}
