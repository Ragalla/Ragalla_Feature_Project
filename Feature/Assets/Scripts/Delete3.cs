using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delete3 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(delete());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator delete()
    {
        yield return new WaitForSeconds(0.2f);
        Object.Destroy(this.gameObject);
    }
}
