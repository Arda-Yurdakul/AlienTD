using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WaveHandler : MonoBehaviour
{

    private Queue<Waypoint> waypoints = new Queue<Waypoint>();
    private Queue<GameObject> turrets = new Queue<GameObject>();


    private const string waveWarning = "New Wave Incoming!\nMax Turrets +1";
    private const string bossWarning = "Boss Incoming!\nMax Turrets +1";
    private const string winWarning = "You Win!\nThe Mother Base Is Safe";
    private const string startWarning = "Wave 1\n Max Turrets 3";

    [SerializeField] private int maxTurrets;
    [SerializeField] private GameObject turret;
    [SerializeField] private GameObject headsUp;

    // Start is called before the first frame update
    void Start()
    {
        Text headsUpText = headsUp.GetComponent<Text>();
        headsUpText.text = startWarning;
        StartCoroutine(GiveHeadsUp(3.0f));
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void HandleTurretSpawn(Waypoint waypoint)
    {
        if (waypoints.Count != maxTurrets)
        {
            GameObject myTurret = Instantiate(turret, waypoint.transform.position + new Vector3(0, 10, 0), Quaternion.identity);
            turrets.Enqueue(myTurret);
            myTurret.transform.parent = this.transform;
            waypoints.Enqueue(waypoint);
            waypoint.hasTower = true;
            turret.name = waypoints.Count.ToString();
        }
        else
        {
            Waypoint oldestWaypoint = waypoints.Dequeue();
            GameObject myTurret = turrets.Dequeue();
            oldestWaypoint.hasTower = false;
            myTurret.transform.position = waypoint.transform.position + new Vector3(0, 10, 0);
            print(myTurret.name);
            waypoint.hasTower = true;
            turrets.Enqueue(myTurret);
            waypoints.Enqueue(waypoint);
        }
    }

    public void HandleWave(int waveNumber)
    {

        Text headsUpText = headsUp.GetComponent<Text>();
        maxTurrets += 1;
        switch (waveNumber)
        {

            case (4):
                headsUpText.text = winWarning;
                headsUpText.color = Color.green;
                StartCoroutine(EndGame(5.0f));
                break;
            case (3):
                headsUpText.text = bossWarning;
                StartCoroutine(GiveHeadsUp(4.0f));
                break;
            default:
                headsUpText.text = waveWarning;
                StartCoroutine(GiveHeadsUp(3.0f));
                break;

        }

    }


    private IEnumerator GiveHeadsUp(float waitTime)
    {  
        headsUp.SetActive(true);
        yield return new WaitForSeconds(waitTime);
        headsUp.SetActive(false);
    }

    private IEnumerator EndGame(float waitTime)
    {
        headsUp.SetActive(true);
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }


}

