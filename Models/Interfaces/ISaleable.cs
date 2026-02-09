namespace CoffeeManagementSystem.Models.Interfaces
{
    // Abstraction: Interface
    public interface ISaleable
    {
        int GetID();
        string GetName();
        double GetPrice();
        string GetDetails();
    }
}
