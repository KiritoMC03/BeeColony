using System;
using UnityEngine;
using UnityEngine.Tilemaps;
using Utils;

public class TilemapGenerator : MonoBehaviourBase
{
    public static TilemapGenerator Instance;
    
    [SerializeField] private Tilemap Tilemap;
    [SerializeField] private bool FromCentre = false;
    [Header("Only even.")]
    [SerializeField] private int Width = 15;
    [SerializeField] private int Height = 15;
    [SerializeField] private Tile DarkGrass;
    [SerializeField] private Tile LightGrass;
    
    private int _startHeightPosition;
    private int _startWidthPosition;
    private int _calculatedHeight;
    private int _calculatedWidth;

    private void Awake()
    {
        Instance = this;
    }

    private void OnValidate()
    {
        Instance = this;
    }

    private void Start()
    {
        Generate();
    }

    public void Generate()
    {
        Tilemap.ClearAllTiles();
        var isDark = true;
        var isWidthEven = (Width % 2 == 0);
        var tilePosition = new Vector3Int();
        
        CorrectPosition();
        for (var i = _startHeightPosition; i < _calculatedHeight; i++)
        {
            for (var j = _startWidthPosition; j < _calculatedWidth; j++)
            {
                tilePosition.Set(j, i, 0);
                Tilemap.SetTile(tilePosition, isDark ? DarkGrass : LightGrass);
                isDark.Invert();
            }
            isDark.Invert();
        }
    }

    private void CorrectPosition()
    {
        if (FromCentre)
        {
            _calculatedHeight = Mathf.CeilToInt(Height / 2f);
            _calculatedWidth = Mathf.CeilToInt(Width / 2f);
            _startHeightPosition = -_calculatedHeight;
            _startWidthPosition = -_calculatedWidth;
        }
    }
}
