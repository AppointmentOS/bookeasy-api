using Bookeasy.Application.Common.Models;
using MediatR;

namespace Bookeasy.Application.Common.Interfaces
{
    public interface IExtendedRequest<T> : MediatR.IRequest<CQRSResult<T>>
    {
        
    }

    public interface IExtendedRequest : IRequest<CQRSResult<Unit>>
    {
        
    }
}