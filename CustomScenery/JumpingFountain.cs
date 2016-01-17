using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Random = UnityEngine.Random;

public class JumpingFountain : MonoBehaviour
{
    private List<ParticleSystem> _jets;

    // Use this for initialization
    void Start()
    {
        _jets = new List<ParticleSystem>(transform.GetComponentsInChildren<ParticleSystem>());

        StartCoroutine(LoopJets());
    }

    private IEnumerator LoopJets()
    {
        for (;;)
        {
            ParticleSystem jet = _jets.OrderBy(x => Guid.NewGuid()).FirstOrDefault();

            jet.Play();

            yield return new WaitForSeconds(Random.value * 2);
        }
    }
}
