using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPatternManager : MonoBehaviour
{
    public static AttackPatternManager inst;
    private void Awake() => inst = this;

    public List<GameObject> attackList = new List<GameObject>();
    public bool isAttackSummon;
    public int coolTime;

    void Start()
    {
        StartCoroutine(Attack_Spawn());
    }

    void Update()
    {
    }

    IEnumerator Attack_Spawn()
    {
        // ��ȯ�ð� �� 20�ʷ� �س���
        while (true)
        {
            if (GameManager.Instance.IsGameStart == true)
            {
                yield return new WaitForSeconds(coolTime);
                Instantiate(attackList[Random.Range(0, attackList.Count)], transform.position, Quaternion.identity).transform.parent = gameObject.transform;
            }

            else
                yield return new WaitForSeconds(1.0f);
        }

    }
}

