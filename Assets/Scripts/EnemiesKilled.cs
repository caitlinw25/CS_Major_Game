using UnityEngine;
using UnityEngine.Events;

public class EnemiesKilled : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int numEnemies { get; private set; }

    public UnityEvent<EnemiesKilled> OnenemiesKilled;

    public void enemiesKilled()
    {
        numEnemies++;
        OnenemiesKilled.Invoke(this);
    }
    
}
