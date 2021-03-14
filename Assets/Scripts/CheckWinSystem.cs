using Leopotam.Ecs;

namespace TicToe
{
    internal class CheckWinSystem : IEcsRunSystem
    {
        private EcsFilter<Position, Taken, CheckWinEvent> _filter;
        private GameState _gameState;
        private Configuration _configuration;

        public void Run()
        {
            foreach (var index in _filter)
            {
                ref var position = ref _filter.Get1(index);

                var chainLength = _gameState.Cells.GetLongestChain(position.Value);
                if (chainLength >= _configuration.ChainLenght)
                {
                    _filter.GetEntity(index).Get<Winner>();
                }
            }
        }
    }
}