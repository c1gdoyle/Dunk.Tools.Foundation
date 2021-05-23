using System;
using System.Collections.Generic;

namespace Dunk.Tools.Foundation.Text
{
    /// <summary>
    /// A node for <see cref="ITrie"/>
    /// </summary>
    [System.Diagnostics.DebuggerDisplay("Character = {Character}")]
    public sealed class TrieNode : IEquatable<TrieNode>
    {
        private readonly Dictionary<char, TrieNode> _children;

        /// <summary>
        /// Initialises a new instance of <see cref="TrieNode"/> with a 
        /// specified character.
        /// </summary>
        /// <param name="c">The character.</param>
        public TrieNode(char c)
        {
            Character = c;
            _children = new Dictionary<char, TrieNode>();
        }

        /// <summary>
        /// Initialises a new instance of <see cref="TrieNode"/> with a 
        /// flag indicating whether it is the root and a specified character.
        /// </summary>
        /// <param name="isRoot">The flag</param>
        /// <param name="c"></param>
        private TrieNode(bool isRoot, char c)
        {
            IsRoot = isRoot;
            Character = c;
            _children = new Dictionary<char, TrieNode>();
        }

        /// <summary>
        /// Gets or sets the character stored in this node.
        /// </summary>
        public char Character 
        { 
            get; 
            private set; 
        }

        /// <summary>
        /// Gets or sets whether this node is the root.
        /// </summary>
        internal bool IsRoot
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets or sets whether this node is a word.
        /// </summary>
        internal bool IsWord
        {
            get;
            set;
        }

        internal void Clear()
        {
            _children.Clear();
        }

        internal IEnumerable<TrieNode> GetChildren()
        {
            return _children.Values;
        }

        internal TrieNode GetChild(char character)
        {
            TrieNode childNode;
            return _children.TryGetValue(character, out childNode) ? childNode : null;
        }

        internal void SetChild(TrieNode childNode)
        {
            _children[childNode.Character] = childNode;
        }

        internal TrieNode GetTrieNode(string prefix)
        {
            TrieNode trieNode = this;
            for(int i = 0; i < prefix.Length; i++)
            {
                trieNode = trieNode.GetChild(prefix[i]);
                if (trieNode == null)
                {
                    break;
                }
            }
            return trieNode;
        }

        internal void RemoveChildNode(char c)
        {
            _children.Remove(c);
        }

        #region IEquatable<TrieNode> Members
        public bool Equals(TrieNode other)
        {
            return other != null &&
                other.Character == Character;
        }
        #endregion IEquatable<TrieNode> Members

        public static TrieNode DefaultRootTrieNode => new TrieNode(true, default(char));
    }
}
