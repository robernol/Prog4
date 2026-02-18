using UnityEngine;

public class Rotate : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public Transform rhyhorn;

    // Update is called once per frame
    void Update()
    {
        //Vector3 temp = transform.eulerAngles;

        transform.LookAt(rhyhorn);

    }
}
