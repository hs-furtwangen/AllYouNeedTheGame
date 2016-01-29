using UnityEngine;

public class Trigger : MonoBehaviour
{
    public float TriggerDistance;
    private GameObject player;
    private PlayerStats playerStats;
    private ParticleSystem ps;

    public Color UntriggeredColor;
    public Color TriggeredColor;

    public float ModifierFood;
    public float ModifierRest;
    public float ModifierSex;

    public float UsageTimer;
    private float _usageTimer;
    public float Downtime;
    private float _downtime;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerStats = player.GetComponent<PlayerStats>();
        ps = this.transform.FindChild("Particles").GetComponent<ParticleSystem>();
        _usageTimer = UsageTimer;
        _downtime = Downtime;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(this.transform.position, player.transform.position) < TriggerDistance)
        {
            if (_usageTimer >= 0)
            {
                playerStats.Food += ModifierFood * Time.deltaTime;
                playerStats.Rest += ModifierRest * Time.deltaTime;
                playerStats.Sexerino += ModifierSex * Time.deltaTime;
                ps.startColor = TriggeredColor;
                _usageTimer -= Time.deltaTime;
            }
        }
        else
        {
            if (_usageTimer != UsageTimer)
            {
                _downtime -= Time.deltaTime;
                if (_downtime <= 0)
                {
                    _usageTimer = UsageTimer;
                    _downtime = Downtime;
                }
            }
            ps.startColor = UntriggeredColor;

        }
    }
}
