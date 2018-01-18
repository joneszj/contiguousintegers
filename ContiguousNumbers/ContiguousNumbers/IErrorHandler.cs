using System.Collections.Generic;

namespace ConsoleApplication1
{
    public interface IErrorHandler
    {
        void AddErrorMessage(string Message);
        void ClearErrorMessages();
        List<string> GetErrorMessages();
    }
}