using Scriptables.Enemy;
using Scriptables.Space;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Gameplay.Space.Generator
{
    public sealed class DebugLevelGeneratorView : MonoBehaviour
    {
        [field: SerializeField, Header("Settings")] public SpaceView SpaceView { get; private set; }
        [field: SerializeField] public SpaceConfig SpaceConfig { get; private set; }
        [field: SerializeField] public StarSpawnConfig StarSpawnConfig { get; private set; }
        [field: SerializeField] public EnemySpawnConfig EnemySpawnConfig{ get; private set; }

        [field: SerializeField, Header("Stars")] public Tilemap StarTilemap { get; private set; }
        [field: SerializeField ] public TileBase StarTileBase { get; private set; }
    }
}