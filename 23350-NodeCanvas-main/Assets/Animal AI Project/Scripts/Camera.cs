using UnityEngine;

public class Camera : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public Transform rhyhorn;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = rhyhorn.position;

        Vector3 temp = transform.eulerAngles;

        if (Input.GetKey(KeyCode.A))
        {
            temp.y += 100f * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D))
        {
            temp.y -= 100f * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.W))
        {
            temp.x -= 100f * Time.deltaTime;
            if ((temp.x < 310) && (temp.x > 200))
            {
                temp.x = 310;
            }
        }

        if (Input.GetKey(KeyCode.S))
        {
            temp.x += 100f * Time.deltaTime;
            if ((temp.x > 10 ) && ( temp.x < 200))
            {
                temp.x = 10;
            }
        }

        transform.eulerAngles = temp;
    }
}
