using MediatR;
using System;
using System.Collections.Generic;

namespace Bookeasy.Application.Common.Models
{
    public class CQRSResult<T> : IRequest<Unit>
    {
        public T Payload { get; set; }
        public Exception Error { get; set; }

        public bool Success => Error == null;

        public bool Failed => Error != null;

        private CQRSResult()
        {
        }

        public static CQRSResult<T> CreateSuccessResult(T payload)
        {
            if (payload == null)
                throw new ArgumentNullException(nameof(payload));
            return new CQRSResult<T> { Payload = payload };
        }

        public static CQRSResult<T> CreateFailureResult(Exception exception)
        {
            if (exception == null)
                throw new ArgumentNullException(nameof(exception));

            return new CQRSResult<T> { Error = exception };
        }
    }
}