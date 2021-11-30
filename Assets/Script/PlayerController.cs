using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float forwardSpeed;
    public Vector3 move;
    public DynamicJoystick dynamicJoystick;
    public float min, max;

    [Header("Player Swipe Settings For PC")]
    public float roadSize = 10;
    public float swipeSpeed = 5;
    public float sensitive = 3;
    private Vector2 initialTouchPosition;
    private Vector2 currentTouchPosition;
    private float startX;


    // Start is called before the first frame update
    void Start()
    {
        dynamicJoystick = FindObjectOfType<DynamicJoystick>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.TransformDirection(transform.position += transform.forward * forwardSpeed * Time.deltaTime);
        move = new Vector3(dynamicJoystick.Horizontal, 0, 0);
        transform.position += (move * (speed) * Time.deltaTime);
        //animator.SetFloat("move", dynamicJoystick.Horizontal);
        var pos = transform.localPosition;
        pos.x = Mathf.Clamp(transform.localPosition.x, min, max);
        transform.localPosition = pos;
        PlayerSwipe();
    }
    void PlayerSwipe()
    {
        //float newX = startX + (currentTouchPosition.x - initialTouchPosition.x) * swipeSpeed;
        Quaternion rotatinDegree = Quaternion.Euler(transform.rotation.x, dynamicJoystick.Horizontal*10, transform.rotation.z);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotatinDegree, Time.deltaTime * sensitive);
    }
}
