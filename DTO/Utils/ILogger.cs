using System;

namespace DTO.Utils
{
    public interface ILogger
    {
        void LogUnexpectedError(Exception exception);
    }
}