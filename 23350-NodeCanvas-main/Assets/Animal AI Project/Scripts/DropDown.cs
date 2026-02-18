using UnityEngine;
using UnityEngine.Rendering.Universal;

public class DropDown : MonoBehaviour
{
    public AnimationCurve drop;
    public float startYPos, timer;
    public bool dropped;
    void Start()
    {
        timer = 0;
        dropped = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow) && (dropped == false) && (timer < Time.time))
        {
            timer = Time.time + 4;
            dropped = true;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && (dropped == true) && (timer < Time.time))
        {
            timer = Time.time + 4;
            dropped = false;
        }

        Vector3 temp = transform.position;

        if (timer > Time.time)
        {
            if (dropped)
            {
                temp.y = startYPos + drop.Evaluate(3 - (timer - Time.time));
            }
            else
            {
                temp.y = startYPos + drop.Evaluate(timer - Time.time);
            }
        }
        transform.position = temp;
    }
}
