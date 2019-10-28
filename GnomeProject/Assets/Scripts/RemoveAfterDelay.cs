using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveAfterDelay : MonoBehaviour
{
    public float delay = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Remove");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Remove()
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}
