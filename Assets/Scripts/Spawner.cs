using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    AudioClip clip1, clip2;

    [SerializeField]
    GameObject template;

    private void Start()
    {
        StartCoroutine(SpawnObject());
    }
    IEnumerator SpawnObject()
    {
        yield return new WaitForSeconds(Random.Range(1f, 2f));

        Vector3 randomPos = transform.position + Random.insideUnitSphere * 5f;
        Instantiate(template, randomPos, Quaternion.identity);
        PlaySound();

        StartCoroutine(SpawnObject());
    }

    void PlaySound()
    {
        AudioClip randomClip = clip1;

        float randomValue = Random.value;
        if(randomValue <= 0.5f)
            randomClip = clip2;

        GetComponent<AudioSource>().PlayOneShot(randomClip);
    }
}
