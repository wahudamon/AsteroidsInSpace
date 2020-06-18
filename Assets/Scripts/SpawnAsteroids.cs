using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAsteroids : MonoBehaviour
{
    public GameObject asteroidsPrefab;
    public float respawnTime = 5f;
    public Vector2 screenBounds;

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(asteroidsWave());
    }

    private void spawnAsteroids() {
        GameObject a = Instantiate(asteroidsPrefab) as GameObject;
        a.transform.position = new Vector2(screenBounds.x + 1, Random.Range(-screenBounds.y, screenBounds.y));
    }

    IEnumerator asteroidsWave() {
        while(true) {
            yield return new WaitForSeconds(respawnTime);
            spawnAsteroids();
        }
    }
}
