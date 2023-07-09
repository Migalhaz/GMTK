using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Angel : BossAbstract
{
    [SerializeField] Transform m_player;
    [SerializeField] float m_moveSpeed;

    [Header("Childs")]
    [SerializeField] Transform m_childPivot;
    [SerializeField] float m_rotateSpeed;
    [SerializeField] List<GameObject> m_defaultChilds;
    [SerializeField] List<GameObject> m_childs;
    [SerializeField] List<GameObject> m_activeChild;
    void Start()
    {
        m_player ??= GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        SetLook();
        Move();
    }

    void Move()
    {
        transform.Translate(m_moveSpeed * Time.deltaTime * Vector3.forward);
    }

    void RotateChilds()
    {
        float newAngle = m_childPivot.eulerAngles.y + m_rotateSpeed;

    }

    void SetLook()
    {
        Vector3 target = new(m_player.position.x, transform.position.y, m_player.position.z);
        transform.LookAt(target);
    }

    void CreateRandomChild()
    {
        if(m_activeChild.Count >= m_childs.Count)
        {
            return;
        }

        GameObject i = m_childs.GetRandom();
        if (m_activeChild.Find(x => x == i))
        {
            CreateRandomChild();
            return;
        }
        m_activeChild.Add(i);
        i.SetActive(true);
    }

    public void KillChild(GameObject child)
    {
        if (!m_activeChild.Find(x => x == child))
        {
            return;
        }
        m_activeChild.Remove(child);
        child.SetActive(false);
    }
}

public static class ListExtend
{
    public static T GetRandom<T>(this List<T> list)
    {
        return list[Random.Range(0, list.Count)];
    }
}
