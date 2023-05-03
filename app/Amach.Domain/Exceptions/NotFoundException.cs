using System;

namespace Amach.Domain.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException() : base("SSN Not Found Exception")
    {
    }
}