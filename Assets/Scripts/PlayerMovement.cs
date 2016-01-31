using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float SpeedMovement;
    public float SpeedRotation;
    private Vector3 _positionLastFrame;
    private float rot;

    private Animation anim;

    // Update is called once per frame
    void Start()
    {
        anim = this.GetComponentInChildren<Animation>();
    }

    void Update()
    {
        if (Config.GetGameState("GameRunning"))
        {
            if (Input.GetAxis("Vertical") > 0)
            {
                anim.CrossFade("Laufen");
            }
            else
            {
                anim.CrossFade("Idle");
            }
            rot += Input.GetAxis("Horizontal");

            this.transform.Translate(Input.GetAxis("Vertical")*SpeedMovement*Time.deltaTime*Vector3.forward);
            this.transform.rotation = Quaternion.Euler(0, rot *SpeedRotation, 0);
        }
        _positionLastFrame = this.transform.position;
    }

}
