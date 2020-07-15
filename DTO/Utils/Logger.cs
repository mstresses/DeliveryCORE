using log4net;
using System;
using System.Reflection;
using System.Text;

namespace DTO.Utils
{
    public class Logger : ILogger
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public void LogUnexpectedError(Exception exception)
        {
            StringBuilder sb = new StringBuilder();
            log.Error(sb.AppendLine(exception.Message).AppendLine(exception.StackTrace).ToString());
        }
    }
}