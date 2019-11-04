using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
namespace FxStore.AuthServer.Seeds
{
    public class TestSeed
    {
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("FxStore.ProductAPI.Resource","Product API Resource")
                {
                    UserClaims =
                    {
                        "name"
                    }
                },
                new ApiResource("FxStore.OrderAPI.Resource","Order API Resource")
                {
                    UserClaims =
                    {
                        "name"
                    }
                },
                new ApiResource("FxStore.OrderHistoryAPI.Resource","Order History API Resource")
                {
                    UserClaims =
                    {
                        "name"
                    }
                }
            };
        }

       
        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>()
            {
                new Client
                {
                    AllowOfflineAccess = true,
                    AccessTokenType = AccessTokenType.Jwt,
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    AllowedScopes =
                    {
                        "FxStore.ProductAPI.Resource",
                        IdentityModel.OidcConstants.StandardScopes.OfflineAccess
                    },
                    ClientName = "FxStore.ProductAPI",
                    ClientId = "FxStore.ProductAPI",
                    ClientSecrets =
                    {
                        new Secret("361e41a3dcd6458da1473911b6d1c1f4".Sha256())
                    }
                },
                new Client
                {
                     AllowOfflineAccess = true,
                    AccessTokenType = AccessTokenType.Jwt,
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
                    AllowedScopes =
                    {
                        "FxStore.OrderAPI.Resource",
                        IdentityModel.OidcConstants.StandardScopes.OfflineAccess
                    },
                    ClientName = "FxStore.OrderAPI",
                    ClientId = "FxStore.OrderAPI",
                    ClientSecrets =
                    {
                        new Secret("68aa0f3836c14afa9aef0c4dcdd0aee7".Sha256())
                    }
                },
                new Client
                {
                     AllowOfflineAccess = true,
                    AccessTokenType = AccessTokenType.Jwt,
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
                    AllowedScopes =
                    {
                        "FxStore.OrderHistoryAPI.Resource",
                        IdentityModel.OidcConstants.StandardScopes.OfflineAccess
                    },
                    ClientName = "FxStore.OrderHistoryAPI",
                    ClientId = "FxStore.OrderHistoryAPI",
                    ClientSecrets =
                    {
                        new Secret("0caa54bd1d0f4f6c81a7cbe556ebcae9".Sha256())
                    }
                }
            };
        }
        public static IEnumerable<TestUser> GetTestUsers() => new List<TestUser>
        {
            new TestUser
            {
                SubjectId = "6004a235-c4e0-48fe-b65d-c8a3bb900b1b",
                Username = "mirzaevolution",
                Password = "future",
                Claims =
                {
                    new Claim("name","Mirza Ghulam Rasyid"),
                    new Claim("email","ghulamcyber@hotmail.com")
                }
            },
            new TestUser
            {
                SubjectId = "7d012c07-1777-4cf7-aad0-efd48256cd05",
                Username = "nighthawk",
                Password = "future",
                Claims =
                {
                    new Claim("name","Night Hawk"),
                    new Claim("email","nighthawk@cia.com")
                }
            }
        };
    }
}
