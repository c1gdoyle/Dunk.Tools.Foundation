using System;
using System.Collections.Generic;

namespace Dunk.Tools.Foundation.Text
{
	/// <summary>
	/// An interface that defines the behaviour of a 
	/// Trie data-structure.
	/// </summary>
	/// <remarks>
	/// See https://visualstudiomagazine.com/articles/2015/10/20/text-pattern-search-trie-class-net.aspx.
	/// </remarks>
	public interface ITrie
    {
        /// <summary>
        /// Gets the total word count stored in this Trie.
        /// </summary>
        int Count { get; }

        /// <summary>
        /// Gets the root node for this Trie.
        /// </summary>
        TrieNode RootNode { get; }

		/// <summary>
		/// Adds a word to this Trie.
		/// </summary>
		/// <param name="word">The word to add.</param>
		/// <exception cref="ArgumentNullException"><paramref name="word"/> was null.</exception>
		void AddWord(string word);

		/// <summary>
		/// Adds a sequence of words to this Trie.
		/// </summary>
		/// <param name="words">The words to add.</param>
		/// <exception cref="ArgumentNullException"><paramref name="words"/> was null.</exception>
		void AddWords(IEnumerable<string> words);

		/// <summary>
		/// Clears all the words stored in this Trie.
		/// </summary>
		void Clear();

		/// <summary>
		/// Gets the node associated with a specified prefix.
		/// </summary>
		/// <param name="prefix">The prefix to search for.</param>
		/// <returns>
		/// The node for prefix if present in this Trie; otherwise returns null.
		/// </returns>
		/// <exception cref="ArgumentNullException"><paramref name="prefix"/> was null.</exception>
		TrieNode GetTrieNode(string prefix);

		/// <summary>
		/// Gets all words in this Trie.
		/// </summary>
		/// <returns>
		/// A sequence of words.
		/// </returns>
		IEnumerable<string> GetWords();

		/// <summary>
		/// Gets all words in this Trie using a specified prefix.
		/// </summary>
		/// <param name="prefix">The prefix to search on.</param>
		/// <returns>
		/// A sequence of words.
		/// </returns>
		/// <exception cref="ArgumentNullException"><paramref name="prefix"/> was null.</exception>
		IEnumerable<string> GetWords(string prefix);

		/// <summary>
		/// Checks if a specified prefix is stored in this Trie.
		/// </summary>
		/// <param name="prefix">The prefix to search for.</param>
		/// <returns>
		/// <c>true</c> if the prefix is stored in the Trie; otherwise returns <c>false</c>.
		/// </returns>
		/// <exception cref="ArgumentNullException"><paramref name="prefix"/> was null.</exception>
		bool HasPrefix(string prefix);

		/// <summary>
		/// Checks if a specified word is stored in this Trie.
		/// </summary>
		/// <param name="word">The word to search for.</param>
		/// <returns>
		/// <c>true</c> if the word is stored in the Trie; otherwise returns <c>false</c>.
		/// </returns>
		/// <exception cref="ArgumentNullException"><paramref name="word"/> was null.</exception>
		bool HasWord(string word);

		/// <summary>
		/// Removes words by prefix from the Trie.
		/// </summary>
		/// <param name="prefix">The prefix to remove.</param>
		/// <returns><c>true</c> if prefix is successfully removed; otherwise returns <c>false</c>.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="prefix"/> was null.</exception>
		bool RemovePrefix(string prefix);

		/// <summary>
		/// Removes word from this Trie.
		/// </summary>
		/// <param name="word">The word to remove.</param>
		/// <returns><c>true</c> if word is successfully removed; otherwise returns <c>false</c>.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="word"/> was null.</exception>
		bool RemoveWord(string word);
	}
}
