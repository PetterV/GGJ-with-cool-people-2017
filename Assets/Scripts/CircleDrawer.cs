using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleDrawer : MonoBehaviour
{

    public float startDuration = 3.0f;
	public float duration;
    public bool isVisible = false;

    Transform target;
    public float ThetaScale = 0.01f;
    public float radius = 3.0f;
    private int Size;
    private LineRenderer LineDrawer;
    private AudioSource VoiceSound;
    private float Theta = 0f;

    void Start()
    {
        LineDrawer = GetComponent<LineRenderer>();
        VoiceSound = GetComponentInParent<AudioSource>();
        target = GameObject.Find("Character").transform;
    }

    void Update()
    {
        // Audio Analysis
        float[] spectrum = new float[1024];
        VoiceSound.GetSpectrumData(spectrum, 0, FFTWindow.Hamming);

        transform.rotation = target.rotation;

        Theta = 0f;
        Size = (int)((1f / ThetaScale) + 1f);
        LineDrawer.numPositions = Size;
        for (int i = 0; i < Size; i++)
        {
            Theta += (2.0f * Mathf.PI * ThetaScale);
            float spectrumSpike = Mathf.Sqrt(spectrum[i]*4) * radius;
            if (i < 3 || i > 99)
                spectrumSpike = 0;
            float x = (radius + spectrumSpike) * Mathf.Cos(Theta);
            float y = (radius + spectrumSpike) * Mathf.Sin(Theta);
            LineDrawer.SetPosition(i, new Vector3(x, y, 0));
        }
        if (isVisible == true){
			duration = duration - Time.deltaTime;
            LineDrawer.endColor = new Color(1.0F, 1.0F, 1.0F, duration / startDuration);
            LineDrawer.startColor = new Color(1.0F, 1.0F, 1.0F, duration / startDuration);
            if ( duration < 0 ){
				LineDrawer.enabled = false;
				isVisible = false;
                //LineDrawer.endColor = new Color(1.0F, 1.0F, 1.0F, 1.0F);
                //LineDrawer.startColor = new Color(1.0F, 1.0F, 1.0F, 1.0F);
            }
		}
    }

	public void StartTimer(float delayedTime)
    {
		Invoke("RealStartTimer", delayedTime);
    }

	void RealStartTimer(){
		LineDrawer.enabled = true;
		isVisible = true;
		duration = startDuration;
	}
}
