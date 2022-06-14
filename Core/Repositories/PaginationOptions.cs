namespace TWJobs.Core.Repositories;

public class PaginationOptions
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }

    public PaginationOptions()
    {
        PageNumber = 1;
        PageSize = 10;
    }

    public PaginationOptions(int pageNumber = 1, int pageSize = 10)
    {
        PageNumber = pageNumber < 1 ? 1 : pageNumber;
        PageSize = pageSize < 1 ? 10 : pageSize;
    }
}