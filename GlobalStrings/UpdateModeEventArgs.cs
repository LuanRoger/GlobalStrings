using System;

namespace GlobalStrings
{
    public enum UpdateMode {Update, Insert, Sync}
    public sealed class UpdateModeEventArgs : EventArgs
    {
        public UpdateMode mode { get; internal init; }
        public dynamic lang {get; internal init;}
    }
}
