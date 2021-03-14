using Leopotam.Ecs;
using UnityEngine;

namespace TicToe
{
    internal class CreateTackenViewSystem : IEcsRunSystem
    {
        private EcsFilter<Taken, CellViewRef>.Exclude<TakenRef> _filter;
        private Configuration _configuration;

        public void Run()
        {
            foreach (var index in _filter)
            {
                var position = _filter.Get2(index).Value.transform.position;
                var takenType = _filter.Get1(index).Value;
                
                SignView signView = null;
                switch (takenType)
                {
                    case SignType.Zero:
                        signView = _configuration.ZeroView;
                        break;
                    case SignType.Cross:
                        signView = _configuration.CrossView;
                        break;
                }

                var instance = Object.Instantiate(signView, position, Quaternion.identity);
                _filter.GetEntity(index).Get<TakenRef>().Value = instance;
            }
        }
    }
}