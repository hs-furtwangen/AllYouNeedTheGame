using UnityEngine;
using System.Collections;
using System.Linq.Expressions;
using UnityEngine.UI;

public class DeathMsg : MonoBehaviour
{
    public float Stay;
    private float _currentStay;

    public Color color;
    private Color trans;

    void Start()
    {
        trans = new Color(0,0,0,0);
    }

	// Update is called once per frame
	void Update () {
        if (_currentStay > 0)
        {
            this.gameObject.GetComponent<Text>().color = color;
            _currentStay -= Time.deltaTime;
        }
        else
        {
            this.gameObject.GetComponent<Text>().color = trans;
        }
    }

    public void StartTimer()
    {
        _currentStay = Stay;
    }
}
