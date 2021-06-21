using GlobalStrings.Exeptions;

namespace GlobalStrings
{
    public partial class Globalization<TLangCode, KTextCode, GCollectionCode>
    {
        public delegate void LangTextObserverEventHandler(object sender, UpdateModeEventArgs updateModeEventArgs);

        /// <summary>
        /// This event is called every time the language is changed or <c>StartGlobalization</c> is called, updating all strings.
        /// </summary>
        public virtual event LangTextObserverEventHandler LangTextObserver;

        /// <summary>
        /// Groups all strings to respond to language changes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="updateModeEventArgs">Provides properties about language changes at runtime</param>
        private void LangTextObserverCall(object sender, UpdateModeEventArgs updateModeEventArgs)
        {
            if(!hasStarted)
            {
                throw new StopedGlobalizationExeption(ExeptionsMessages.STOPED_GLOBALIZATION_EXEPTION_MESSAGE);
            }
            LangTextObserver?.Invoke(sender, updateModeEventArgs);
        }
    }
}
