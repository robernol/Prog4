using JetBrains.Annotations;
using NUnit.Framework;
using System.Collections;
using UnityEditor;
using UnityEngine;

public class BerrySpawner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject berry1, berry2, berry3, berry4, berry5;
    public GameObject[] berryList;
    // Update is called once per frame

    private void Start()
    {
        berryList = new GameObject[5] { berry1, berry2, berry3, berry4, berry5 };
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(berryList[Random.Range(0, 5)], transform.position, transform.rotation);
        }
    }
}
