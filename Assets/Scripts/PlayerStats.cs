using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float Food;
    public float FoodDepletion;
    public float Rest;
    public float RestDepletion;
    public float Sexerino;
    public float SexDepletion;

    void Update()
    {
        Food -= FoodDepletion * Time.deltaTime;
        Rest -= RestDepletion * Time.deltaTime;
        Sexerino -= SexDepletion * Time.deltaTime;

        Food = Mathf.Clamp(Food, 0, 100);
        Rest = Mathf.Clamp(Rest, 0, 100);
        Sexerino = Mathf.Clamp(Sexerino, 0, 100);

        //Debug.Log("Food: " + Food + " - Rest: " + Rest + " - Sex: " + Sexerino);
    }
}
