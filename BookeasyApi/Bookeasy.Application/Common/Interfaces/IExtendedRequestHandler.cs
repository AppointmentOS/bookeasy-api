using Bookeasy.Application.Common.Models;
using MediatR;

namespace Bookeasy.Application.Common.Interfaces
{
    public interface IExtendedRequestHandler<TRequest, TResponse> : MediatR.IRequestHandler<TRequest, CQRSResult<TResponse>>
        where TRequest : MediatR.IRequest<CQRSResult<TResponse>>
    {
    }

    public interface IExtendedRequestHandler<TRequest> : IRequestHandler<TRequest, CQRSResult<Unit>>
        where TRequest : IRequest<CQRSResult<Unit>>
    {
        
    }
}