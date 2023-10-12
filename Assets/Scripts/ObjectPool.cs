using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] private int _capacity;

    private Camera _camera;
    private float _desablePositionX;
    private List<GameObject> _pool;

    protected void Initialize(GameObject prefab)
    {
        _camera = Camera.main;
        _desablePositionX = _camera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        _pool = new List<GameObject>();

        for (int i = 0; i < _capacity; i++)
        {
            GameObject spawned = Instantiate(prefab, _container.transform);
            spawned.SetActive(false);

            _pool.Add(spawned);
        }
    }

    protected bool TryGetObject(out GameObject result)
    {
        result = _pool.FirstOrDefault(gameObject => gameObject.activeSelf == false);

        return result != null;
    }

    protected void DisableOffscreenObjects()
    {
        foreach (var item in _pool)
        {
            if (item.activeSelf)
            {
                if (item.transform.position.x < _desablePositionX)
                {
                    item.SetActive(false);
                }
            }            
        }
    }

    public void ResetPool()
    {
        foreach (var item in _pool)
        {
            item.SetActive(false);
        }
    }
}
