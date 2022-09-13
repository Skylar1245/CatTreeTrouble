using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrunkGenerator : MonoBehaviour
{
    public GameObject prefab;
    public GameObject me;
    public GameObject TopPoint;
    public GameObject BottomPoint;
    bool needsGen = true;

    private void Update()
    {
        if (needsGen && (me.transform.position.y < TopPoint.transform.position.y + 5))
        {
            prefab = Instantiate(me);
            prefab.transform.position = me.transform.position + new Vector3(0, 5f, 0);
            needsGen = false;
        }

        if (!needsGen && (BottomPoint.transform.position.y - 5 > me.transform.position.y))
        {
            Destroy(me); //me when she 
        }
    }
}