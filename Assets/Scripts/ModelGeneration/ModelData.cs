using UnityEngine;

public class ModelData
{
    private const int COLLIDER_LAYER_COUNT = 1;
    private const int SKIN_LAYER_COUNT = 1;

    private readonly MeshData _colliderMesh;
    private readonly MeshData _skinMesh;
    private readonly SkinData _skin;

    public ModelData()
    {
        _skin = new SkinData();
        _skinMesh = new MeshData(SKIN_LAYER_COUNT);
        _colliderMesh = new MeshData(COLLIDER_LAYER_COUNT);
    }

    ~ModelData()
    {
        Clear();
    }

    public void Clear()
    {
        _skinMesh.Clear();
        _colliderMesh.Clear();
        _skin.Clear();
    }

    public void Add(ModelData objectData, Vector3 shift)
    {
        _skinMesh.Add(objectData._skinMesh, shift);
        _colliderMesh.Add(objectData._colliderMesh, shift);
        _skin.Add(objectData._skin);
    }

    public void Add(ModelData objectData)
    {
        Add(objectData, Vector3.zero);
    }
}