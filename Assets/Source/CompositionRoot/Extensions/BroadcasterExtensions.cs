using Model.Messaging;
using UnityEngine;
using View.Sources.View.Broadcasters;

namespace CompositionRoot.Extensions
{
    public static class BroadcasterExtensions
    {
        public static GameObject InitializeAs<TTickable>(this TickBroadcaster broadcaster, TTickable tickable, out TTickable instance)
            where TTickable : ITickable
        {
            instance = tickable;    
            return broadcaster.Initialize(tickable); ;
        }
    }
}
