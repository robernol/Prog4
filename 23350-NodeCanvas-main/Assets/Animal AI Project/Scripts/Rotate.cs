using UnityEngine;

public class Rotate : MonoBehaviour
{
    public Transform rhyhorn;

    void Update()
    {
        //Rhyhorn's friends will stare into his soul... Forever...

        transform.LookAt(rhyhorn);

    }
}
