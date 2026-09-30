namespace Base
{
    using System;

    public static class LogeventArgsExtension
    {
        public static void Raise(this EventHandler<LogEventArgs> handler, object sender, LogEventArgs args)
        {
            if (handler != null)
            {
                handler(sender, args);
            }
        }
    }
}
