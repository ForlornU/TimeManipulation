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
        yield return new WaitForSeconds(2f);

        Vector3 pos = transform.position + Random.insideUnitSphere * 5f;
        Instantiate(template, pos, Quaternion.identity);
        StartCoroutine(SpawnObject());
        PlaySound();
    }

    void PlaySound()
    {
        AudioClip c = clip1;
        float r = Random.value;
        if(r <= 0.5f)
            c = clip2;
        GetComponent<AudioSource>().PlayOneShot(c);
    }
}
