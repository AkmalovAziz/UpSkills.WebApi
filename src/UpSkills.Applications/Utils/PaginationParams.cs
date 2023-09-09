namespace UpSkills.Applications.Utils;

public class PaginationParams
{
    public int PageSize { get; set; }
    public int PageNumber { get; set; }

    public PaginationParams(int pagenumber, int pagesize)
    {
        PageNumber = pagenumber;
        PageSize = pagesize;
    }

    public int SkipCount() => (PageNumber - 1) * PageSize;
}