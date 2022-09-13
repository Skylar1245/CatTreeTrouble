using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputScripts : MonoBehaviour
{
    public GameObject cat;
    public string catName;
    public GameObject TopPoint;
    public GameObject BottomPoint;
    public GameObject pauseScreen;
    bool Jumping = false;
    int facing = 0;
    public float jumpTime = 0.75f;
    public float mod;
    Animator myAnimator;

    public GameObject catPic;
    public Text catNameText;
    // Start is called before the first frame update
    void Start()
    {
        myAnimator = gameObject.GetComponent<Animator>();
        catNameText.text = catName;

    }
    private void Update()
    {
        if(transform.position.y < BottomPoint.transform.position.y - 2)
        {
            cat.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        mod = CameraMotor.cameraSpeed;
        if(Input.touchCount > 0 && !Jumping && !pauseScreen.activeInHierarchy)
        {

            Touch touch = Input.GetTouch(0);
            Vector2 end = Camera.main.ScreenToWorldPoint(touch.position);

            if (end.y > transform.position.y && end.y < TopPoint.transform.position.y -1)
            {
                end = new Vector2(end.x, end.y + 0.5f);
                Jumping = true;
                myAnimator.SetBool("grounded", false);

                if (end.x > transform.position.x && facing == 0)
                {
                    transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                    facing = 1;
                }
                if (end.x < transform.position.x && facing == 1)
                {
                    transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                    facing = 0;
                }
                StartCoroutine(Jump(end, jumpTime));
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Grond"))
        {
            myAnimator.SetBool("grounded", true);
        } else
        {
            myAnimator.SetBool("grounded", false);
        }
    }

    IEnumerator Jump(Vector2 end, float duration)
    {
        duration -= mod;
        float time = 0;

        Vector2 start = transform.position;

        while(time < duration)
        {
            transform.position = Vector2.Lerp(start, end, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        Jumping = false;
    }
}
