using API.Models;
using API.Services.Interfaces;

namespace API.Services.Implementation;

public class UserService : IUserService
{
	static List<User> users = [
		new User(){
			Id = 1,
			FirstName = "A",
			LastName = "AA",
			Mobile = "0"
		},
		new User(){
			Id = 2,
			FirstName = "B",
			LastName = "BB",
			Mobile = "00"
		},
		new User(){
			Id = 3,
			FirstName = "C",
			LastName = "CC",
			Mobile = "000"
		}
		];
	public List<User> GetUsers()
		=> users;
	
}
