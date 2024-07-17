using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;

namespace TopDownShoot
{
    public class AuroBakeNavMesh : MonoBehaviour
    {
        private void Awake()
        {
            var surfaces = GetComponents<NavMeshSurface>();
            foreach (var surface in surfaces)
            {
                surface.BuildNavMesh();
            }
        }
    }
}
