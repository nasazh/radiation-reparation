using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadiationBoltScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * Constants.BALLS_SPEED * 3);
    }
}
