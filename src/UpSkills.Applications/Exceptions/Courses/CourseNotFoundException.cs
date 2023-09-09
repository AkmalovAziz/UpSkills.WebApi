namespace UpSkills.Applications.Exceptions.Courses;

public class CourseNotFoundException : NotFoundExcption
{
    public CourseNotFoundException()
    {
        this.TittleMessage = "Course not found !";
    }
}