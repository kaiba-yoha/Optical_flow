using UnityEngine;
using System.Collections.Generic;

public class SphereGenerator : MonoBehaviour
{
    public GameObject spherePrefab;
    public int sphereCount = 100;
    public float spawnDistance = 50f;
    public float spawnRange = 10f;
    public float speed = 5f;

    private List<GameObject> spheres = new List<GameObject>();
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
        GenerateSpheres();
    }

    void Update()
    {
        MoveSpheres();
    }

    void GenerateSpheres()
    {
        for (int i = 0; i < sphereCount; i++)
        {
            Vector3 randomPosition = mainCamera.transform.position + mainCamera.transform.forward * spawnDistance + Random.insideUnitSphere * spawnRange;
            randomPosition -= mainCamera.transform.forward * Random.value * spawnDistance;
            GameObject sphere = Instantiate(spherePrefab);
            //Instantiate(spherePrefab, randomPosition, Quaternion.identity);
            sphere.transform.position = randomPosition;
            sphere.transform.rotation = Quaternion.identity;
            sphere.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            sphere.transform.SetParent(mainCamera.transform, true);
            spheres.Add(sphere);
        }
    }

    void MoveSpheres()
    {
        Vector3 cameraForward = mainCamera.transform.forward;


        foreach (GameObject sphere in spheres)
        {
            sphere.transform.position += -cameraForward * speed * Time.deltaTime;

            //カメラの後ろに来たら
            if (mainCamera.transform.InverseTransformPoint(sphere.transform.position).z < 0)
            {
                Vector3 newPosition = cameraForward * spawnDistance;
                sphere.transform.position += newPosition;
            }
        }
    }
}