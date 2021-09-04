using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace GlobalStrings.Collection
{
    /// <summary>
    /// Collection of strings with an identifier.
    /// </summary>
    /// <typeparam name="GCollectionCode">Type of unique identifier of the collection.</typeparam>
    /// <typeparam name="KTextCode">Type of identifier of each string in the collection.</typeparam>
    public sealed class TextBookCollection<GCollectionCode, KTextCode> :
        IDictionary<GCollectionCode, Dictionary<KTextCode, string>>
    {
        private Dictionary<GCollectionCode, Dictionary<KTextCode, string>> collection;
        public Dictionary<KTextCode, string> this[GCollectionCode collectionCode] 
            { get => collection[collectionCode]; set => collection[collectionCode] = value; }
        public ICollection<GCollectionCode> Keys => collection.Keys;
        public ICollection<Dictionary<KTextCode, string>> Values => collection.Values;
        public int Count => collection.Count;
        public bool IsReadOnly => false;

        public TextBookCollection() => collection = new();
        
        /// <summary>
        /// Adds the specified key and value to the <c>TextBookCollection</c>.
        /// </summary>
        /// <param name="key">The key of the collection to be added.</param>
        /// <param name="value">The <c>Dictionary&lt;KTextCode, string&gt;</c> to be added.</param>
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
                throw new ArgumentException("The index is greater than the number of collections");

            for(int c = 0; c < arrayIndex; c++) array[c] = collection.ToArray()[c];
        }
        
        /// <summary>
        /// Removes the element with the specified key from the <c>TextBookCollection</c> object.
        /// </summary>
        /// <param name="key">The key of the element to be removed.</param>
        /// <returns>true if the element is successfully found and removed; otherwise, false.
        /// This method returns false if key is not found in the Dictionary&lt;TKey,TValue&gt;.</returns>
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