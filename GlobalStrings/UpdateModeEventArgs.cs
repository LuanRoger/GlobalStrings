using System;

namespace GlobalStrings
{
    public enum UpdateMode {Update, Insert}
    public sealed class UpdateModeEventArgs : EventArgs
    {
        public UpdateMode mode { get; set; }
        public dynamic lang {get; internal set;}
    }
}
