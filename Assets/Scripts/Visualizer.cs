using UnityEngine;

public class Visualizer : MonoBehaviour
{
    [SerializeField] private GameObject objectToSpawn;
    [SerializeField] private Material objectMaterial;
    [SerializeField] private int radius;
    [Space] [SerializeField] private int maxSize;
    
    private int _numberOfObjects;
    private Transform[] _objects;
    
    void Start()
    {
        _numberOfObjects = SampleCreator.Samples.Length;
        _objects = new Transform[_numberOfObjects];

        SpawnObjects();
    }
    
    private void Update()
    {
        int i = 0;
        foreach (var obj in _objects)
        {
            obj.localScale = new Vector3(1, Mathf.Min(SampleCreator.Samples[i] * 10000 + 2, maxSize), 1);
            i++;
        }
    }

    private void SpawnObjects()
    {
        int distanceInDegrees = 360 / _numberOfObjects;
        for (int i = 0; i < _numberOfObjects; i++)
        {
            float t = distanceInDegrees * i * Mathf.Deg2Rad;
            Vector3 pos = new Vector3(Mathf.Cos(t) * radius, transform.position.y, Mathf.Sin(t) * radius);
            Transform newObj = Instantiate(objectToSpawn, pos, Quaternion.identity, transform).transform;
            newObj.position = pos;
            newObj.LookAt(transform);
            _objects[i] = newObj;
        }
    }

}
