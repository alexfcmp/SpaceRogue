using UnityEditor;
using UnityEngine;

namespace Gameplay.Space.Generator
{
    [CustomEditor(typeof(DebugLevelGeneratorView))]
    public sealed class DebugLevelGeneratorViewEditor : Editor
    {
        private DebugLevelGenerator _debugLevelGenerator;

        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            if (GUILayout.Button("Generate"))
            {
                _debugLevelGenerator = new((DebugLevelGeneratorView)target);
                _debugLevelGenerator.Generate();
            }

            if (GUILayout.Button("Clear"))
            {
                _debugLevelGenerator = new((DebugLevelGeneratorView)target);
                _debugLevelGenerator.ClearTileMaps();
            }
        }
    } 
}
