using Leopotam.Ecs;
using System.Collections.Generic;
using UnityEngine;

namespace TicToe
{
    public static class GameExtention
    {
        public static int GetLongestChain(this Dictionary<Vector2Int, EcsEntity> cells, Vector2Int positon)
        {
            var startEntity = cells[positon];
            if (!startEntity.Has<Taken>())
                return 0;

            var startType = startEntity.Ref<Taken>().Unref().Value;
            var currentLehgth = 1;
            {
                var direction = new Vector2Int(-1, 0);
                var currentPosition = positon + direction;

                while (cells.TryGetValue(currentPosition, out var entity))
                {
                    if (!entity.Has<Taken>())
                    {
                        break;
                    }

                    var type = entity.Ref<Taken>().Unref().Value;
                    if (startType != type)
                    {
                        break;
                    }

                    currentLehgth++;
                    currentPosition += direction;

                }

                direction = new Vector2Int(1, 0);
                currentPosition = positon + direction;

                while (cells.TryGetValue(currentPosition, out var entity))
                {
                    if (!entity.Has<Taken>())
                    {
                        break;
                    }

                    var type = entity.Ref<Taken>().Unref().Value;
                    if (startType != type)
                    {
                        break;
                    }

                    currentLehgth++;
                    currentPosition += direction;
                }
            }
            return currentLehgth;
        }
    }
}