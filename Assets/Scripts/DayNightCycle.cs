using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    //variables for skyboxes and time switches
    public Material daySkybox; 
    public Material sunsetSkybox;
    public Material nightSkybox;
    public Material sunriseSkybox;

    //public Material blendedSkies;
    public float dayDuration = 60f; //each day is one minute
    private float dayCycle;

    //create a new material for when the skies are transitioning so we don't alter our original materials
    void Start()
    {
        //blendedSkies = new Material(daySkybox);
        //RenderSettings.skybox = blendedSkies;
    }


    // Update is called once per frame
    void Update()
    {

        dayCycle = Mathf.PingPong(Time.time/dayDuration, 1f); //making the day cycle 0 to 1 (this way it's easier to control when to change the sky boxes)

        //control when the sun is rising, setting, day, or night
        //the day is 1/4 of the way, it'll be day
        if (dayCycle < 0.4f) //40% of the day is daytime skybox
        {    
            RenderSettings.skybox = daySkybox;
        }
        else if (dayCycle < 0.45f) //5% of the time it's sunset
        {
            RenderSettings.skybox = sunsetSkybox;
        }
        else if (dayCycle < 0.85f) //another 40% is night skybox
        {
            RenderSettings.skybox = nightSkybox;
        }
        else //last 5% is sunrise
        {
            RenderSettings.skybox = sunriseSkybox;
        }   


        DynamicGI.UpdateEnvironment();

    }
}
