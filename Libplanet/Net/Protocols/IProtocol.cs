using System;
using System.Collections.Immutable;
using System.Threading;
using System.Threading.Tasks;
using Libplanet.Net.Messages;

namespace Libplanet.Net.Protocols
{
    internal interface IProtocol
    {
        ImmutableList<BoundPeer> Peers { get; }

        ImmutableList<BoundPeer> PeersToBroadcast { get; }

        Task BootstrapAsync(
            ImmutableList<BoundPeer> bootstrapPeers,
            TimeSpan? pingSeedTimeout,
            TimeSpan? findPeerTimeout,
            CancellationToken cancellationToken);

        Task RefreshTableAsync(TimeSpan maxAge, CancellationToken cancellationToken);

        Task RebuildConnectionAsync(CancellationToken cancellationToken);

        Task CheckReplacementCacheAsync(CancellationToken cancellationToken);

        void ReceiveMessage(Message message);

        string Trace();
    }
}
