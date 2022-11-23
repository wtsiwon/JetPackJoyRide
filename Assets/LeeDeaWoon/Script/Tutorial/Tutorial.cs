using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using DG.Tweening;
using TMPro;

public class Tutorial : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] GameObject obstacle;

    [SerializeField] GameObject descriptionBar;
    [SerializeField] bool isNextCheck;
    [SerializeField] int nextNum;

    void Start()
    {

    }

    void Update()
    {
        Description_Box();
    }

    void Description_Box()
    {
        if (isNextCheck == true)
        {
            isNextCheck = false;
            descriptionBar.transform.GetChild(nextNum - 1).gameObject.SetActive(false);
            descriptionBar.transform.GetChild(nextNum).gameObject.SetActive(true);
        }
    }

    IEnumerator NextDescription()
    {
        descriptionBar.transform.GetChild(nextNum).GetComponent<TextMeshProUGUI>().text = "���ϼ̽��ϴ�.";

        yield return new WaitForSeconds(2);

        nextNum += 1;
        isNextCheck = true;

        switch (nextNum)
        {
            case 2:
                Obstacle();
                break;

            case 3:
                EnemyAttack();
                break;
        }

    }

    void Obstacle()
    {
        obstacle.SetActive(true);
        obstacle.transform.DOMoveX(20, 0);
        Player.Instance.IsDie = false;

        obstacle.transform.DOMoveX(-14, 5).SetEase(Ease.Linear).OnComplete(() =>
        {
            if (Player.Instance.IsDie == true)
            {
                descriptionBar.transform.GetChild(nextNum).GetComponent<TextMeshProUGUI>().text = "�ٽ� �� �� �غ��ô�.";
                Obstacle();
            }

            else
            {
                Destroy(obstacle);
                StartCoroutine(NextDescription());
            }
        });
    }

    void EnemyAttack()
    {

    }

    #region �÷��̾� �̵�
    public void OnPointerDown(PointerEventData eventData)
    {
        if (nextNum == 0)
            StartCoroutine(NextDescription());

        Player.Instance.isPressing = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (nextNum == 1)
            StartCoroutine(NextDescription());

        Player.Instance.isPressing = false;
    }
    #endregion
}
