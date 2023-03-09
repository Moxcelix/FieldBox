using UnityEngine;

public class ModelData
{
    public int ColliderLayerCount { get; } = 1;
    public int SkinLayerCount { get; } = 1;

    public MeshData ColliderMesh { get; }
    public MeshData SkinMesh { get; }
    public SkinData Skin { get; }

    public ModelData()
    {
        Skin = new SkinData();
        SkinMesh = new MeshData(SkinLayerCount);
        ColliderMesh = new MeshData(ColliderLayerCount);
    }

    public ModelData(int colliderLayerCount, int skinLayerCount) : base()
    {
        ColliderLayerCount = colliderLayerCount;
        SkinLayerCount = skinLayerCount;
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

    public void Add(MeshData colliderMesh, MeshData skinMesh, SkinData skin, Vector3 shift)
    {
        SkinMesh.Add(skinMesh, shift);
        ColliderMesh.Add(colliderMesh, shift);
        Skin.Add(skin);
    }

    public void Add(ModelData objectData)
    {
        Add(objectData, Vector3.zero);
    }

    public void Add(MeshData colliderMesh, MeshData skinMesh, SkinData skin)
    {
        Add(colliderMesh, skinMesh, skin, Vector3.zero);
    }
}