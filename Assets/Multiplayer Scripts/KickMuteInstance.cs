using UnityEngine;

public class KickMuteInstance : MonoBehaviour
{
    public GameObject kickMutePrefab;

    private static bool created = false;

    void Awake()
    {
        if (!created)
        {
            // Instantiate the kickMutePrefab
            GameObject kickMuteObject = Instantiate(kickMutePrefab);

            // Make it DontDestroyOnLoad
            DontDestroyOnLoad(kickMuteObject);

            // Set created to true to indicate that the instance has been created
            created = true;
        }
        else
        {
            // If additional instances are created, destroy them
            Destroy(gameObject);
        }
    }
}
