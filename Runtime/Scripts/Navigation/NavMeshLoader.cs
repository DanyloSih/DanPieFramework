using UnityEngine;
using UnityEngine.AI;
using NavMeshBuilder = UnityEngine.AI.NavMeshBuilder;
using NavMesh = UnityEngine.AI.NavMesh;

namespace DanPie.Framework.Navigation
{
    public class NavMeshLoader : MonoBehaviour
    {
        public NavMeshData m_NavMeshData;
        private NavMeshDataInstance m_NavMeshInstance;

        void OnEnable()
        {
            m_NavMeshInstance = NavMesh.AddNavMeshData(m_NavMeshData);
        }

        void OnDisable()
        {
            NavMesh.RemoveNavMeshData(m_NavMeshInstance);
        }
    }

}
