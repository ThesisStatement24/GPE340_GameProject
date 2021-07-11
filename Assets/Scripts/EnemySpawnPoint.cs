using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnPoint : MonoBehaviour
{

    [Header("Gizmos")]
    public Color gizmoColor = Color.white;
    public Vector3 boxSize = new Vector3(1, 2, 1);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmos()
    {
        gizmoColor.a = 0.5f;
        Gizmos.color = gizmoColor;

        float boxOffsetY = boxSize.y / 2;
        Gizmos.DrawCube(transform.position + (boxOffsetY * Vector3.up), boxSize);

        Gizmos.color = Color.black;
        Gizmos.DrawRay(transform.position + (boxOffsetY * Vector3.up), transform.forward);

    }

}
