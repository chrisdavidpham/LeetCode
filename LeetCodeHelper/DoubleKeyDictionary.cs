namespace LeetCodeHelper
{
    public class DoubleKeyDictionary<T1, T2, T3> : Dictionary<T1, Dictionary<T2, T3>>
        where T1 : notnull
        where T2 : notnull
    {
        public void Add(T1 key1, T2 key2, T3 value)
        {
            if (!this.TryGetValue(key1, out var dictionary))
            {
                dictionary = new Dictionary<T2, T3>();
                this.Add(key1, dictionary);
            }
            dictionary.Add(key2, value);
        }

        public bool TryAdd(T1 key1, T2 key2, T3 value)
        {
            if (!this.TryGetValue(key1, out var dictionary))
            {
                dictionary = new Dictionary<T2, T3>();
                this.Add(key1, dictionary);
            }
            return dictionary.TryAdd(key2, value);
        }

        public bool TryGetValue(T1 key1, T2 key2, out T3 value)
        {
            if(!(this.TryGetValue(key1, out var dictionary) && dictionary.TryGetValue(key2, out value)) {
                value = default(T3);
                return false;
            }
            return true;
        }
    }
}