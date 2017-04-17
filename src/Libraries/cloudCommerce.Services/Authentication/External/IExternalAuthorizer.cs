//Contributor:  Nicholas Mayne


namespace cloudCommerce.Services.Authentication.External
{
    public partial interface IExternalAuthorizer
    {
        AuthorizationResult Authorize(OpenAuthenticationParameters parameters);
    }
}