using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public float moveSpeed = 300;
    public GameObject Doggy;

    private Rigidbody2D characterBody;
    private float ScreenWidth;
    private float ScreenHeight;

    // Start is called before the first frame update
    void Start()
    {
        ScreenWidth = Screen.width;
        ScreenHeight = Screen.height;
        characterBody = Doggy.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        int i = 0;
        //loop over every touch found
        while (i < Input.touchCount)
        {
            // 
            if ((Input.GetTouch(i).position.x > ScreenWidth / 2) && (Input.GetTouch(i).position.y > ScreenHeight / 2))
            {
                //move right
                RunCharacter(1.0f);
            }
            if (Input.GetTouch(i).position.x < ScreenWidth / 2)
            {
                //move left
                RunCharacter(-1.0f);
            }
            ++i;
        }
    }

    void FixedUpdate()
    {
#if UNITY_EDITOR
        RunCharacter(Input.GetAxis("Horizontal"));
        RunCharacter(Input.GetAxis("Vertical"));
#endif
    }

    private void RunCharacter(float horizontalInput){
        //move player
        characterBody.AddForce(new Vector2(horizontalInput * moveSpeed * Time.deltaTime, 0));

    }

    private void ClimbDoggy(float verticalInput)
    {
        //move player
        characterBody.AddForce(new Vector2(verticalInput * moveSpeed * Time.deltaTime, 0));

    }
}
