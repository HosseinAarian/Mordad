using Duende.IdentityServer.Models;

namespace SSOMicroService;

public static class Config
{
	public static IEnumerable<IdentityResource> IdentityResources =>
		new IdentityResource[]
		{
			new IdentityResources.OpenId(),
			new IdentityResources.Profile(),

			new IdentityResource()
			{
				Description = ""
			}
		};

	public static IEnumerable<ApiScope> ApiScopes =>
		new ApiScope[]
			{
				new ApiScope()
				{
					Name = "ApiScope_Name_01",
					DisplayName = "ApiScope_DisplayName_01",
					Description = "ApiScope_Description_01",
					UserClaims = {"Role", "UserUd" },
					Enabled = true,
					ShowInDiscoveryDocument = true //=> show in .welknown
				}
			};

	public static IEnumerable<Client> Clients =>
		new Client[]
			{
				new Client()
				{
					ClientId = "Client_Id_01",
					ClientName = "Client_Name_01",
					Description = "Client_Description_01",
					AllowedGrantTypes = GrantTypes.Code,
					ClientSecrets = [new Duende.IdentityServer.Models.Secret("abc123".Sha256())],
					Enabled = true,
					EnableLocalLogin = true,

					AllowedScopes = ["profile", "openid", "ApiScope_Name_01"]
				}
			};
}
