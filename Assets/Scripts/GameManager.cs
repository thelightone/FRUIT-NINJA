using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public TMP_Text scores;
    public int numscore;

    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Spawner");
        numscore= 0;
        scores.text = numscore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
     
    }
    IEnumerator Spawner()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }
    public void Score(int plus)
    {
        numscore += plus;
        scores.text = numscore.ToString();
    }
}
