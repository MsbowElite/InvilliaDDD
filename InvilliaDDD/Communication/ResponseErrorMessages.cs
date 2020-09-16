using System.Collections.Generic;

namespace InvilliaDDD.Core.Communication
{
    public class ResponseErrorMessages
    {
        public ResponseErrorMessages()
        {
            Messages = new List<string>();
        }

        public List<string> Messages { get; set; }
    }
}
