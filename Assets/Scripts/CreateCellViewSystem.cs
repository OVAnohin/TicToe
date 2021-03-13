using Leopotam.Ecs;
using UnityEngine;

namespace TicToe
{
    internal class CreateCellViewSystem : IEcsRunSystem
    {
        private EcsFilter<Cell, Position>.Exclude<CellViewRef> _filter;
        private Configuration _configuration;
        private Configuration configuration;

        public CreateCellViewSystem(Configuration configuration)
        {
            _configuration = configuration;
        }

        public void Run()
        {
            foreach (var index in _filter)
            {
                ref var position = ref _filter.Get2(index);

                var cellView = Object.Instantiate(_configuration.CellView);

                cellView.transform.position = new Vector3(position.value.x + _configuration.Offcet.x * position.value.x, position.value.y + _configuration.Offcet.y * position.value.y);

                _filter.GetEntity(index).Get<CellViewRef>().value = cellView;
            }
        }
    }
}