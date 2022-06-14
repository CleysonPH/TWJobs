namespace TWJobs.Core.Repositories;

public interface IRepository<Model, Id>
{
    bool ExistsById(Id id);
}