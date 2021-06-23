using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace GlobalStrings
{
    /// <summary>
    /// Contains language information.
    /// </summary>
    /// <typeparam name="TLangCode">Defines the type used to identify <c>LanguageInfo<TLangCode, KTextCode></c>.</typeparam>
    /// <typeparam name="KTextCode">Defines the type used to identify the strings in <c>LanguageInfo<...>.textBook</c>.</typeparam>
    /// <typeparamref name="GCollectionCode"/>Defines the type used to identify <c>TextBookCollection</c> collections.</typeparam>
    public sealed class LanguageInfo<TLangCode, KTextCode, GCollectionCode>
    {
        /// <summary>
        /// Identifies the language by a unique code for each one.
        /// </summary>
        public TLangCode langCode { get; private set; }

        [AllowNull]
        [Obsolete("It is recommended to use TextBookCollection instead of this.")]
        public Dictionary<KTextCode, string> textLangBook { get; set; }
        /// <summary>
        /// Contains and manages language string collections.
        /// </summary>
        public TextBookCollection<TLangCode, KTextCode, GCollectionCode> textBookCollection { get; set; }

        /// <summary>
        /// Instantiate a new LanguageInfo.
        /// </summary>
        /// <param name="langCode">It is mandatory at first, define the code that will identify the language.</param>
        /// <param name="textBookCollection">Defines all collections used in the language.</param>
        /// <param name="textLangBook">Obsolete</param>
        public LanguageInfo(TLangCode langCode, TextBookCollection<TLangCode, KTextCode, GCollectionCode> textBookCollection = null,
            Dictionary<KTextCode, string> textLangBook = null)
        {
            this.langCode = langCode;
            this.textLangBook = textLangBook;
            this.textBookCollection = textBookCollection;
        }
    }
    public sealed class TextBookCollection<TLangCode, KTextCode, GCollectionCode> : IDictionary<GCollectionCode, Dictionary<KTextCode, string>>, IEnumerable
    {
        private Dictionary<GCollectionCode, Dictionary<KTextCode, string>> collection;
        public Dictionary<KTextCode, string> this[GCollectionCode key] { get => collection[key]; set => collection[key] = value; }
        public ICollection<GCollectionCode> Keys => collection.Keys;
        public ICollection<Dictionary<KTextCode, string>> Values => collection.Values;
        public int Count => collection.Count;
        public bool IsReadOnly => false;

        public TextBookCollection() => collection = new();

        public void Add(GCollectionCode key, Dictionary<KTextCode, string> value) =>
            collection.Add(key, value);

        public void Add(KeyValuePair<GCollectionCode, Dictionary<KTextCode, string>> item) =>
            collection.Add(item.Key, item.Value);

        public void Clear() =>
            collection.Clear();

        public bool Contains(KeyValuePair<GCollectionCode, Dictionary<KTextCode, string>> item) =>
            collection.ContainsKey(item.Key) && collection.ContainsValue(item.Value);

        public bool ContainsKey(GCollectionCode key) =>
            collection.ContainsKey(key);

        public void CopyTo(KeyValuePair<GCollectionCode, Dictionary<KTextCode, string>>[] array, int arrayIndex)
        {
            if(collection.Count > arrayIndex)
            {
                throw new ArgumentException("The index is greater than the number of collections");
            }
            for(int c = 0; c < arrayIndex; c++) array[c] = collection.ToArray()[c];
        }

        public bool Remove(GCollectionCode key) =>
            collection.Remove(key);

        public bool Remove(KeyValuePair<GCollectionCode, Dictionary<KTextCode, string>> item) => 
            collection.Remove(item.Key);

        public bool TryGetValue(GCollectionCode key, [MaybeNullWhen(false)] out Dictionary<KTextCode, string> value) =>
            collection.TryGetValue(key, out value);

        public IEnumerator<KeyValuePair<GCollectionCode, Dictionary<KTextCode, string>>> GetEnumerator()
        {
            throw new NotImplementedException();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
