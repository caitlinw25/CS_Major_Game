using UnityEngine;
using System.Collections; //need this for IEnumerator

public class TimeManager : MonoBehaviour
{

    //skybox textures variables
    public Texture2D skyboxNight;
    public Texture2D skyboxSunrise;
    public Texture2D skyboxDay;
    public Texture2D skyboxSunset;

    //lighting variables
    public Light skyTransition;
    public Gradient graddientNightToSunrise;
    public Gradient graddientSunriseToDay;
    public Gradient graddientDayToSunset;
    public Gradient graddientSunsetToNight;


    //variables for time tracking
    private int minutes;
    public int Minutes { get {return minutes; } set {minutes = value; OnMinutesChange(value); } }
    private int hours = 5;
    public int Hours { get {return hours; } set {hours = value; OnHoursChange(value); } }
    private int days;
    public int Days { get {return days; } set {days = value;} }
    private float tempSec;

    //enemy spawning time specific variables (if it's day or night)
    public bool isNight = true; 
    public bool isDay = false; 

    //fixing issue of the blend not starting off at 0
    void Start()
{
    if (RenderSettings.skybox.HasProperty("_Blend"))
    {
        RenderSettings.skybox.SetFloat("_Blend", 0);
    }
}

    
    // Update is called once per frame
    void Update()
    {
        tempSec += Time.deltaTime;
        if(tempSec >= 1)
        {
            Minutes += 1;
            tempSec = 0;
        }
    }


    //every 60 min is a hour, then reset minutes, then every 24 hours is a day, reset hours
    private void OnMinutesChange(int value)
    {
        skyTransition.transform.Rotate(Vector3.up, (1f / (1440f / 4f)) * 360f, Space.Self);
        if(value >= 60)
        {
            Hours++;
            minutes = 0;
        }
        if(Hours >= 24)
        {
            Hours = 0;
            Days++;
        }
    }


    //
    private void OnHoursChange(int value)
    {
        if(value == 6)
        {
            StartCoroutine(LerpSkybox(skyboxNight, skyboxSunrise, 15f)); //when it's at 6 hours, make it blend from night to sunrise
            StartCoroutine(LerpLight(graddientNightToSunrise, 15f)); //add the gradient

        }
        else if(value == 8)
        {
            StartCoroutine(LerpSkybox(skyboxSunrise, skyboxDay, 15f)); //8 hours, sunrise to day
            StartCoroutine(LerpLight(graddientSunriseToDay, 15f));
            isNight = false;
            isDay = true;
        }
        else if(value == 18)
        {
            StartCoroutine(LerpSkybox(skyboxDay, skyboxSunset, 15f)); //18 hours, day to sunset
            StartCoroutine(LerpLight(graddientDayToSunset, 15f));
            isDay = false;
            isNight = true;
        }
        else if(value == 22)
        {
            StartCoroutine(LerpSkybox(skyboxSunset, skyboxNight, 15f)); //22 hours, sunset to night
            StartCoroutine(LerpLight(graddientSunsetToNight, 15f));
        }
    }

    private IEnumerator LerpSkybox(Texture2D a, Texture2D b, float time)
    {
        //set the skyboxes textures/pics
        RenderSettings.skybox.SetTexture("_Texture1", a);
        RenderSettings.skybox.SetTexture("_Texture2", b);
        RenderSettings.skybox.SetFloat("_Blend", 0); //set blend to 0 at first

        //algorithm to slowly change and move along the blend factor to change the skybox seemlessly
        for (float i = 0; i < time; i+= Time.deltaTime)
        {
            RenderSettings.skybox.SetFloat("_Blend", i/time ); //adjust blend variable over time
            yield return null;
        }
        RenderSettings.skybox.SetTexture("_Texture2", b);
    }

    private IEnumerator LerpLight(Gradient lightGradient, float time)
    {
        for (float i = 0; i < time; i+= Time.deltaTime)
        {
            skyTransition.color = lightGradient.Evaluate(i/time); //allows smooth transition from one to another light
            yield return null;
        }
    }
}
