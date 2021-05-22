using System;
using System.Collections.Generic;
using System.Linq;
using Dunk.Tools.Foundation.Extensions;
using Dunk.Tools.Foundation.Text;
using NUnit.Framework;

namespace Dunk.Tools.Foundation.Test.Text
{
    [TestFixture]
    public class TrieTests
    {
        [Test]
        public void TrieInitialises()
        {
            var trie = new Trie();
            Assert.IsNotNull(trie);
        }

        [Test]
        public void TrieInitialisesWithDefaultRootNode()
        {
            const int expected = 0;

            var trie = new Trie();

            Assert.AreEqual(expected, trie.Count);
        }

        [Test]
        public void TrieInitialisesWithZeroCount()
        {
            var trie = new Trie();

            Assert.AreEqual(TrieNode.DefaultRootTrieNode, trie.RootNode);
        }

        [Test]
        public void TrieAddWordThrowsIfWordIsNull()
        {
            var trie = new Trie();

            Assert.Throws<ArgumentNullException>(() => trie.AddWord(null));
        }

        [Test]
        public void TrieAddWordsThrowsIfWordsCollectionIsNull()
        {
            var trie = new Trie();

            Assert.Throws<ArgumentNullException>(() => trie.AddWords(null));
        }

        [Test]
        public void TrieAddWordsThrowsIfWordsCollectionContainsNull()
        {
            var trie = new Trie();

            Assert.Throws<ArgumentNullException>(() => trie.AddWords(new string[] { null }));
        }

        [Test]
        public void TrieAddsWords()
        {
            const int expected = 5;

            var words = new List<string> { "ARM", "ARMED", "ARC", "JAWS", "JAZZ" };

            var trie = new Trie();

            trie.AddWords(words);

            Assert.AreEqual(expected, trie.Count);
        }

        [Test]
        public void TrieAddWordsUpdatesCountIfWordsAreAddedInDifferrentOrder()
        {
            const int expected = 5;

            var words = new List<string> { "ARMED", "ARM", "ARC", "JAWS", "JAZZ" };

            var trie = new Trie();

            trie.AddWords(words);

            Assert.AreEqual(expected, trie.Count);
        }

        [Test]
        public void TrieAddWordsUpdatesCountIfWordsAreAddedInRandomOrder()
        {
            const int expected = 5;

            var words = new List<string> { "ARMED", "ARM", "ARC", "JAWS", "JAZZ" };

            var trie = new Trie();

            trie.AddWords(words.Randomize());

            Assert.AreEqual(expected, trie.Count);
        }

        [Test]
        public void TrieAddWordsUpdatesCountOnceIfWordsAreAddedMultipleTimes()
        {
            const int expected = 1;

            var words = new List<string> { "ARMED", "ARMED", "ARMED", "ARMED", "ARMED" };

            var trie = new Trie();

            trie.AddWords(words);

            Assert.AreEqual(expected, trie.Count);
        }

        [Test]
        public void TrieGetWordsReturnsAllWordsInTrie()
        {
            const int expected = 5;

            var words = new List<string> { "ARM", "ARMED", "ARC", "JAWS", "JAZZ" };

            var trie = new Trie();

            trie.AddWords(words);

            var result = trie.GetWords().ToList();

            Assert.AreEqual(expected, result.Count);
        }

        [Test]
        public void TrieGetWordsReturnsAllWordsEnumerableSupportsTake()
        {
            const int expected = 2;

            var words = new List<string> { "ARM", "ARMED", "ARC", "JAWS", "JAZZ" };

            var trie = new Trie();

            trie.AddWords(words);

            var result = trie.GetWords().Take(2).ToList();

            Assert.AreEqual(expected, result.Count);
        }

        [Test]
        public void TrieGetWordsRetunsAllWordsEnumerableSupportsSkip()
        {
            const int expected = 3;

            var words = new List<string> { "ARM", "ARMED", "ARC", "JAWS", "JAZZ" };

            var trie = new Trie();

            trie.AddWords(words);

            var result = trie.GetWords().Skip(2).ToList();

            Assert.AreEqual(expected, result.Count);
        }

        [Test]
        public void TrieGetsReturnsEmptyIfTrieIsEmpty()
        {
            const int expected = 0;

            var trie = new Trie();

            var result = trie.GetWords().ToList();

            Assert.AreEqual(expected, result.Count);
        }

        [Test]
        public void TrieGetWordsByPrefixThrowsIfPrefixIsNull()
        {
            var trie = new Trie();

            Assert.Throws<ArgumentNullException>(() => trie.GetWords(null).ToList());
        }

        [Test]
        public void TrieGetWordsByPrefixReturnsAllWordsForPrefix()
        {
            const int expected = 3;

            var words = new List<string> { "ARM", "ARMED", "ARC", "JAWS", "JAZZ" };

            var trie = new Trie();

            trie.AddWords(words);

            var result = trie.GetWords("AR").ToList();

            Assert.AreEqual(expected, result.Count);
        }

        [Test]
        public void TrieGetWordsByPrefixEnumerableSupportsTake()
        {
            const int expected = 2;

            var words = new List<string> { "ARM", "ARMED", "ARC", "JAWS", "JAZZ" };

            var trie = new Trie();

            trie.AddWords(words);

            var result = trie.GetWords("AR").Take(2).ToList();

            Assert.AreEqual(expected, result.Count);
        }

        [Test]
        public void TrieGetWordsByPrefixEnumerableSupportsSkip()
        {
            const int expected = 1;

            var words = new List<string> { "ARM", "ARMED", "ARC", "JAWS", "JAZZ" };

            var trie = new Trie();

            trie.AddWords(words);

            var result = trie.GetWords("AR").Skip(2).ToList();

            Assert.AreEqual(expected, result.Count);
        }

        [Test]
        public void TrieGetWordsByPrefixReturnsEmptyIfPrefixIsNotInTrie()
        {
            const int expected = 0;

            var trie = new Trie();

            var result = trie.GetWords("AR").ToList();

            Assert.AreEqual(expected, result.Count);
        }

        [Test]
        public void TrieGetTrieNodeReturnsNodeIfPrefixIsPresent()
        {
            var words = new List<string> { "ARM", "ARMED", "ARC", "JAWS", "JAZZ" };

            var trie = new Trie();

            trie.AddWords(words);

            var node = trie.GetTrieNode("AR");

            Assert.IsNotNull(node);
        }

        [Test]
        public void TrieGetTrieNodeReturnsNullIfPrefixIsNotPresent()
        {
            var words = new List<string> { "ARM", "ARMED", "ARC", "JAWS", "JAZZ" };

            var trie = new Trie();

            trie.AddWords(words);

            var node = trie.GetTrieNode("FOO");

            Assert.IsNull(node);
        }

        [Test]
        public void TrieGetTrieNodeThrowsIfPrefixIsNull()
        {
            var trie = new Trie();

            Assert.Throws<ArgumentNullException>(() => trie.GetTrieNode(null));
        }

        [Test]
        public void TrieHasPrefixThrowsIfInputIsNull()
        {
            var trie = new Trie();

            Assert.Throws<ArgumentNullException>(() => trie.HasPrefix(null));
        }

        [Test]
        public void TrieHasPrefixReturnsTrueIfTrieContainsPrefix()
        {
            var words = new List<string> { "ARM", "ARMED", "ARC", "JAWS", "JAZZ" };

            var trie = new Trie();

            trie.AddWords(words);

            Assert.IsTrue(trie.HasPrefix("AR"));
        }

        [Test]
        public void TrieHasPrefixReturnsFalseIfTrieDoesNotContainPrefix()
        {
            var words = new List<string> { "ARM", "ARMED", "ARC", "JAWS", "JAZZ" };

            var trie = new Trie();

            trie.AddWords(words);

            Assert.IsFalse(trie.HasPrefix("BEE"));
        }

        [Test]
        public void TrieHasPrefixReturnsFalseForEmptyString()
        {
            var words = new List<string> { "ARM", "ARMED", "ARC", "JAWS", "JAZZ" };

            var trie = new Trie();

            trie.AddWords(words);

            Assert.IsFalse(trie.HasPrefix(string.Empty));
        }

        [Test]
        public void TrieHasPrefixReturnsFalseForDefaultChar()
        {
            var words = new List<string> { "ARM", "ARMED", "ARC", "JAWS", "JAZZ" };

            var trie = new Trie();

            trie.AddWords(words);

            Assert.IsFalse(trie.HasPrefix(new string(new[] { default(char) })));
        }

        [Test]
        public void TrieHasWordThrowsIfInputIsNull()
        {
            var trie = new Trie();

            Assert.Throws<ArgumentNullException>(() => trie.HasWord(null));
        }

        [Test]
        public void TrieHasPrefixReturnsTrueIfTrieContainsWord()
        {
            var words = new List<string> { "ARM", "ARMED", "ARC", "JAWS", "JAZZ" };

            var trie = new Trie();

            trie.AddWords(words);

            Assert.IsTrue(trie.HasWord("ARM"));
        }

        [Test]
        public void TrieHasPrefixReturnsFalseIfTrieDoesNotContainWord()
        {
            var words = new List<string> { "ARM", "ARMED", "ARC", "JAWS", "JAZZ" };

            var trie = new Trie();

            trie.AddWords(words);

            Assert.IsFalse(trie.HasWord("BEE"));
        }

        [Test]
        public void TrieHasPrefixReturnsFalseIfInputIsNotWord()
        {
            var words = new List<string> { "ARM", "ARMED", "ARC", "JAWS", "JAZZ" };

            var trie = new Trie();

            trie.AddWords(words);

            Assert.IsFalse(trie.HasWord("AR"));
        }

        [Test]
        public void TrieHasWordReturnsFalseForEmptyString()
        {
            var words = new List<string> { "ARM", "ARMED", "ARC", "JAWS", "JAZZ" };

            var trie = new Trie();

            trie.AddWords(words);

            Assert.IsFalse(trie.HasWord(string.Empty));
        }

        [Test]
        public void TrieHasWordReturnsFalseForDefaultChar()
        {
            var words = new List<string> { "ARM", "ARMED", "ARC", "JAWS", "JAZZ" };

            var trie = new Trie();

            trie.AddWords(words);

            Assert.IsFalse(trie.HasWord(new string(new[] { default(char) })));
        }

        [Test]
        public void TrieClearRemovesAllChildNodes()
        {
            var words = new List<string> { "ARM", "ARMED", "ARC", "JAWS", "JAZZ" };

            var trie = new Trie();

            trie.AddWords(words);

            trie.Clear();

            Assert.AreEqual(0, trie.Count);
        }

        [Test]
        public void TrieClearDoesNotThrowIfNoChildNodes()
        {
            var trie = new Trie();

            Assert.DoesNotThrow(() => trie.Clear());
            Assert.AreEqual(0, trie.Count);
        }

        [Test]
        public void TrieRemoveByPrefixReturnsFalseIfTrieDoesNotContainPrefix()
        {
            var words = new List<string> { "ARM", "ARMED", "ARC", "JAWS", "JAZZ" };

            var trie = new Trie();

            trie.AddWords(words);

            Assert.IsFalse(trie.RemovePrefix("FOO"));
        }

        [Test]
        public void TrieRemoveByPrefixReturnsTrueIfTrieDoesContainPrefix()
        {
            var words = new List<string> { "ARM", "ARMED", "ARC", "JAWS", "JAZZ" };

            var trie = new Trie();

            trie.AddWords(words);

            Assert.IsTrue(trie.RemovePrefix("AR"));
        }

        [Test]
        public void TrieRemoveByPrefixRemovesExpectedStrings()
        {
            var words = new List<string> { "ARM", "ARMED", "ARC", "JAWS", "JAZZ" };

            var trie = new Trie();

            trie.AddWords(words);

            trie.RemovePrefix("AR");

            Assert.IsFalse(trie.HasWord("ARM"));
            Assert.IsFalse(trie.HasWord("ARMED"));
            Assert.IsFalse(trie.HasWord("ARC"));
            Assert.AreEqual(2, trie.Count);
        }

        [Test]
        public void TrieRemoveByPrefixThrowsIfSpecifiedWordIsNull()
        {
            var words = new List<string> { "ARM", "ARMED", "ARC", "JAWS", "JAZZ" };

            var trie = new Trie();

            trie.AddWords(words);

            Assert.Throws<ArgumentNullException>(() => trie.RemovePrefix(null));
        }

        [Test]
        public void TrieRemoveByPrefixReturnsFalseIfSpecifiedPrefixIsEmpty()
        {
            var words = new List<string> { "ARM", "ARMED", "ARC", "JAWS", "JAZZ" };

            var trie = new Trie();

            trie.AddWords(words);

            Assert.IsFalse(trie.RemovePrefix(string.Empty));
        }

        [Test]
        public void TrieRemoveByPrefixDoesNotRemoveAnyNodesIfSpecifiedPrefixIsEmpty()
        {
            var words = new List<string> { "ARM", "ARMED", "ARC", "JAWS", "JAZZ" };

            var trie = new Trie();

            trie.AddWords(words);

            trie.RemovePrefix(string.Empty);

            words.ForEach(s =>
                Assert.IsTrue(trie.HasWord(s)));
            Assert.AreEqual(5, trie.Count);
        }

        [Test]
        public void TrieRemoveByPrefixReturnsFalseIfSpecifiedPrefixIsDefaultChar()
        {
            var words = new List<string> { "ARM", "ARMED", "ARC", "JAWS", "JAZZ" };

            var trie = new Trie();

            trie.AddWords(words);

            Assert.IsFalse(trie.RemovePrefix(new string(new[] { default(char) })));
        }

        [Test]
        public void TrieRemoveByPrefixDoesNotRemoveAnyNodesIfSpecifiedPrefixIsDefaultChar()
        {
            var words = new List<string> { "ARM", "ARMED", "ARC", "JAWS", "JAZZ" };

            var trie = new Trie();

            trie.AddWords(words);

            trie.RemovePrefix(new string(new[] { default(char) }));

            words.ForEach(s =>
                Assert.IsTrue(trie.HasWord(s)));
            Assert.AreEqual(5, trie.Count);
        }

        [Test]
        public void TrieRemoveByWordReturnsFalseIfTrieDoesNotContainWord()
        {
            var words = new List<string> { "ARM", "ARMED", "ARC", "JAWS", "JAZZ" };

            var trie = new Trie();

            trie.AddWords(words);

            Assert.IsFalse(trie.RemoveWord("FOO"));
        }

        [Test]
        public void TrieRemoveByWordReturnsFalseIfTrieDoesNotContainStringAsWord()
        {
            var words = new List<string> { "ARM", "ARMED", "ARC", "JAWS", "JAZZ" };

            var trie = new Trie();

            trie.AddWords(words);

            Assert.IsFalse(trie.RemoveWord("AR"));
        }

        [Test]
        public void TrieRemoveByWordReturnsTrueIfTrieContainsWord()
        {
            var words = new List<string> { "ARM", "ARMED", "ARC", "JAWS", "JAZZ" };

            var trie = new Trie();

            trie.AddWords(words);

            Assert.IsTrue(trie.RemoveWord("ARM"));
        }

        [Test]
        public void TrieRemoveByWordRemovesExpectedString()
        {
            var words = new List<string> { "ARM", "ARMED", "ARC", "JAWS", "JAZZ" };

            var trie = new Trie();

            trie.AddWords(words);

            trie.RemoveWord("ARM");

            Assert.IsFalse(trie.HasWord("ARM"));
            Assert.AreEqual(4, trie.Count);
        }

        [Test]
        public void TrieRemoveByWordOnlyRemoveSpecifiedWord()
        {
            var words = new List<string> { "ARM", "ARMED", "ARC", "JAWS", "JAZZ" };

            var trie = new Trie();

            trie.AddWords(words);

            trie.RemoveWord("ARM");

            Assert.IsTrue(trie.HasWord("ARMED"));
            Assert.AreEqual(4, trie.Count);
        }

        [Test]
        public void TrieRemoveByWordThrowsIfSpecifiedWordIsNull()
        {
            var words = new List<string> { "ARM", "ARMED", "ARC", "JAWS", "JAZZ" };

            var trie = new Trie();

            trie.AddWords(words);

            Assert.Throws<ArgumentNullException>(() => trie.RemoveWord(null));
        }

        [Test]
        public void TrieRemoveByWordReturnsFalseIfSpecifiedWordIsEmpty()
        {
            var words = new List<string> { "ARM", "ARMED", "ARC", "JAWS", "JAZZ" };

            var trie = new Trie();

            trie.AddWords(words);

            Assert.IsFalse(trie.RemoveWord(string.Empty));
        }

        [Test]
        public void TrieRemoveByWordDoesNotRemoveAnyNodesIfSpecifiedWordIsEmpty()
        {
            var words = new List<string> { "ARM", "ARMED", "ARC", "JAWS", "JAZZ" };

            var trie = new Trie();

            trie.AddWords(words);

            words.ForEach(s =>
                Assert.IsTrue(trie.HasWord(s)));
            Assert.AreEqual(5, trie.Count);
        }

        [Test]
        public void TrieRemoveByWordReturnsFalseIfSpecifiedWordIsDefaultChar()
        {
            var words = new List<string> { "ARM", "ARMED", "ARC", "JAWS", "JAZZ" };

            var trie = new Trie();

            trie.AddWords(words);

            Assert.IsFalse(trie.RemoveWord(new string(new[] { default(char) })));
        }

        [Test]
        public void TrieRemoveByWordDoesNotRemoveAnyNodesIfSpecifiedWordIsDefaultChar()
        {
            var words = new List<string> { "ARM", "ARMED", "ARC", "JAWS", "JAZZ" };

            var trie = new Trie();

            trie.AddWords(words);

            trie.RemoveWord(new string(new[] { default(char) }));

            words.ForEach(s =>
                Assert.IsTrue(trie.HasWord(s)));
            Assert.AreEqual(5, trie.Count);
        }
    }
}
