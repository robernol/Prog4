using UnityEngine;

public class RunAway : MonoBehaviour
{
    public float timer;
    bool bonked;
    public Vector3 startingRotation, runningRotation;

    void Start()
    {
        timer = Time.time + 2;   
        transform.eulerAngles = startingRotation; //some of the models imported were rotated differently, so this is to adjust for their starting rotation
        bonked = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time < timer) {} //for 2 seconds, the dropped creature will bounce around with no input

        else //after 2 seconds, the creature will run to the back wall of the enclosure, then be destroyed after passing it (the wall's collision has been turned off after baking the NavMesh)
        {
            Vector3 temp = transform.position;

            temp.z -= 2f * Time.deltaTime;
            transform.position = temp;
            transform.eulerAngles = runningRotation;
        }

        if (transform.position.z <= 5f)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!bonked) //plays a bonk sound after hitting rhyhorn on the head. The bonked value is then set to true to prevent playing the sound over and over again.
        {
            GetComponent<AudioSource>().Play();
            bonked = true;
        }
        
    }
}
