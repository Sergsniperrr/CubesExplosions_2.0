using UnityEngine;

[RequireComponent(typeof(BoxCollider),typeof(Renderer))]
public class Cube : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;
    [SerializeField] private Spawn _spawn;
    [SerializeField] private float _separationChance;

    private Explosion _explosion = new Explosion();
    private Renderer _renderer;

    public Rigidbody RigitBody => GetComponent<Rigidbody>();

    private void Start()
    {
        SetRandomColor();
        ReduceChanceOfSeparation();
    }

    private void OnMouseDown()
    {
        if (CanSeparation())
            _explosion.ExplodeLocal(_spawn.CloneCubes(_cubePrefab), transform.position);
        else
            _explosion.ExplodeGlobal(transform.localScale.x, transform.position);

        Destroy(gameObject);
    }

    private bool CanSeparation()
    {
        float maxChance = 100f;
        float initialChance = maxChance;

        if (_separationChance == 0)
            _separationChance = initialChance;

        return Random.Range(0, maxChance) < _separationChance;
    }

    private void ReduceChanceOfSeparation()
    {
        int halfDevider = 2;

        _separationChance /= halfDevider;
    }

    private void SetRandomColor()
    {
        _renderer = GetComponent<Renderer>();
        _renderer.material.color = Random.ColorHSV();
    }
}
