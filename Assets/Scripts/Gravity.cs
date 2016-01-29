using UnityEngine;

public class Gravity : MonoBehaviour
{
    public float GravityStrength;
    public float DistanceToGround;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * GravityStrength);

        RaycastHit hit;

        while (Physics.Raycast(transform.position, Vector3.down, out hit, DistanceToGround))
        {
            if (hit.collider.gameObject.tag == "Terrain")
            {
                transform.Translate(Vector3.up * GravityStrength);
            }
            else
            {
                break;
            }
        }
    }
}
