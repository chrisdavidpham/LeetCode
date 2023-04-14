using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnightDialer
{
    public class KnightDialTreeNode
    {
        public PhonePadPosition Position { get; private set; }
        public KnightDialTreeNode[]? Children { get; private set; }
        public KnightDialTreeNode? Parent { get; private set; }

        public KnightDialTreeNode(PhonePadPosition position, KnightDialTreeNode[]? children = null, KnightDialTreeNode? parent = null)
        {
            Position = position;
            Children = children;
            Parent = parent;
        }
    }
}
