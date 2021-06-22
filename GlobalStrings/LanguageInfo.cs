using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace GlobalStrings
{
    public sealed class LanguageInfo<TLangCode, KTextCode, GCollectionCode>
    {
        public TLangCode langCode { get; private set; }

        [AllowNull]
        [Obsolete]
        public Dictionary<KTextCode, string> textLangBook { get; set; }
        public TextBookCollection<TLangCode, KTextCode, GCollectionCode> textBookCollection { get; set; }

        public LanguageInfo(TLangCode langCode, Dictionary<KTextCode, string> textLangBook = null, 
            TextBookCollection<TLangCode, KTextCode, GCollectionCode> textBookCollection = null)
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
