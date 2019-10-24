using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HermiteCubique : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject sphere;
    void Start()
    {
        Hermite(new Vector3(0, 0), new Vector3(2, 0), new Vector3(1, 1), new Vector3(1, -1), 10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Hermite(Vector3 p0, Vector3 p1, Vector3 v0, Vector3 v1, int nbPoints)
    {
        for (float u = 0; u < nbPoints; u++)
        {
            float nb = u / (nbPoints-1);
            Vector3 newPoints = F1(nb) * p0 + F2(nb) * p1 + F3(nb) * v0 + F4(nb) * v1;
            Instantiate(sphere, newPoints, Quaternion.identity);
        }
    }

    float F1(float u)
    {
        return 2 * Mathf.Pow(u, 3) - 3 * Mathf.Pow(u, 2) + 1;
    }
    float F2(float u)
    {
        return - (2 * Mathf.Pow(u, 3)) + 3 * Mathf.Pow(u, 2);
    }
    float F3(float u)
    {
        return Mathf.Pow(u, 3) - 2 * Mathf.Pow(u, 2);
    }
    float F4(float u)
    {
        return Mathf.Pow(u, 3) - Mathf.Pow(u, 2);
    }
}
