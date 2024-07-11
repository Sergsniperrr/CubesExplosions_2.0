using UnityEngine;

public class Spawn : MonoBehaviour
{
    private readonly int _minNumberOfCubes = 2;
    private readonly int _maxNumberOfCubes = 6;

    public Cube[] CloneCubes(Cube sampleCube)
    {
        int numberOfCubes = Random.Range(_minNumberOfCubes, _maxNumberOfCubes);
        float radius = sampleCube.transform.localScale.x;
        Cube[] cubes = new Cube[numberOfCubes];
        int doubler = 2;

        ReduceSize(sampleCube);

        for (int i = 0; i < numberOfCubes; i++)
        {
            float angle = i * Mathf.PI * doubler / numberOfCubes;
            float x = Mathf.Cos(angle) * radius;
            float z = Mathf.Sin(angle) * radius;
            Vector3 position = sampleCube.transform.position + new Vector3(x, 0, z);
            float angleDegrees = -angle * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.Euler(0, angleDegrees, 0);
            cubes[i] = Instantiate(sampleCube, position, rotation);
        }

        return cubes;
    }

    private void ReduceSize(Cube cube)
    {
        int halfDevider = 2;

        cube.transform.localScale /= halfDevider;
    }
}
