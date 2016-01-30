using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float SpeedMovement;
    public float SpeedRotation;

    // Update is called once per frame
    void Update()
    {
        if (Config.GetGameState("GameRunning"))
        {
            this.transform.Translate(Input.GetAxis("Vertical")*SpeedMovement*Time.deltaTime*Vector3.forward);
            this.transform.Rotate(Vector3.up, Input.GetAxis("Horizontal")*SpeedRotation*Time.deltaTime);
        }
    }
}
