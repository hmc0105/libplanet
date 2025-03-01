using System;
using System.Security.Cryptography;
#pragma warning disable S1128
using Libplanet.Blocks;
#pragma warning restore S1128

namespace Libplanet.Blockchain
{
    /// <summary>
    /// The exception that is thrown when a <see cref="BlockChain{T}"/> have
    /// not calculated the complete states for all blocks, but an operation
    /// that needs some lacked states is requested.
    /// </summary>
    public class IncompleteBlockStatesException : Exception
    {
        /// <summary>
        /// Creates a new <see cref="IncompleteBlockStatesException"/> object.
        /// </summary>
        /// <param name="blockHash">Specifies <see cref="BlockHash"/>.
        /// It is automatically included to the <see cref="Exception.Message"/>
        /// string.</param>
        /// <param name="message">Specifies the <see cref="Exception.Message"/>.
        /// </param>
        public IncompleteBlockStatesException(
            HashDigest<SHA256> blockHash,
            string message = null)
            : base(
                message is null
                    ? $"{blockHash} lacks states"
                    : $"{message}\nBlock that lacks states: {blockHash}")
        {
            BlockHash = blockHash;
        }

        /// <summary>
        /// The <see cref="Block{T}.Hash"/> of <see cref="Block{T}"/> that
        /// a <see cref="BlockChain{T}"/> lacks the states.
        /// </summary>
        public HashDigest<SHA256> BlockHash { get; }
    }
}
