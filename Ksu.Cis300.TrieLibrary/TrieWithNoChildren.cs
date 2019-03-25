/* TrieWithNoChildren.cs
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
    public class TrieWithNoChildren : ITrie
    {
        /// <summary>
        /// Whether or not the trie contains an empty string.
        /// </summary>
        private bool _containsEmptyString = false;

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
            else
            {
                return new TrieWithOneChild(s, _containsEmptyString);
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
            else
            {
                return false;
            }
        }
    }
}
