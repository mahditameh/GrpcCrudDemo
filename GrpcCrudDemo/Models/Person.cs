
namespace GrpcCrudDemo.Models;

public class Person
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public string NationalCode { get; set; } = "";
    public string BirthDate { get; set; } = "";
}
