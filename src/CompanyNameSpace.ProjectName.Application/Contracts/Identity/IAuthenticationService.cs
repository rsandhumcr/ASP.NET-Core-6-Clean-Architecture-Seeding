using CompanyNameSpace.ProjectName.Application.Models.Authentication;

namespace CompanyNameSpace.ProjectName.Application.Contracts.Identity;

public interface IAuthenticationService
{
    Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request);
    Task<RegistrationResponse> RegisterAsync(RegistrationRequest request);
}