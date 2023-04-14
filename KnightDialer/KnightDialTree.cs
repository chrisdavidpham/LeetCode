using KnightDialer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnightDialer
{
    public class KnightDialTree
    {
        private KnightDialTreeNode _head;
        private Dictionary<PhonePadPosition, KnightDialTreeNode> _nodeDictionary;
        private Dictionary<PhonePadPosition, Dictionary<int, int>> _permutationDictionary;

        public KnightDialTree(PhonePadPosition head)
        {
            _head = head;
            _nodeDictionary = KnightMoveSetBuilder.BuildKnightMoveSet();
            _permutationDictionary = new Dictionary<PhonePadPosition, Dictionary<int, int>>();
        }

    }
}

