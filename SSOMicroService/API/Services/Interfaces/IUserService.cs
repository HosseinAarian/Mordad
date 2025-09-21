using API.Models;

namespace API.Services.Interfaces;

public interface IUserService
{
	List<User> GetUsers();
}
