using DanPie.Framework.UnityExtensions;
using UnityEngine;

namespace DanPie.Framework.MeshTools
{
    public class GameObjectBoundsCalculator
    {
        public Bounds GetBounds(GameObject meshesContainer, bool useSharedMesh = false)
        {
            MeshFilter[] filters = meshesContainer.GetComponentsInChildren<MeshFilter>();
            Bounds result = new Bounds();
            
            if (filters.Length == 0)
            {
                result.center = meshesContainer.transform.position;
                return result;
            }
            Mesh mesh = useSharedMesh ? filters[0].sharedMesh : filters[0].mesh;
            result = GetBounds(mesh.vertices, filters[0].transform);

            for (int i = 1; i < filters.Length; i++)
            {
                mesh = useSharedMesh ? filters[i].sharedMesh : filters[i].mesh;
                Bounds meshBounds = GetBounds(mesh.vertices, filters[i].transform);
                result.max = result.max.Merge(meshBounds.max, (a, b) => Mathf.Max(a, b));
                result.min = result.min.Merge(meshBounds.min, (a, b) => Mathf.Min(a, b));
            }

            return result;
        }

        public Bounds GetBounds(Vector3[] vertices, Transform transform)
        {
            if (vertices.Length == 0)
            {
                return new Bounds() { center = transform.position };
            }

            Vector3 verticle = transform.rotation * vertices[0];
            Vector3 min = verticle;
            Vector3 max = verticle;

            for (int i = 1; i < vertices.Length; i++)
            {
                verticle = transform.rotation * vertices[i];
                min = min.Merge(verticle, (a, b) => Mathf.Min(a, b));
                max = max.Merge(verticle, (a, b) => Mathf.Max(a, b));
            }

            Bounds result = new Bounds() { min = min, max = max };
            var size = result.size;
            var center = result.center;
            size.Scale(transform.lossyScale);
            center.Scale(transform.lossyScale);
            result.size = size;
            result.center = center;
            result.center += transform.position;
            return result;
        }
    }
}
