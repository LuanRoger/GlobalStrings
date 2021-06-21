﻿using System;

namespace GlobalStrings
{
    public partial class Globalization<TLangCode, KTextCode, GCollectionCode>
    {
        private static Globalization<TLangCode, KTextCode, GCollectionCode> globalizationInstance {get; set;}

        /// <summary>
        /// Get the global instance of <c>Globalization</c>
        /// </summary>
        /// <returns><c>Globalization</c> instance</returns>
        public static Globalization<TLangCode, KTextCode, GCollectionCode> GetGlobalizaztionInstance() => globalizationInstance;

        /// <summary>
        /// Set the global instance of <c>Globalization</c>
        /// </summary>
        /// <param name="globalization">New value for <c>Globalization</c> global instance</param>
        public static void SetGlobalizationInstance(Globalization<TLangCode, KTextCode, GCollectionCode> globalization) => 
            globalizationInstance = globalization;

        /// <summary>
        /// Creates a shallow copy of the current System.Object.
        /// </summary>
        /// <returns>A shallow copy of the current System.Object.</returns>
        public object Clone() => MemberwiseClone();

        /// <summary>
        /// Return <c>globalizationInstance</c> to its original state, null.
        /// </summary>
        public void Clear() => globalizationInstance = null;
    }
}
