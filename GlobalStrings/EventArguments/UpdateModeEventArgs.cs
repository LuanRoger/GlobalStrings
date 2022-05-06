using System;
using GlobalStrings.Types.Enums;

namespace GlobalStrings.EventArguments
{
    public sealed class UpdateModeEventArgs : EventArgs
    {
        public UpdateMode mode { get; }
        public dynamic lang { get; }

        public UpdateModeEventArgs(UpdateMode mode, dynamic lang)
        {
            this.mode = mode;
            this.lang = lang;
        }
    }
}