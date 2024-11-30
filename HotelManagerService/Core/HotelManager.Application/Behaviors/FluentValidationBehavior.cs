using FluentValidation;
using MediatR;
using SendGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.Application.Behaviors
{
    public class FluentValidationBehavior<TRequest, TRespoonse> : IPipelineBehavior<TRequest, TRespoonse>
        where TRequest : IRequest<TRespoonse>
    {
        private readonly IEnumerable<IValidator<TRequest>> validator;
        public FluentValidationBehavior(IEnumerable<IValidator<TRequest>> validator)
        {
            this.validator = validator;
        }
        public Task<TRespoonse> Handle(TRequest request, RequestHandlerDelegate<TRespoonse> next, CancellationToken cancellationToken)
        {
            var context = new ValidationContext<TRequest>(request);
            var failtures = validator.Select(v => v.Validate(context))
                                     .SelectMany(result => result.Errors)
                                     .GroupBy(x => x.ErrorMessage)
                                     .Select(x => x.First())
                                     .Where(f => f != null)
                                     .ToList();

            if (failtures.Any())
            {
                throw new ValidationException(failtures);
            }

            return next();
        }
    }
}
