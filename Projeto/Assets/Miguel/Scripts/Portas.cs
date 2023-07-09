using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portas : MonoBehaviour
{
    Vector3 m_openPosition;
    [SerializeField] Vector3 m_closePosition;
    [SerializeField] float m_smothness;
    bool opened;
    void Start()
    {
        m_openPosition = transform.position;
        opened = true;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentPosition;
        if (opened)
        {
            currentPosition = m_openPosition;
        }
        else
        {
            currentPosition = m_closePosition;
        }

        transform.position = Vector3.Lerp(transform.position, currentPosition, m_smothness * Time.deltaTime);
    }

    [ContextMenu("Open")]
    public void Open()
    {
        opened = true;
    }

    [ContextMenu("Close")]
    public void Close()
    {
        opened = false;
    }
}
