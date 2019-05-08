using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public Transform[] objPrefabs;

    private float nextObjTime = 0.0f;
    private float spawnRate = 1.5f;

    void Update()
    {
        if (nextObjTime < Time.time)
        {
            SpawnObj();
            nextObjTime = Time.time + spawnRate;
        }
    }

    void SpawnObj()
    {
        KinectManager manager = KinectManager.Instance;

        if (objPrefabs.Length != 0 && manager && manager.IsInitialized() && manager.IsUserDetected())
        {
            uint userId = manager.GetPlayer1ID();
            Vector3 posUser = manager.GetUserPosition(userId);

            float addXPos = Random.Range(-10f, 10f);
            Vector3 spawnPos = new Vector3(addXPos, 10f, posUser.z);
            Transform objectToSpawn = objPrefabs[objPrefabs.Length-1];

            Transform objTransform = Instantiate(objectToSpawn, spawnPos, Quaternion.identity) as Transform;
            objTransform.parent = transform;
        }
    }
}
