using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem
{
    internal class DelegateAndEventsUtils
    {
        public event Alert processFinished;

        protected virtual void ProcessFinishedHandler(params dynamic[] message)
        {
            processFinished?.Invoke(message);
        }

        public void ShowCompletionMessage(params dynamic[] msg)
        {
            ProcessFinishedHandler(msg);
        }

        public void ShowFailedMessage(params dynamic[] msg)
        {
            ProcessFinishedHandler(msg);
        }
        public void ShowExitMessage(params dynamic[] msg)
        {
            ProcessFinishedHandler(msg);
        }

        //Anonymous method
        Alert printLine = delegate (dynamic[] msg )
        {
            Console.WriteLine();
        };


    }
}
