namespace UpSkills.Persistance.Validations;

public class PriceValidator
{
    public static bool IsValid(float price)
    {
        if (price <= 0) return false;

        return true;
    }
}