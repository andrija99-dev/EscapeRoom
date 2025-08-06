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
        EnableLights(false);

        foreach (Light light in lights)
        {
            light.enabled = true;
            yield return new WaitForSeconds(delayBetweenLights);
        }

        yield return new WaitForSeconds(delayBeforeReset);

        EnableLights(false);
    }
    private void EnableLights(bool enable)
    {
        foreach (Light light in lights)
            light.enabled = enable;
    }
}
