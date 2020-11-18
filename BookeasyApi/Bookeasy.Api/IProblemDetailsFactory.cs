using System;
using Microsoft.AspNetCore.Mvc;

namespace Bookeasy.Api
{
    public interface IProblemDetailsFactory
    {
        ProblemDetails CreateProblemDetails(Exception exception);
    }
}