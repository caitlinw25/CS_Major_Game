using UnityEngine;

public class Coin : MonoBehaviour
{

    public AudioSource coinSound;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter (Collider other)
    {
        if(other.CompareTag("Player"))
        {
            CoinManager.instance.AddCoin();
            coinSound.Play();
            //Debug.Log("Sound playing:" + (coinSound.isPlaying ? "Yes" : "No")); //check if sound played or not

            Destroy(gameObject);
            
        }
    }
}
