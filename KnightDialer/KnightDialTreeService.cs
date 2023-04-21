using LeetCodeHelper;

namespace KnightDialer
{
    // This service can help a KnightDialTree build faster by caching data about the PhonePadPosition permutation count at certain depths
    public class KnightDialTreeService
    {
        private DoubleKeyDictionary<PhonePadPosition, int, int> _permutationDictionaries;

        public KnightDialTreeService() 
        {
            _permutationDictionaries = new DoubleKeyDictionary<PhonePadPosition, int, int>();
        }

        public bool TryAddPermutationCount(PhonePadPosition position, int depth, int count)
        {
            return _permutationDictionaries.TryAdd(position, depth, count);
        }

        public bool TryGetPermutationCount(PhonePadPosition position, int depth, out int count)
        {
            return _permutationDictionaries.TryGetValue(position, depth, out count);
        }
    }
}
