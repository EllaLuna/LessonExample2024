using UnityEngine;

public class InstantiateManagers : MonoBehaviour
{
    [SerializeField] GameObject managersPrefab;

    void Awake()
    {
        var managers = FindFirstObjectByType<Managers>();
        if (managers == null)
        {
            Instantiate(managersPrefab);
        }
        Destroy(gameObject);
    }
}
