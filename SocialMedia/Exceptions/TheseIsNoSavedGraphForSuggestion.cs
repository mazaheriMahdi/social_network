using System.Runtime.Serialization;

namespace SocialMedia.Exceptions
{
    [Serializable]
    internal class TheseIsNoSavedGraphForSuggestion : Exception
    {

        public TheseIsNoSavedGraphForSuggestion() : base("There is no connection Graph for analyse please go back and create a graph for your user lists")
        {
        }
        public TheseIsNoSavedGraphForSuggestion(string? message) : base(message)
        {
        }
        public TheseIsNoSavedGraphForSuggestion(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected TheseIsNoSavedGraphForSuggestion(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}