using System;
using System.Collections.Generic;

namespace LeetCodeExcercise
{
    public class StreamChecker
    {
        private readonly Trier trier;
        private TrierNode current;
        public StreamChecker(string[] words)
        {
            // build trier and fail pointer
            trier = new Trier(words);
            current = trier.Root;
        }

        public bool Query(char letter)
        {
            TrierNode longest = null;
            while (current != null)
            {
                if (current.Children.TryGetValue(letter, out TrierNode child))
                {
                    if (longest == null)
                        longest = child;
                    if (child.IsEndingChar)
                    {
                        current = longest;
                        return true;
                    }
                }
                current = current.Fail;
            }
            current = longest ?? trier.Root;
            return false;
        }
    }

    class Trier
    {
        public TrierNode Root { get; set; }
        public Trier(string[] words)
        {
            BuildTrier(words);
            BuildFailPointer();
        }

        private void BuildTrier(string[] words)
        {
            Root = new TrierNode(' ');
            foreach (var word in words)
            {
                var current = Root;
                foreach (var wc in word)
                {
                    if (!current.Children.ContainsKey(wc))
                        current.Children[wc] = new TrierNode(wc);
                    current = current.Children[wc];
                }
                current.IsEndingChar = true;
            }
        }

        private void BuildFailPointer()
        {
            var queue = new Queue<TrierNode>();
            queue.Enqueue(Root);
            while (queue.TryDequeue(out TrierNode current))
            {
                foreach (var kvPair in current.Children)
                {
                    var f = current.Fail;
                    while (f != null)
                    {
                        if (f.Children.TryGetValue(kvPair.Key, out TrierNode fChild))
                        {
                            kvPair.Value.Fail = fChild;
                            break;
                        }
                        f = f.Fail;
                    }
                    if (f == null)
                        kvPair.Value.Fail = Root;
                    queue.Enqueue(kvPair.Value);
                }
            }
        }
    }

    class TrierNode
    {
        public char C { get; set; }
        public Dictionary<char, TrierNode> Children { get; set; }
        public bool IsEndingChar { get; set; }
        public TrierNode Fail { get; set; }

        public TrierNode(char c)
        {
            C = c;
            Children = new Dictionary<char, TrierNode>();
        }
    }
}
