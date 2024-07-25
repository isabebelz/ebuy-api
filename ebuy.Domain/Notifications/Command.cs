using ValidationResult = FluentValidation.Results.ValidationResult;
using MediatR;

namespace ebuy.Domain.Notifications
{
    public abstract class Command<T> : IRequest<T>
    {
        public DateTime Timestamp { get; private set; }
        public ValidationResult ValidationResult { get; set; }
    
        protected Command()
        {
            ValidationResult = new ValidationResult();
            Timestamp = DateTime.Now;
        }

        public virtual bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}
