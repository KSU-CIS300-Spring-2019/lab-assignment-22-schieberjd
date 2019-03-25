/* TrieWithOneChild.cs
 * Author: Justin Schieber
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.TrieLibrary
{
    /// <summary>
    /// A node of a trie for storing strings made up of lower-case English letters.
    /// </summary>
    public class TrieWithOneChild : ITrie
    {
        /// <summary>
        /// Whether or not the trie contains an empty string.
        /// </summary>
        private bool _containsEmptyString;

        /// <summary>
        /// The child of the trie.
        /// </summary>
        private ITrie _onlyChild;

        /// <summary>
        /// The label of the child.
        /// </summary>
        private char _childLabel;

        public TrieWithOneChild(string s, bool b)
        {
            if (s == "" || s[0] < 'a' || s[0] > 'z')
            {
                throw new ArgumentException();
            }
            _containsEmptyString = b;
            _childLabel = s[0];
            _onlyChild = new TrieWithNoChildren().Add(s.Substring(1));
        }

        /// <summary>
        /// Adds the given string to the trie rooted at this node.
        /// </summary>
        /// <param name="s">The string to add.</param>
        public ITrie Add(string s)
        {
            if (s == "")
            {
                _containsEmptyString = true;
                return this;
            }
            else if (s[0] == _childLabel)
            {
                _onlyChild = _onlyChild.Add(s.Substring(1));
                return this;
            }
            else
            {
                return new TrieWithManyChildren(s, _containsEmptyString, _childLabel, _onlyChild);
            }
        }

        /// <summary>
        /// Gets whether the trie rooted at this node contains the given string.
        /// </summary>
        /// <param name="s">The string to look up.</param>
        /// <returns>Whether the trie rooted at this node contains s.</returns>
        public bool Contains(string s)
        {
            if (s == "")
            {
                return _containsEmptyString;
            }
            else if (s[0] == _childLabel)
            {
                return _onlyChild.Contains(s.Substring(1));
            }
            else
            {
                return false;
            }
        }
    }
}
