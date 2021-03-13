using UnityEngine;

namespace TicToe
{
    [CreateAssetMenu]
    public class Configuration : ScriptableObject
    {
        [SerializeField] private int _levelWidth;
        [SerializeField] private int _levelHeight;
        [SerializeField] private int _chainLenght;
        [SerializeField] private CellView _cellView;
        [SerializeField] private Vector2 _offcet;


        public int LevelWidth => _levelWidth;
        public int LevelHeight => _levelHeight;
        public int ChainLenght => _chainLenght;
        public CellView CellView => _cellView;
        public Vector2 Offcet => _offcet;
    }
}