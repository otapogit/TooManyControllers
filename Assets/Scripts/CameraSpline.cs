using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSpline : MonoBehaviour
{
    public Vector3 start;
    public Vector3 end;
    public float time;
    float currtime = 0;
    // Start is called before the first frame update
    void Start()
    {
        start = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        currtime += Time.deltaTime;
        float tvalue = Mathf.Min(1.0f, currtime/time);
        this.transform.position = start + Vector3.Lerp(new Vector3(0,0,0),end,tvalue);
    }
}
