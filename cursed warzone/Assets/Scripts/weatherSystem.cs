using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Rendering;
using UnityEngine.VFX;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class weatherSystem : MonoBehaviour
{
    private float Timer;
    private float TimerInt;
    public GameObject rain;
    public bool weatherSun;
    public GameObject GeneralFX;
    public Light l;
    public Material[] skyboxMaterials;

    // Start is called before the first frame update
    void Start()
    {
        TimerInt = Random.Range(120, 300);
        Debug.Log(TimerInt);
        SetSkybox(1);
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;

        if (TimerInt < Timer)
        {
            if (weatherSun)
            {
                Sunny();
                TimerInt = Random.Range(120, 300);
                Debug.Log(TimerInt);
                Timer = 0;
            }
            else
            {
                Rain();
                TimerInt = Random.Range(120, 300);
                Debug.Log(TimerInt);
                Timer = 0;
            }
        }

    }

    public void Sunny()
    {
        weatherSun = false;
        rain.SetActive(false);
        l.color = Color.white;
        SetSkybox(0);
    }

    public void Rain()
    {
        weatherSun = true;
        rain.SetActive(true);
        l.color = Color.grey;
        SetSkybox(1);
    }

    public void SetSkybox(int index)
    {
        if (index >= 0 && index < skyboxMaterials.Length)
        {
            RenderSettings.skybox = skyboxMaterials[index];
            // Update the lighting settings to reflect the new skybox
            DynamicGI.UpdateEnvironment();
        }
        else
        {
            Debug.LogWarning("Skybox index out of range");
        }
    }
}
