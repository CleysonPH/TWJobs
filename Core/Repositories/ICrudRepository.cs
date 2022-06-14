namespace TWJobs.Core.Repositories;

public interface ICrudRepository<Model, Id> : IRepository<Model, Id>
{
    ICollection<Model> FindAll();
    Model Create(Model model);
    Model? FindById(Id id);
    Model UpdateById(Id id, Model model);
    void DeleteById(Id id);
}