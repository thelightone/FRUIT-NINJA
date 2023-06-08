using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _targets;
    [SerializeField]
    private TMP_Text _scores;
    [SerializeField]
    private int _numscore;

    void Start()
    {
        StartCoroutine("Spawner");
        _numscore = 0;
        _scores.text = _numscore.ToString();
    }

    IEnumerator Spawner()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            int index = Random.Range(0, _targets.Count);
            Instantiate(_targets[index]);
        }
    }

    public void Score(int plus)
    {
        _numscore += plus;
        _scores.text = _numscore.ToString();
    }
}
