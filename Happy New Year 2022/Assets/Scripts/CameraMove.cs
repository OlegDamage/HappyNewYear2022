using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Vector2 _minMaxX;
    public Vector2 _minMaxZ;

    public float _cameraSpeed;
    private Vector2 _startPos;

    Transform trans;

    private void Start()
    {
        trans = transform;
    }

    private void FixedUpdate()
    {
        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    _startPos = touch.position;
                    break;

                case TouchPhase.Moved:
                    Vector2 dir = touch.position - _startPos;
                    _startPos = touch.position;
                    //var pos = transform.position + new Vector3(transform.position.x, transform.position.y, dir.y);
                    Vector3 pos = transform.position + new Vector3(-dir.x, 0, -dir.y);
                    trans.position = Vector3.MoveTowards(transform.position, pos, Time.fixedDeltaTime * _cameraSpeed);
                    trans.position = new Vector3(Mathf.Clamp(trans.position.x, _minMaxX.x, _minMaxX.y), trans.position.y, Mathf.Clamp(trans.position.z, _minMaxZ.x, _minMaxZ.y));
                    break;
            }
        }
    }
}
