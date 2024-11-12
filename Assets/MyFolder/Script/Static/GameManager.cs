using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private int score;

    [SerializeField] private GameObject[] initializeMembers;
    private List<Initializer> initializeMemberList = new();

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
        else
        {
            instance.score = 0;
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        AddInitializeMember();
        foreach (var v in initializeMemberList)
        {
            v.Initialize();
        }
    }

    private void AddInitializeMember()
    {
        if (initializeMembers is null)
        {
            return;
        }
        foreach (var v in initializeMembers)
        {
            var x = v.GetComponent<Initializer>();
            if (x != null) // 컴포넌트가 있을 때만 추가
            {
                initializeMemberList.Add(x);
            }
        }
    }

    public void AddScore()
    {
        ++score;
    }

    public int GetScore()
    {
        return score;
    }
}
