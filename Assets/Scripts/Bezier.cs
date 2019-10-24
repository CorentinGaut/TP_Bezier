using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bezier : MonoBehaviour
{
    public int nbPoints = 20;
    public GameObject sphere;
    public Material r;

    public List<GameObject> pointsControles = new List<GameObject>();
    List<GameObject> listPts = new List<GameObject>();
    int select = 0;
    // Start is called before the first frame update
    void Start()
    {
        CreateBezierCurve();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            pointsControles[select].GetComponent<Material>().color = Color.green;
            select = 0;
            resetColor(select);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            pointsControles[select].GetComponent<Material>().color = Color.green;
            
            select = 1;
            resetColor(select);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            pointsControles[select].GetComponent<Material>().color = Color.green;
            select = 2;
            resetColor(select);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            pointsControles[select].GetComponent<Material>().color = Color.green;
            select = 3;
            resetColor(select);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            foreach(GameObject g in listPts)
            {
                Destroy(g);
            }
            pointsControles[select].transform.position += Vector3.left * Time.deltaTime;
            CreateBezierCurve();
        }
        if (Input.GetKey(KeyCode.D))
        {
            foreach (GameObject g in listPts)
            {
                Destroy(g);
            }
            pointsControles[select].transform.position += Vector3.right * Time.deltaTime;
            CreateBezierCurve();
        }
        if (Input.GetKey(KeyCode.Z))
        {
            foreach (GameObject g in listPts)
            {
                Destroy(g);
            }
            pointsControles[select].transform.position += Vector3.up * Time.deltaTime;
            CreateBezierCurve();
        }
        if (Input.GetKey(KeyCode.S))
        {
            foreach (GameObject g in listPts)
            {
                Destroy(g);
            }
            pointsControles[select].transform.position += Vector3.down * Time.deltaTime;
            CreateBezierCurve();
        }
    }

    void CreateBezierCurve()
    {
        for (int i = 0; i < nbPoints; i++)
        {
            float nb = i / ((float)nbPoints - 1f);
            Vector3 pos = courbeBezier(nb, pointsControles.Count);
            GameObject s = Instantiate(sphere, pos, Quaternion.identity);
            listPts.Add(s);
        }
    }

    Vector3 courbeBezier(float u, float n)
    {
        Vector3 newPoints =  Vector3.zero;
        for (int i = 0; i < n; i++)
        {
            newPoints += (PolynomeBeirnstein(u, i, n-1) * pointsControles[i].transform.position);
        }
        return newPoints;
    }


    float PolynomeBeirnstein(float t, int i, float n)
    {
        return (Factoriel(n) / (Factoriel(i) * Factoriel(n - i)) * Mathf.Pow(t, i) * Mathf.Pow(1 - t, n - i));
    }


    static float Factoriel(float n)
    {
        
        return n > 1 ? n * Factoriel(n - 1) : 1;

    }

    void resetColor(int j)
    {
        for (int i = 0; i < pointsControles.Count; i++)
        {
            if (i!= j)
            {
                pointsControles[i].GetComponent<Material>().color = Color.red;
            }
        }
    }
}
