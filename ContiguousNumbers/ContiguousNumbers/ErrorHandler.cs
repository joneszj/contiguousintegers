using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class ErrorHandler : IErrorHandler
    {
        #region members
        private List<string> ErrorMessages;
        #endregion
        
        #region ctor
        public ErrorHandler()
        {
            ErrorMessages = new List<string>();
        }
        #endregion

        public List<string> GetErrorMessages() { return ErrorMessages; }
        public void AddErrorMessage(string Message) { ErrorMessages.Add(Message); }
        public void ClearErrorMessages() { ErrorMessages.Clear(); }
    }
}
