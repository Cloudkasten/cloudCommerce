//Contributor:  Nicholas Mayne


namespace cloudCommerce.Services.Authentication.External
{
    public partial interface IClaimsTranslator<T>
    {
        UserClaims Translate(T response);
    }
}