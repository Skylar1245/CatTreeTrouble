using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    /**
     * Need referances to all possible platforms
     * as well as the top/bottom points
     * 
     */
    public GameObject TopPoint;
    public GameObject BottomPoint;

    public GameObject lastPlatform;
    public GameObject bed;
    public GameObject bedAngled;
    public GameObject smallPlatform;
    public GameObject smallPlatformAngled;
    public GameObject house;
    public GameObject houseAngled;
    public GameObject largePlatform;

    public GameObject[] platformOptions = new GameObject[7];
    public Queue<GameObject> platformQ = new Queue<GameObject>();

    // Start is called before the first frame update
    private void Start()
    {
        platformOptions[0] = bed;
        platformOptions[1] = bedAngled;
        platformOptions[2] = smallPlatform;
        platformOptions[3] = smallPlatformAngled;
        platformOptions[4] = house;
        platformOptions[5] = houseAngled;
        platformOptions[6] = largePlatform;
        platformQ.Enqueue(lastPlatform);

    }

    // Update is called once per frame
    void Update()
    {
        /**
         * Check if the next platform to be made
         * is too far off screen or not to generate,
         * 
         * If a platform should be made then
         * randomly select one from all options
         * 
         * Place selected platform with some
         * random varaiance above and to the opposite
         * side of the last platform
         * 
         * Need a way to Destroy ones too far below the screen
         * Destroy(me) please
         * 
         */
      
        if (lastPlatform.transform.position.y <= TopPoint.transform.position.y + 5)
        {
            int generate = (int)Random.Range(0f, 6f);
            GameObject nextPlatform = platformOptions[generate];

            float yRange = Random.Range(lastPlatform.transform.position.y + 2f, lastPlatform.transform.position.y + 3f);
            if (nextPlatform == largePlatform)
            {
                lastPlatform = Instantiate(largePlatform);
                Vector3 temp = new Vector3(-0.5f, yRange, lastPlatform.transform.position.z);
                lastPlatform.transform.position = temp;
            }
            //left range -2.3 to -0.5, -0.5 to 1.3
            else
            {
                lastPlatform = Instantiate(nextPlatform);
                float xRange;
                float flip = lastPlatform.transform.localScale.x;
                if (lastPlatform.transform.position.x < -0.5f)
                {
                    xRange = Random.Range(-0.5f, 1.3f);
                    flip *= -1;
                } else
                {
                    xRange = Random.Range(-2.3f, -0.5f);      
                }
                Vector3 temp = new Vector3(xRange, yRange, lastPlatform.transform.position.z);
                lastPlatform.transform.position = temp;
                lastPlatform.transform.localScale = new Vector3(flip, lastPlatform.transform.localScale.y, lastPlatform.transform.localScale.z);
                platformQ.Enqueue(lastPlatform);
            }
        }

        foreach(GameObject item in platformQ)
        {
            if(item.transform.position.y < BottomPoint.transform.position.y - 2)
            {
                platformQ.Dequeue();
                Destroy(item);
            }
        }
    }
}
