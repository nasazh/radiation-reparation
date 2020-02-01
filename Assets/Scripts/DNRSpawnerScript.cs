using System;
using UnityEngine;

public class DNRSpawnerScript : MonoBehaviour
{

    public GameObject dnr;

    float timer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= Constants.DNR_SPAWN_TIME)
        {
            Instantiate(dnr, transform.localPosition, Quaternion.identity);
            timer = 0;
        }
    }
}
