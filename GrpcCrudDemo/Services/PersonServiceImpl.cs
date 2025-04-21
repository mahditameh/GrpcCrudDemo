
// Ensure the correct namespace is used for the generated gRPC code.  
// The 'protos' namespace is typically defined in the generated files from the .proto definitions.  
// Verify the namespace in the generated files and update the using directive accordingly.  

using Grpc.Core;
using GrpcCrudDemo.Models;
namespace GrpcCrudDemo.Services;

public class PersonServiceImpl : PersonService.PersonServiceBase
{
    private static readonly List<Person> People = new();

    public override Task<PersonResponse> CreatePerson(PersonRequest request, ServerCallContext context)
    {
        if (People.Any(p => p.Id == request.Id))
        {
            return Task.FromResult(new PersonResponse
            {
                Status = "Error",
                Message = "Person with this ID already exists."
            });
        }

        var person = new Person
        {
            Id = string.IsNullOrWhiteSpace(request.Id) ? Guid.NewGuid().ToString() : request.Id,
            FirstName = request.FirstName,
            LastName = request.LastName,
            NationalCode = request.NationalCode,
            BirthDate = request.BirthDate
        };

        People.Add(person);

        return Task.FromResult(new PersonResponse
        {
            Id = person.Id,
            FirstName = person.FirstName,
            LastName = person.LastName,
            NationalCode = person.NationalCode,
            BirthDate = person.BirthDate,
            Status = "Success",
            Message = "Person created successfully."
        });
    }

    public override Task<PersonResponse> GetPerson(PersonIdRequest request, ServerCallContext context)
    {
        var person = People.FirstOrDefault(p => p.Id == request.Id);
        if (person == null)
        {
            return Task.FromResult(new PersonResponse
            {
                Status = "Error",
                Message = "Person not found."
            });
        }

        return Task.FromResult(new PersonResponse
        {
            Id = person.Id,
            FirstName = person.FirstName,
            LastName = person.LastName,
            NationalCode = person.NationalCode,
            BirthDate = person.BirthDate,
            Status = "Success",
            Message = "Person found."
        });
    }

    public override Task<PersonResponse> UpdatePerson(PersonRequest request, ServerCallContext context)
    {
        var person = People.FirstOrDefault(p => p.Id == request.Id);
        if (person == null)
        {
            return Task.FromResult(new PersonResponse
            {
                Status = "Error",
                Message = "Person not found."
            });
        }

        person.FirstName = request.FirstName;
        person.LastName = request.LastName;
        person.NationalCode = request.NationalCode;
        person.BirthDate = request.BirthDate;

        return Task.FromResult(new PersonResponse
        {
            Id = person.Id,
            FirstName = person.FirstName,
            LastName = person.LastName,
            NationalCode = person.NationalCode,
            BirthDate = person.BirthDate,
            Status = "Success",
            Message = "Person updated successfully."
        });
    }

    public override Task<DeleteResponse> DeletePerson(PersonIdRequest request, ServerCallContext context)
    {
        var person = People.FirstOrDefault(p => p.Id == request.Id);
        if (person == null)
        {
            return Task.FromResult(new DeleteResponse
            {
                Status = "Error",
                Message = "Person not found."
            });
        }

        People.Remove(person);

        return Task.FromResult(new DeleteResponse
        {
            Status = "Success",
            Message = "Person deleted successfully."
        });
    }
}
