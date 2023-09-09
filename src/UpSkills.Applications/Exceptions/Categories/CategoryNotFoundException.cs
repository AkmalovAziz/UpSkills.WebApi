namespace UpSkills.Applications.Exceptions.Categories;

public class CategoryNotFoundException : NotFoundExcption
{
    public CategoryNotFoundException()
    {
        this.TittleMessage = "Category not found !";
    }
}