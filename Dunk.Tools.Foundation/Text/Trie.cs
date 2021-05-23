using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dunk.Tools.Foundation.Text
{
    /// <summary>
    /// Default implementation of <see cref="ITrie"/>.
    /// </summary>
    public class Trie : ITrie
    {
        private readonly TrieNode _rootNode;

        /// <summary>
        /// Initialises a new instance of <see cref="Trie"/>.
        /// </summary>
        public Trie()
        {
            _rootNode = TrieNode.DefaultRootTrieNode;
        }

        #region ITrie Members
        /// <inheritdoc />
        public int Count
        {
            get 
            {
                int count = 0;
                DetermineCount(RootNode, ref count);
                return count; 
            }
        }

        /// <inheritdoc />
        public TrieNode RootNode
        {
            get { return _rootNode; }
        }

        /// <inheritdoc />
        public void AddWord(string word)
        {
            if (word == null)
            {
                throw new ArgumentNullException(nameof(word),
                    $"Unable to add word to {typeof(Trie).Name}, {nameof(word)} parameter cannot be null");
            }
            AddWord(RootNode, word.ToCharArray());
        }

        /// <inheritdoc />
        public void AddWords(IEnumerable<string> words)
        {
            if(words == null)
            {
                throw new ArgumentNullException(nameof(words),
                    $"Unable to add words to {typeof(Trie).Name}, {nameof(words)} parameter cannot be null");
            }

            foreach(string word in words)
            {
                AddWord(word);
            }
        }

        /// <inheritdoc />
        public void Clear()
        {
            RootNode.Clear();
        }

        /// <inheritdoc />
        public TrieNode GetTrieNode(string prefix)
        {
            if (prefix == null)
            {
                throw new ArgumentNullException(nameof(prefix),
                    $"Unable to get trie-node from {typeof(Trie).Name}, {nameof(prefix)} parameter cannot be null");
            }
            return RootNode.GetTrieNode(prefix);
        }

        /// <inheritdoc />
        public IEnumerable<string> GetWords()
        {
            return GetWords(string.Empty);
        }

        /// <inheritdoc />
        public IEnumerable<string> GetWords(string prefix)
        {
            CheckGetWordsArgument(prefix);

            foreach (var word in Traverse(GetTrieNode(prefix), new StringBuilder(prefix)))
            {
                yield return word;
            }
        }

        /// <inheritdoc />
        public bool HasPrefix(string prefix)
        {
            if (prefix == null)
            {
                throw new ArgumentNullException(nameof(prefix),
                    $"Unable to lookup prefix from {typeof(Trie).Name}, {nameof(prefix)} parameter cannot be null");
            }
            var trieNode = GetTrieNode(prefix);
            return trieNode != null &&
                !trieNode.IsRoot;
        }

        /// <inheritdoc />
        public bool HasWord(string word)
        {
            if (word == null)
            {
                throw new ArgumentNullException(nameof(word),
                    $"Unable to lookup word from {typeof(Trie).Name}, {nameof(word)} parameter cannot be null");
            }
            var trieNode = GetTrieNode(word);
            return trieNode != null &&
                !trieNode.IsRoot &&
                trieNode.IsWord;
        }

        /// <inheritdoc />
        public bool RemovePrefix(string prefix)
        {
            if (prefix == null)
            {
                throw new ArgumentNullException(nameof(prefix),
                    $"Unable to remove prefix from {typeof(Trie).Name}, {nameof(prefix)} parameter cannot be null");
            }
            
            if(prefix.Length == 0)
            {
                return false;
            }

            var nodesToRemove = GetTrieNodesToRemoveForPrefix(prefix);
            if(nodesToRemove.Count == 0)
            {
                return false;
            }

            RemovePrefix(nodesToRemove);
            return true;
        }

        /// <inheritdoc />
        public bool RemoveWord(string word)
        {
            if (word == null)
            {
                throw new ArgumentNullException(nameof(word),
                    $"Unable to remove word from {typeof(Trie).Name}, {nameof(word)} parameter cannot be null");
            }

            if (word.Length == 0)
            {
                return false;
            }

            var nodesToRemove = GetTrieNodesToRemoveForWord(word);
            if(nodesToRemove.Count == 0)
            {
                return false;
            }

            RemoveWord(nodesToRemove);
            return true;
        }
        #endregion ITrie Members

        private static void CheckGetWordsArgument(string prefix)
        {
            if (prefix == null)
            {
                throw new ArgumentNullException(nameof(prefix),
                    $"Unable to get words from {typeof(Trie).Name}, {nameof(prefix)} parameter cannot be null");
            }
        }

        private void AddWord(TrieNode trieNode, char[] word)
        {
            for(int i = 0; i < word.Length; i++)
            {
                char currentCharacter = word[i];
                var child = trieNode.GetChild(currentCharacter);
                if (child == null)
                {
                    child = new TrieNode(currentCharacter);
                    trieNode.SetChild(child);
                }
                trieNode = child;
            }
            trieNode.IsWord = true;
        }

        private void DetermineCount(TrieNode node, ref int count)
        {
            if (node.IsWord)
            {
                count += 1;
            }
            foreach(var childNode in node.GetChildren())
            {
                DetermineCount(childNode, ref count);
            }
        }

        private IEnumerable<string> Traverse(TrieNode trieNode, StringBuilder buffer)
        {
            if (trieNode == null)
            {
                yield break;
            }
            if (trieNode.IsWord)
            {
                yield return buffer.ToString();
            }
            foreach (var child in trieNode.GetChildren())
            {
                buffer.Append(child.Character);
                foreach (var word in Traverse(child, buffer))
                {
                    yield return word;
                }
                buffer.Length--;
            }
        }

        private Stack<TrieNode> GetTrieNodesToRemoveForPrefix(string prefix)
        {
            var nodes = new Stack<TrieNode>(prefix.Length + 1);
            var trieNode = RootNode;
            nodes.Push(RootNode);
            for(int i = 0; i < prefix.Length; i++)
            {
                char currentChar = prefix[i];
                trieNode = trieNode.GetChild(currentChar);
                if(trieNode == null)
                {
                    nodes.Clear();
                    break;
                }
                nodes.Push(trieNode);
            }

            return nodes;
        }

        private Stack<TrieNode> GetTrieNodesToRemoveForWord(string word)
        {
            var nodes = new Stack<TrieNode>(word.Length + 1);
            var trieNode = RootNode;
            nodes.Push(RootNode);
            for (int i = 0; i < word.Length; i++)
            {
                char currentChar = word[i];
                trieNode = trieNode.GetChild(currentChar);
                if (trieNode == null)
                {
                    nodes.Clear();
                    break;
                }
                nodes.Push(trieNode);
            }

            return trieNode != null && !trieNode.IsWord ?
                new Stack<TrieNode>() :
                nodes;
        }

        private void RemoveWord(Stack<TrieNode> trieNodes)
        {
            //mark the last node as not word
            trieNodes.Peek().IsWord = false;
            Trim(trieNodes);
        }

        private void RemovePrefix(Stack<TrieNode> trieNodes)
        {
            // Clear the last trieNode
            trieNodes.Peek().Clear();
            // Trim excess trieNodes
            Trim(trieNodes);
        }

        private void Trim(Stack<TrieNode> trieNodes)
        {
            while(trieNodes.Count > 1)
            {
                var trieNode = trieNodes.Pop();
                var parentTrieNode = trieNodes.Peek();
                if (trieNode.IsWord 
                    || trieNode.GetChildren().Any())
                {
                    break;
                }
                parentTrieNode.RemoveChildNode(trieNode.Character);
            }
        }
    }
}
