using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace GlobalStrings.Types
{
    /// <summary>
    /// Collection of strings with an identifier.
    /// </summary>
    /// <typeparam name="GCollectionCode">Type of unique identifier of the collection.</typeparam>
    /// <typeparam name="KTextCode">Type of identifier of each string in the collection.</typeparam>
    public sealed class TextBookCollection<GCollectionCode, KTextCode> :
        IDictionary<GCollectionCode, Dictionary<KTextCode, string>>
    {
        private readonly Dictionary<GCollectionCode, Dictionary<KTextCode, string>> _collection;
        public Dictionary<KTextCode, string> this[GCollectionCode collectionCode]
            { get => _collection[collectionCode]; set => _collection[collectionCode] = value; }
        public ICollection<GCollectionCode> Keys => _collection.Keys;
        public ICollection<Dictionary<KTextCode, string>> Values => _collection.Values;
        public int Count => _collection.Count;
        public bool IsReadOnly => false;

        public TextBookCollection()
        {
            _collection = new();
        }
        public TextBookCollection(Dictionary<GCollectionCode, Dictionary<KTextCode, string>> collection)
        {
            _collection = collection;
        }
        
        /// <summary>
        /// Adds the specified key and value to the <c>TextBookCollection</c>.
        /// </summary>
        /// <param name="key">The key of the collection to be added.</param>
        /// <param name="value">The <c>Dictionary&lt;KTextCode, string&gt;</c> to be added.</param>
        public void Add(GCollectionCode key, Dictionary<KTextCode, string> value) =>
            _collection.Add(key, value);

        public void Add(KeyValuePair<GCollectionCode, Dictionary<KTextCode, string>> item) =>
            _collection.Add(item.Key, item.Value);

        public void Clear() =>
            _collection.Clear();

        public bool Contains(KeyValuePair<GCollectionCode, Dictionary<KTextCode, string>> item) =>
            _collection.ContainsKey(item.Key) && _collection.ContainsValue(item.Value);

        public bool ContainsKey(GCollectionCode key) =>
            _collection.ContainsKey(key);

        public void CopyTo(KeyValuePair<GCollectionCode, Dictionary<KTextCode, string>>[] array, int arrayIndex)
        {
            if(_collection.Count > arrayIndex)
                throw new ArgumentException("The index is greater than the number of collections");

            for(int c = 0; c < arrayIndex; c++) array[c] = _collection.ToArray()[c];
        }
        
        /// <summary>
        /// Removes the element with the specified key from the <c>TextBookCollection</c> object.
        /// </summary>
        /// <param name="key">The key of the element to be removed.</param>
        /// <returns>true if the element is successfully found and removed; otherwise, false.
        /// This method returns false if key is not found in the Dictionary&lt;TKey,TValue&gt;.</returns>
        public bool Remove(GCollectionCode key) =>
            _collection.Remove(key);

        public bool Remove(KeyValuePair<GCollectionCode, Dictionary<KTextCode, string>> item) => 
            _collection.Remove(item.Key);

        public bool TryGetValue(GCollectionCode key, [MaybeNullWhen(false)] out Dictionary<KTextCode, string> value) =>
            _collection.TryGetValue(key, out value);

        public IEnumerator<KeyValuePair<GCollectionCode, Dictionary<KTextCode, string>>> GetEnumerator()
        {
            return _collection.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _collection.GetEnumerator();
        }
    }
}