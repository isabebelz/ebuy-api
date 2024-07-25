namespace ebuy.Application.Common.Interfaces.Services.ValidationsService
{
    public interface IValidationService
    {
        bool ValidarFormatoEmail(string email);
        bool ValidarFormatoSenha(string senha);
    }
}
