
namespace AkkaNet.Actors
{
    public class Messages
    {
        public struct SystemCommands
        {
            public const string Start = "start";
            public const string Exit = "exit";
        }

        internal struct ValidationMessages
        {
            public const string EmptyInput = "You must send a word";

            public const string ValidInput = "You sent a valid input";
            public const string InvalidInput = "You sent an invalid input";
        }
    }
}
