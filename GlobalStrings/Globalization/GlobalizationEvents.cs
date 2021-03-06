using GlobalStrings.EventArguments;

namespace GlobalStrings.Globalization
{
    public partial class Globalization<TLangCode, GCollectionCode, KTextCode>
    {
        public delegate void LangTextObserverEventHandler(object sender, UpdateModeEventArgs updateModeEventArgs);

        /// <summary>
        /// This event is executed every time the language is changed,
        /// <c>StartGlobalization</c> or <c>SyncStrings</c> is called, updating all strings.
        /// </summary>
        public event LangTextObserverEventHandler LangTextObserver;

        /// <summary>
        /// Groups all strings to respond to language changes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="updateModeEventArgs">Provides properties about language changes at runtime</param>
        private void LangTextObserverCall(object sender, UpdateModeEventArgs updateModeEventArgs) =>
            LangTextObserver?.Invoke(sender, updateModeEventArgs);
    }
}
