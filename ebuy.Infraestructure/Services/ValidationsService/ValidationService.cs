using ebuy.Application.Common.Interfaces.Services.ValidationsService;
using System.Text.RegularExpressions;

namespace ebuy.Infraestructure.Services.ValidationsService
{
    public class ValidationService : IValidationService
    {
        public bool ValidarFormatoEmail(string email)
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}(?:\.[a-zA-Z]+)?$";

            return Regex.IsMatch(email, pattern);
        }

        public bool ValidarFormatoSenha(string senha)
        {
            string pattern = @"^(?=.*\d)(?=.*[A-Z])(?=.*[a-z])(?=.*[^a-zA-Z0-9]).{8,}$";

            Regex regex = new(pattern);

            return regex.IsMatch(senha);
        }
    }
}
