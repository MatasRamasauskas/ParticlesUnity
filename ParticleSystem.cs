using UnityEngine;
using System.Collections;

public class ParticleControl : MonoBehaviour
{
    private bool isPlaying;
    // Use this for initialization
    void Start()
    {
        isPlaying = true;
        InvokeRepeating("ChangeColor", 0, 2);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isPlaying == true)
            {
                this.gameObject.GetComponent<ParticleSystem>().Stop();
            }
            else
            {
                this.gameObject.GetComponent<ParticleSystem>().Play();
            }
            isPlaying = !isPlaying;
        }

        /*byte r = (byte)Random.Range (0, 256);
        byte g = (byte)Random.Range (0, 256);
        byte b = (byte)Random.Range (0, 256);
        subEmitter.GetComponent<ParticleSystem> ().startColor = new Color32 (r, g, b, 255);*/
    }

    void ChangeColor()
    {
        GameObject subEmitter = this.gameObject.transform.GetChild(0).gameObject;
        ParticleSystem.Particle[] parts;
        int kiek;
        parts = new ParticleSystem.Particle[1000];
        kiek = subEmitter.GetComponent<ParticleSystem>().GetParticles(parts);
        for (int i = 0; i < kiek; i++)
        {
            byte r = (byte)Random.Range(0, 256);
            byte g = (byte)Random.Range(0, 256);
            byte b = (byte)Random.Range(0, 256);
            parts[i].color = new Color32(r, g, b, 255);
        }
        subEmitter.GetComponent<ParticleSystem>().SetParticles(parts, kiek);
    }
}