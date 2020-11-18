using Microsoft.AspNetCore.Mvc;
using System;

namespace Bookeasy.Api
{
    public interface IProblemDetailsFactory
    {
        ProblemDetails CreateProblemDetails(Exception exception);
    }
}