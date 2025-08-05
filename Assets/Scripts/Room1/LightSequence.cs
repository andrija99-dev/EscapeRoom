using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSequence : MonoBehaviour
{
    [SerializeField] private List<Light> lights;
    [SerializeField] private float delayBetweenLights;
    [SerializeField] private float delayBeforeReset;

    public void StartSequence()
    {
        StartCoroutine(SequenceCoroutine());
    }

    private IEnumerator SequenceCoroutine()
    {
        foreach (Light light in lights)
            light.enabled = false;

        foreach (Light light in lights)
        {
            light.enabled = true;
            yield return new WaitForSeconds(delayBetweenLights);
        }

        yield return new WaitForSeconds(delayBeforeReset);

        foreach (Light light in lights)
            light.enabled = false;
    }
}
