using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSequence : MonoBehaviour
{
    [SerializeField] private List<Light> yellowLights;
    [SerializeField] private List<Light> redLights;
    [SerializeField] private List<Light> greenLights;

    [SerializeField] private float delayBetweenLights = 0.5f;
    [SerializeField] private float delayBeforeReset = 1.0f;

    public void StartSequence()
    {
        StartCoroutine(LightSequenceCoroutine());
    }

    private IEnumerator LightSequenceCoroutine()
    {
        while (true)
        {
            EnableLights(yellowLights, false);
            EnableLights(redLights, false);
            EnableLights(greenLights, false);

            yield return StartCoroutine(EnableLightsSequentially(yellowLights));
            EnableLights(yellowLights, false);

            yield return StartCoroutine(EnableLightsSequentially(redLights));
            EnableLights(redLights, false);

            yield return StartCoroutine(EnableLightsSequentially(greenLights));
            EnableLights(greenLights, false);

            yield return new WaitForSeconds(delayBeforeReset);
        }
        
    }

    private IEnumerator EnableLightsSequentially(List<Light> lights)
    {
        foreach (var light in lights)
        {
            light.enabled = true;
            yield return new WaitForSeconds(delayBetweenLights);
        }
    }

    private void EnableLights(List<Light> lights, bool enable)
    {
        foreach (var light in lights)
            light.enabled = enable;
    }
}