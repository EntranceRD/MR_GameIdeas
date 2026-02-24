using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    int i = 0;

        // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        i++;
        Debug.Log($"Update {i}" );
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Trigger {i}");
    }

}
