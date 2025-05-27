using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndroidDebugLog : MonoBehaviour
{

    void Awake()
    {   
        Debug.Log("Unity calls awake!");
    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Unity calls Start!");
        StartCoroutine(DebugEveryTwoSeconds());
    }

    IEnumerator DebugEveryTwoSeconds()
    {
        for (int i = 0; i < 5; i++)
        {
            Debug.Log($"Debug message {i + 1}");
            yield return new WaitForSeconds(2f);
        }

        Debug.Log("Finished debugging 5 times.");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
