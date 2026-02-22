using UnityEngine;

public class Spin : MonoBehaviour
{
    void Update()
    {
        Vector3 temp = transform.eulerAngles;
        temp.y = Random.Range(0f, 365f); //randomly rotates a pivot point for the berry spawners, so the berries will spawn randomly along a fixed radius around the tree
        transform.eulerAngles = temp;
    }
}
