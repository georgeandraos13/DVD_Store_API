using DVD_Store_API.Data;
using DVD_Store_API.Exceptions;
using DVD_Store_API.Interfaces;
using DVD_Store_API.Models;

namespace DVD_Store_API.Repositories
{
    public class ActorActressRepository : IActorActressRepository
    {
        private readonly DataContext dataContext;

        public ActorActressRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public bool Exists(int id)
        {
            return dataContext.ActorsActresses.Any(a => a.Id == id);
        }
        public bool Exists(string name)
        {
            return dataContext.ActorsActresses.Any(p => p.Name == name);
        }
        public int GetActorActressId(string name)
        {
            if (!Exists(name))
                throw new ObjectNotFoundException();
            else
            {
                ActorActress? a = dataContext.ActorsActresses.Where(p => p.Name == name).FirstOrDefault();
                if (a == null)
                    throw new ObjectNotFoundException();
                else
                    return a.Id;
            }
        }
        public ICollection<ActorActress> GetActorsActresses()
        {
            ICollection<ActorActress> result = dataContext.ActorsActresses.OrderBy(p => p.Name).ToList();
            if (result.Count <= 0)
                throw new ObjectNotFoundException();
            else
                return result;
        }
        public ActorActress GetActorActress(int id)
        {
            if (!Exists(id))
                throw new ObjectNotFoundException();
            else
            {
                ActorActress? a = dataContext.ActorsActresses.Where(p => p.Id == id).FirstOrDefault();
                if (a == null)
                    throw new ObjectNotFoundException();
                else
                    return a;
            }
        }
        public void AddActorActress(ActorActress actorActress)
        {
            if (actorActress.Name != null)
            {
                if (Exists(actorActress.Name))
                    throw new ObjectAlreadyExistsException();
                else
                {
                    dataContext.ActorsActresses.Add(actorActress);
                    dataContext.SaveChanges();
                }
            }
        }
        public void DeleteActorActress(ActorActress actorActress)
        {
            if (!Exists(actorActress.Id))
                throw new ObjectNotFoundException();
            else
            {
                ICollection<MovieActorActress> moviesactorsactresses = dataContext.MoviesActorsActresses.Where(p => p.ActorActressId == actorActress.Id).ToList();
                for (int i = 0; i < moviesactorsactresses.Count; i++)
                    dataContext.MoviesActorsActresses.Remove(moviesactorsactresses.ElementAt(i));
                dataContext.Remove(actorActress);
                dataContext.SaveChanges();
            }
        }
        public void UpdateActorActress(int id, ActorActress newActorActress)
        {
            if (!Exists(id))
                throw new ObjectNotFoundException();
            else
            {
                ActorActress? a = dataContext.ActorsActresses.Where(p => p.Id == id).FirstOrDefault();
                if (a == null)
                    throw new ObjectNotFoundException();
                else
                {
                    a.Name = newActorActress.Name;
                    dataContext.SaveChanges();
                }
            }
        }
    }
}
