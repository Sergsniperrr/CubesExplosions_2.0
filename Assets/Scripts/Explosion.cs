using UnityEngine;

public class Explosion
{
    private float _force;
    private float _radius;

    public void ExplodeLocal(Cube[] cubes, Vector3 explosionCenter)
    {
        if (cubes.Length == 0)
            return;

        _force = 5000f;
        _radius = 10f;

        foreach (Cube cube in cubes)
            cube.RigitBody.AddExplosionForce(_force, explosionCenter, _radius);
    }

    public void ExplodeGlobal(float cubeSize, Vector3 explosionCenter)
    {
        float maxForce = 10000f;
        float maxRadius = 50f;
        _force = maxForce / Mathf.Sqrt(cubeSize);
        _radius = maxRadius / Mathf.Sqrt(cubeSize);

        Collider[] overlappedColliders = Physics.OverlapSphere(explosionCenter, _radius);

        for (int j = 0; j < overlappedColliders.Length; j++)
        {
            Rigidbody rigidbody = overlappedColliders[j].attachedRigidbody;

            if (rigidbody)
            {
                rigidbody.AddExplosionForce(_force, explosionCenter, _radius);
            }
        }
    }
}
