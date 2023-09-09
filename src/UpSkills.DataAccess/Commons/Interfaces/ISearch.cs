using UpSkills.Applications.Utils;

namespace UpSkills.DataAccess.Commons.Interfaces;

public interface ISearch<TViewModel>
{
    public Task<IList<TViewModel>> SearchAsync(string search, PaginationParams @params);
}