using System;
using GlobalStrings.Util.Types;

namespace GlobalStrings.EventArguments
{
    public sealed class UpdateModeEventArgs : EventArgs
    {
        public UpdateMode mode { get; internal init; }
        public dynamic lang {get; internal init;}
    }
}