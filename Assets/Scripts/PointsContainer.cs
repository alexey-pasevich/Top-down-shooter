using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace TopDownShoot
{
    public class PointsContainer : MonoBehaviour
    {
        [SerializeField] private List<Transform> m_points;


        public List<Vector3> GetPoints()
        {
            var list = new List<Vector3>();
            foreach (var p in m_points) 
            {
                list.Add(p.position);
            }
            return list;
        }
    }
}
