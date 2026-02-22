using UnityEngine;
using UnityEngine.Rendering.Universal;

public class DropDown : MonoBehaviour
{
    public AnimationCurve drop; //Curve for the drop to follow
    public float startYPos, timer;
    public bool dropped;
    void Start()
    {
        timer = 0;
        dropped = false;
    }

    void Update()
    {
        //When the dropped boolean is set to true using the FSM and the timer is set to 1, the bug will drop down following the animation curve.
        if ((dropped) && (timer < Time.time))
        {
            //after 1 second, the timer will be set to 3 seconds and dropped is set back to false. The bug will stay in place for 2 seonds before it rises back up following the curve in inverse.
            timer = Time.time + 3;
            dropped = false;
            
        }

        Vector3 temp = transform.position;

        if (timer > Time.time)
        {
            if (dropped) //following the curve normally for dropping down
            {
                temp.y = startYPos + drop.Evaluate(1 - (timer - Time.time));
            }
            else //following the curve in inverse for rising back up
            {
                temp.y = startYPos + drop.Evaluate(timer - Time.time);
            }
        }
        transform.position = temp;
    }
}
