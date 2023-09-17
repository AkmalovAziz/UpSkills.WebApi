using UpSkills.Applications.Utils;

namespace UpSkills.Service.Interfaces.Commons;

public interface IPaginator
{
    public void Paginate(long itemsCount, PaginationParams @params);
}