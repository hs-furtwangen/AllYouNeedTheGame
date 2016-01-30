using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public float Food;
    public float FoodDepletion;
    public GameObject FoodLabel;
    public float Rest;
    public float RestDepletion;
    public GameObject RestLabel;
    public float Sexerino;
    public float SexDepletion;
    public GameObject SexLabel;

    void Update()
    {
        Food -= FoodDepletion * Time.deltaTime;
        Rest -= RestDepletion * Time.deltaTime;
        Sexerino -= SexDepletion * Time.deltaTime;

        Food = Mathf.Clamp(Food, 0, 100);
        Rest = Mathf.Clamp(Rest, 0, 100);
        Sexerino = Mathf.Clamp(Sexerino, 0, 100);

        //Debug.Log("Food: " + Food + " - Rest: " + Rest + " - Sex: " + Sexerino);

        FoodLabel.GetComponent<Text>().text = "Food: " + Mathf.RoundToInt(Food);
        RestLabel.GetComponent<Text>().text = "Rest: " + Mathf.RoundToInt(Rest);
        SexLabel.GetComponent<Text>().text = "Sex: " + Mathf.RoundToInt(Sexerino);
    }
}
