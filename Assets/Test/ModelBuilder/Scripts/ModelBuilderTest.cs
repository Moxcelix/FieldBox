using UnityEngine;

public class ModelBuilderTest : MonoBehaviour
{
    [SerializeField] ModelBuilder _modelBuilder;

    private ModelData _modelData;

    private void Start()
    {
        _modelData = new ModelData();

        UpdateMesh();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            UpdateMesh();
    }

    private void UpdateMesh() 
    {
        var meshData = new MeshData(_modelData.ColliderLayerCount);
        var skinData = new SkinData();

        meshData.AddQuad( new(1, 0, 0),new(0, 0, 0), new(1, 0, 1), new(0, 0, 1));

        skinData.Add(new(0, 0), Color.red);
        skinData.Add(new(1, 0), Color.blue);
        skinData.Add(new(0, 1), Color.green);
        skinData.Add(new(1, 1), Color.yellow);

        _modelData.Clear();
        _modelData.Add(meshData, meshData, skinData);

        _modelBuilder.UpdateModel(_modelData);
    }
}
