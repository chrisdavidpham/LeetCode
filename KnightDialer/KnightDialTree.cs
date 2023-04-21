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
        private PhonePadPosition _headPosition;
        private KnightDialTreeService _knightDialTreeService;
        private Dictionary<PhonePadPosition, KnightDialTreeNode> _nodeDictionary;

        public KnightDialTree(PhonePadPosition head) : this(head, new KnightDialTreeService()) {}

        public KnightDialTree(PhonePadPosition head, KnightDialTreeService knightDialTreeService)
        {
            _headPosition = head;
            _knightDialTreeService = knightDialTreeService;
            _nodeDictionary = KnightMoveSetBuilder.BuildKnightMoveSet();
        }

        public void BuildTree(int depth)
        {

        }
    }
}

