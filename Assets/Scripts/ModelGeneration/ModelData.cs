using UnityEngine;

public class ModelData
{
    private const int COLLIDER_LAYER_COUNT = 1;
    private const int SKIN_LAYER_COUNT = 1;

    public MeshData ColliderMesh { get; }
    public MeshData SkinMesh { get; }
    public SkinData Skin { get; }

    public ModelData()
    {
        Skin = new SkinData();
        SkinMesh = new MeshData(SKIN_LAYER_COUNT);
        ColliderMesh = new MeshData(COLLIDER_LAYER_COUNT);
    }

    ~ModelData()
    {
        Clear();
    }

    public void Clear()
    {
        SkinMesh.Clear();
        ColliderMesh.Clear();
        Skin.Clear();
    }

    public void Add(ModelData objectData, Vector3 shift)
    {
        SkinMesh.Add(objectData.SkinMesh, shift);
        ColliderMesh.Add(objectData.ColliderMesh, shift);
        Skin.Add(objectData.Skin);
    }

    public void Add(ModelData objectData)
    {
        Add(objectData, Vector3.zero);
    }
}