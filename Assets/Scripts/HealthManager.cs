using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private int baseHealth;
    [SerializeField] private GameObject deathPanel;
    [SerializeField] private Slider healthBar;
    private static HealthManager _instance;
    public static HealthManager Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError("No HealthManager Found!");
            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        healthBar.value = healthBar.maxValue;
    }

    // Update is called once per frame
    void Update()
    {
        if(baseHealth <= 0)
        {
            Invoke("HandleDeath", 1.0f);
        }
    }

    public void DecrementHealth(int damage)
    {
        baseHealth -= damage;
        healthBar.value -= damage;
    }

    public void HandleDeath()
    {
        deathPanel.SetActive(true);
        Time.timeScale = 0f;
        Time.fixedDeltaTime = 0.02F * Time.timeScale;
        Cursor.visible = true;
        baseHealth = 10;
    }
}
