# DVD_Store_API
Basckend API system for a DVD store.
DB manages movies, customers, and actors/actresses.
Data Context class inherits from DB Data Context, to create the DB from the Models
Rent table is between movie and customer tables (many to manay).
MovieActorActress is betwee movie and Actor/Actress table (many to many).
Repository interfaces are what repository classes inherit from.
Controllers manage basic CRUD operations with some advanced search features.
