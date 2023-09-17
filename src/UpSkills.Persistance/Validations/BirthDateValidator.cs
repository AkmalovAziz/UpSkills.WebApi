namespace UpSkills.Persistance.Validations;

public class BirthDateValidator
{
    public static (bool IsValid, string message) IsValidBirthDate(string date)
    {
        if (date.Length != 10) return (IsValid: false, message: "Birthdate can not be less than 9 characters!");
        
        if (date[2] != '/' || date[5] != '/')
            return (IsValid: false, message: "Birthdate should contain at least Symbol /");

        for (int i = 0; i < date.Length; i++)
        {
            if (i == 2 || i == 5)
                continue;

            if (char.IsDigit(date[i])) continue;
            else return (Isvalid: false, message: "Birthdate must be entered in the number");
        }
        return (IsValid:true, message:"");
    }
}