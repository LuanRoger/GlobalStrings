using System;
using GlobalStrings.Types.Enums;

namespace GlobalStrings.EventArguments
{
    public sealed class UpdateModeEventArgs : EventArgs
    {
        public UpdateMode mode { get; internal init; }
        public dynamic lang {get; internal init;}
    }
}