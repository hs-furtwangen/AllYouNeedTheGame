using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public float StartFood;
    public float Food;
    public float FoodDepletion;
    public GameObject FoodLabel;

    public float StartRest;
    public float Rest;
    public float RestDepletion;
    public GameObject RestLabel;

    public float StartFun;
    public float Fun;
    public float FunDepletion;
    public GameObject FunLabel;

    public float StartClean;
    public float Clean;
    public float CleanDepletion;
    public GameObject CleanLabel;

    public float StartSexerino;
    public float Sexerino;
    public float SexDepletion;
    public GameObject SexLabel;

    public Vector3 StartPosition;
    public Vector3 StartRotation;

    private GameController _gc;

    void Start()
    {
        _gc = GameObject.Find("GameController").GetComponent<GameController>();
        ResetStats();
    }

    void Update()
    {
        if (Config.GetGameState("GameRunning"))
        {
            Food -= FoodDepletion*Time.deltaTime;
            Rest -= RestDepletion*Time.deltaTime;
            Sexerino -= SexDepletion*Time.deltaTime;
            Fun -= FunDepletion*Time.deltaTime;
            Clean -= CleanDepletion*Time.deltaTime;

            Food = Mathf.Clamp(Food, 0, 100);
            Rest = Mathf.Clamp(Rest, 0, 100);
            Sexerino = Mathf.Clamp(Sexerino, 0, 100);
            Fun = Mathf.Clamp(Fun, 0, 100);
            Clean = Mathf.Clamp(Clean, 0, 100);

            //Debug.Log("Food: " + Food + " - Rest: " + Rest + " - Sex: " + Sexerino);

            FoodLabel.GetComponent<Text>().text = "Food: " + Mathf.RoundToInt(Food);
            RestLabel.GetComponent<Text>().text = "Rest: " + Mathf.RoundToInt(Rest);
            SexLabel.GetComponent<Text>().text = "Social: " + Mathf.RoundToInt(Sexerino);
            FunLabel.GetComponent<Text>().text = "Fun: " + Mathf.RoundToInt(Fun);
            CleanLabel.GetComponent<Text>().text = "Clean: " + Mathf.RoundToInt(Clean);

            if (Food <= 0 || Rest <= 0 || Sexerino <= 0 || Fun <= 0 || Clean <= 0)
            {
                _gc.EndGame();
                ResetStats();
            }
        }
    }

    void ResetStats()
    {
        Food = StartFood;
        Rest = StartRest;
        Sexerino = StartSexerino;
        Clean = StartClean;
        Fun = StartFun;

        this.transform.position = StartPosition;
        this.transform.rotation = Quaternion.Euler(StartRotation);
    }
}
