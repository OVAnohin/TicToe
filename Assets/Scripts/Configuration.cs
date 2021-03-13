using System.Collections;
using System.Collections.Generic;
using TicToe;
using UnityEngine;

public class Configuration : MonoBehaviour
{
    [SerializeField] private ConfigurationData _configuration;

    public int LevelWidth => _configuration.LevelWidth;
    public int LevelHeight => _configuration.LevelHeight;
    public int ChainLenght => _configuration.ChainLenght;
    public CellView CellView => _configuration.CellView;
    public Vector2 Offcet => _configuration.Offcet;
}
