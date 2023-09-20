namespace UpSkills.Applications.Exceptions.Orders;

public class OrderNotFoundException : NotFoundExcption
{
    public OrderNotFoundException()
    {
        this.TittleMessage = "Order not found";
    }
}