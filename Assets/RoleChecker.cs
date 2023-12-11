using UnityEngine;

public class RoleChecker : MonoBehaviour
{
    public static RoleChecker Instance;
    public string role;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
