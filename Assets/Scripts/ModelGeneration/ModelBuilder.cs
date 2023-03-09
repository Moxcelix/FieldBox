using UnityEngine;

[RequireComponent(typeof(MeshCollider))]
[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class ModelBuilder : MonoBehaviour
{
    private MeshFilter _meshFilter;
    private MeshCollider _meshCollider;

    private void Awake()
    {
        _meshCollider = GetComponent<MeshCollider>();
        _meshFilter = GetComponent<MeshFilter>();
    }

    public void UpdateModel(ModelData modelData)
    {
        var skinMesh = new Mesh();
        var colliderMesh = new Mesh();

        var uvChannel = 0;
        var colliderLayer = 0;

        skinMesh.SetVertices(modelData.SkinMesh.Vertices);
        skinMesh.SetColors(modelData.Skin.Colors);
        skinMesh.SetUVs(uvChannel, modelData.Skin.UVs);

        for (int i = 0; i < modelData.SkinMesh.Triangles.Length; i++)
            skinMesh.SetTriangles(modelData.SkinMesh.Triangles[i], i);

        colliderMesh.SetVertices(modelData.ColliderMesh.Vertices);
        colliderMesh.SetTriangles(modelData.ColliderMesh.Triangles[colliderLayer], colliderLayer);

        skinMesh.RecalculateNormals();
        colliderMesh.RecalculateNormals();

        _meshCollider.sharedMesh = colliderMesh;
        _meshFilter.sharedMesh = skinMesh;
    }
}
