using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragmentsSummon : MonoBehaviour
{
    public List<GameObject> fragmentList = new List<GameObject>();

    [Header("???? Y??ǥ")]
    public float posYMin;
    public float posYMax;

    void Start()
    {
        Fragments_Summon();
    }

    void Update()
    {

    }

    void Fragments_Summon()
    {
        SoundManager.instance.StopSoundClip(SoundType.BGM);
        SoundManager.instance.PlaySoundClip("Fragments", SoundType.SFX, SoundManager.instance.soundSFX);

        for (int i = 0; i < fragmentList.Count; i++)
            Instantiate(fragmentList[i], new Vector3(-10, Random.Range(posYMin, posYMax), 0), Quaternion.identity).transform.parent = gameObject.transform;
    }
}
