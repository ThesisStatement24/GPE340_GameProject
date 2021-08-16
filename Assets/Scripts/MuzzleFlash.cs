using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzzleFlash : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine("FlashDestroy");

    }

    // Update is called once per frame
    void Update()
    {
        
    }

   IEnumerator FlashDestroy()
    {

        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject);

    }

}
