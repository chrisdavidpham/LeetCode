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

public static class KnightMoveSetBuilder
{
    public static Dictionary<PhonePadPosition, KnightDialTreeNode> BuildKnightMoveSet()
    {
        return new Dictionary<PhonePadPosition, KnightDialTreeNode>
        {
            {
                PhonePadPosition.Zero,
                new KnightDialTreeNode
                (
                    PhonePadPosition.Zero,
                    new KnightDialTreeNode[]
                    {
                        new KnightDialTreeNode(PhonePadPosition.Four),
                        new KnightDialTreeNode(PhonePadPosition.Six),
                    }
                )
            },
            {
                PhonePadPosition.One,
                new KnightDialTreeNode
                (
                    PhonePadPosition.One,
                    new KnightDialTreeNode[]
                    {
                        new KnightDialTreeNode(PhonePadPosition.Six),
                        new KnightDialTreeNode(PhonePadPosition.Eight),
                    }
                )
            },
            {
                PhonePadPosition.Two,
                new KnightDialTreeNode
                (
                    PhonePadPosition.Two,
                    new KnightDialTreeNode[]
                    {
                        new KnightDialTreeNode(PhonePadPosition.Seven),
                        new KnightDialTreeNode(PhonePadPosition.Nine),
                    }
                )
            },
            {
                PhonePadPosition.Three,
                new KnightDialTreeNode
                (
                    PhonePadPosition.Three,
                    new KnightDialTreeNode[]
                    {
                        new KnightDialTreeNode(PhonePadPosition.Four),
                        new KnightDialTreeNode(PhonePadPosition.Eight),
                    }
                )
            },
            {
                PhonePadPosition.Four,
                new KnightDialTreeNode
                (
                    PhonePadPosition.Four,
                    new KnightDialTreeNode[]
                    {
                        new KnightDialTreeNode(PhonePadPosition.Zero),
                        new KnightDialTreeNode(PhonePadPosition.Three),
                        new KnightDialTreeNode(PhonePadPosition.Nine),
                    }
                )
            },
            {
                PhonePadPosition.Five,
                new KnightDialTreeNode
                (
                    PhonePadPosition.Five,
                    new KnightDialTreeNode[]{}
                )
            },
            {
                PhonePadPosition.Six,
                new KnightDialTreeNode
                (
                    PhonePadPosition.Six,
                    new KnightDialTreeNode[]
                    {
                        new KnightDialTreeNode(PhonePadPosition.One),
                        new KnightDialTreeNode(PhonePadPosition.Seven),
                        new KnightDialTreeNode(PhonePadPosition.Zero),
                    }
                )
            },
            {
                PhonePadPosition.Seven,
                new KnightDialTreeNode
                (
                    PhonePadPosition.Seven,
                    new KnightDialTreeNode[]
                    {
                        new KnightDialTreeNode(PhonePadPosition.Two),
                        new KnightDialTreeNode(PhonePadPosition.Six),
                    }
                )
            },
            {
                PhonePadPosition.Eight,
                new KnightDialTreeNode
                (
                    PhonePadPosition.Eight,
                    new KnightDialTreeNode[]
                    {
                        new KnightDialTreeNode(PhonePadPosition.One),
                        new KnightDialTreeNode(PhonePadPosition.Three),
                    }
                )
            },
            {
                PhonePadPosition.Nine,
                new KnightDialTreeNode
                (
                    PhonePadPosition.Nine,
                    new KnightDialTreeNode[]
                    {
                        new KnightDialTreeNode(PhonePadPosition.Two),
                        new KnightDialTreeNode(PhonePadPosition.Four),
                    }
                )
            }
        };
    }
}