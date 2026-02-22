using UnityEngine;

public class Camera : MonoBehaviour
{

    public Transform rhyhorn;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //The camera will follow Rhyhorn, and use it as a pivot point.
        transform.position = rhyhorn.position;

        Vector3 temp = transform.eulerAngles;

        //A or D will rotate the camera horizontally
        if (Input.GetKey(KeyCode.A))
        {
            temp.y += 100f * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D))
        {
            temp.y -= 100f * Time.deltaTime;
        }
        //W or S will rotate the camera vertically, but clamped to not get stuck at bizarre angles.
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
