using Scriptables.Enemy;
using Scriptables.Space;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Gameplay.Space.Generator
{
    public sealed class LevelGenerator : SpaceGenerator
    {
        private readonly Tilemap _borderTilemap;
        private readonly Tilemap _borderMaskTilemap;
        private readonly Tilemap _nebulaTilemap;
        private readonly Tilemap _nebulaMaskTilemap;

        public LevelGenerator(SpaceView spaceView,
                              SpaceConfig spaceConfig,
                              StarSpawnConfig starSpawnConfig,
                              EnemySpawnConfig enemySpawnConfig) 
            : base(spaceView, spaceConfig, starSpawnConfig, enemySpawnConfig)
        {
            _borderTilemap = spaceView.BorderTilemap;
            _borderMaskTilemap = spaceView.BorderMaskTilemap;
            _nebulaTilemap = spaceView.NebulaTilemap;
            _nebulaMaskTilemap = spaceView.NebulaMaskTilemap;
        }

        protected override void Draw()
        {
            DrawLayer(_borderMap, _borderTilemap, _borderTileBase, CellType.Border);
            DrawLayer(_borderMap, _borderMaskTilemap, _borderMaskTileBase, CellType.Border);
            DrawLayer(_nebulaMap, _nebulaTilemap, _nebulaTileBase, CellType.Obstacle);
            DrawLayer(_nebulaMap, _nebulaMaskTilemap, _nebulaMaskTileBase, CellType.Obstacle);
        }

        public List<Vector3> GetSpawnPoints(CellType cellType)
        {
            if (_spaceObjectsMap == null)
            {
                return new();
            }

            var spawnPoints = new List<Vector3>();

            for (int x = 0; x < _spaceObjectsMap.GetLength(0); x++)
            {
                for (int y = 0; y < _spaceObjectsMap.GetLength(1); y++)
                {
                    var positionTile = new Vector3Int(-_spaceObjectsMap.GetLength(0) / 2 + x,
                        -_spaceObjectsMap.GetLength(1) / 2 + y, 0);

                    if (_spaceObjectsMap[x, y] == (int)cellType)
                    {
                        spawnPoints.Add(_nebulaTilemap.GetCellCenterWorld(positionTile));
                    }
                }
            }

            return spawnPoints;
        }

        public Vector3 GetPlayerSpawnPoint()
        {
            if (_spaceObjectsMap == null)
            {
                return new();
            }

            for (int x = 0; x < _spaceObjectsMap.GetLength(0); x++)
            {
                for (int y = 0; y < _spaceObjectsMap.GetLength(1); y++)
                {
                    var positionTile = new Vector3Int(-_spaceObjectsMap.GetLength(0) / 2 + x,
                        -_spaceObjectsMap.GetLength(1) / 2 + y, 0);

                    if (_spaceObjectsMap[x, y] == (int)CellType.Player)
                    {
                        return _nebulaTilemap.GetCellCenterWorld(positionTile);
                    }
                }
            }

            Debug.LogWarning("Player: zero position!");
            return new();
        }

        private void DrawLayer(int[,] map, Tilemap tilemap, TileBase tileBase, CellType cellType)
        {
            if (map == null)
            {
                return;
            }

            for (int x = 0; x < map.GetLength(0); x++)
            {
                for (int y = 0; y < map.GetLength(1); y++)
                {
                    var positionTile = new Vector3Int(-map.GetLength(0) / 2 + x, -map.GetLength(1) / 2 + y, 0);

                    if (map[x, y] == (int)cellType)
                    {
                        tilemap.SetTile(positionTile, tileBase);
                    }
                }
            }
        }
    }
}