using UnityEngine;

public class Spin : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame
    void Update()
    {
        Vector3 temp = transform.eulerAngles;
        temp.y = Random.Range(0f, 365f);
        transform.eulerAngles = temp;
    }
}
