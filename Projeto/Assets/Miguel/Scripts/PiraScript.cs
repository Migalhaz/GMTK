using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiraScript : BossAbstract
{
    [Header("Attack Settings")]
    [SerializeField] List<GameObject> m_attackRay;
    bool m_isAttacking;
    [SerializeField, Min(0)] float m_attackDelayOne;
    [SerializeField, Min(0)] float m_attackDelayTwo;
    float currentAttackDelay;

    [Header("Rotate Settings")]
    [SerializeField] Vector2 m_rangeTimer;
    [SerializeField, Min(0)] float m_rotateSpeed;
    float m_currentSpeed;
    float m_currentTimer;
    Vector3 m_eulerAngles;

    [Header("Laser Debbug")]
    float alpha;
    bool laserOn;
    [SerializeField] private Material piramidMaterial;
    float morrendoFloat = 5;
    [SerializeField] float morrendoSpeed = 0.1f;
    [SerializeField] List<Renderer> renderes;
    [SerializeField] SkinnedMeshRenderer olho;
    private float olhoAbertura = 100;
    int olhoDirection = 0;
    [SerializeField] List<BoxCollider> colisores;
    [SerializeField] GameObject soul;
    enum State { One, Two }
    State m_currentState;

    private void Awake()
    {
        m_canTakeDamage = true;

        piramidMaterial.SetFloat("_Saturacao", 5);
        piramidMaterial.SetFloat("_alphaPiramide", 0);
        foreach (Renderer rend in renderes)
        {
            rend.material = piramidMaterial;
        }
        SetCurrentTimer();
        SetRayActive(false);

        SetState();
    }

    void SetState()
    {
        m_currentState = Random.value >= .5f ? State.One : State.Two;
        currentAttackDelay = m_currentState == State.One ? m_attackDelayOne : m_attackDelayTwo;
    }

    private void Update()
    {
        if (!m_active) return; 
        switch (m_currentState)
        {
            case State.One:
                StateOne();
                break;
            case State.Two:
                StateTwo();
                break;
        }

        if (laserOn)
        {
            foreach (GameObject ray in m_attackRay)
            {
                alpha += Mathf.Lerp(0, 1, currentAttackDelay * .5f * Time.deltaTime);
                ray.GetComponent<Renderer>().material.SetFloat("_alpha", alpha);
            }
        }

        olhoAbertura += Time.deltaTime * olhoDirection * 100;
        if (olhoAbertura < 0) olhoAbertura = 0;
        if (olhoAbertura > 100) olhoAbertura = 100;
        olho.SetBlendShapeWeight(0, olhoAbertura);
    }

    void StateOne()
    {
        m_currentTimer -= Time.deltaTime;
        if (m_currentTimer > 0)
        {
            Rotate();
        }
        else
        {
            Attack();
        }
    }

    void StateTwo()
    {
        m_currentTimer -= Time.deltaTime;
        Rotate();
        if (m_currentTimer <= 0)
        {
            Attack();
        }
    }

    void Rotate()
    {
        m_currentSpeed += m_rotateSpeed;
        m_eulerAngles.Set(transform.eulerAngles.x, m_currentSpeed, transform.eulerAngles.z);
        m_currentSpeed = m_eulerAngles.y;
        transform.eulerAngles = m_eulerAngles;
    }

    void Attack()
    {
        if (m_isAttacking) return;
        StartCoroutine(nameof(AttackEffect));
    }

    IEnumerator AttackEffect()
    {
        m_isAttacking = true;
        m_canTakeDamage = true;
        olhoDirection = -1;
        foreach(BoxCollider col in colisores)
        {
            col.enabled = true;
        }
        yield return new WaitForSeconds(currentAttackDelay * 0.5f);
        SetRayActive(true);
        yield return new WaitForSeconds(currentAttackDelay * 0.5f);
        foreach (BoxCollider col in colisores)
        {
            col.enabled = false;
        }
        olhoDirection = 1;
        SetRayActive(false);
        m_isAttacking = false;
        m_canTakeDamage = false;
        SetCurrentTimer();
        SetState();
    }

    void SetRayActive(bool active)
    {
        foreach(GameObject ray in m_attackRay)
        {
            if (active)
            {
                alpha = 0;
                laserOn = true;
                ray.GetComponent<Collider>().enabled = true;
            }
            else
            {
                laserOn = false;
                ray.GetComponent<Renderer>().material.SetFloat("_alpha", 1);
                ray.GetComponent<Collider>().enabled = false;
            }
        }
    }

    void SetCurrentTimer()
    {
        m_currentTimer = Random.Range(m_rangeTimer.x, m_rangeTimer.y);
    }

    public override void Damage()
    {
        StartCoroutine(Dead());
    }

    IEnumerator Dead()
    {
        PlayerCollider pc = GetComponent<PlayerCollider>();
        if (pc.canTeleportForever)
        {
            pc.canTeleportForever = false;
        }
        else
        {
            pc.canShotForever = false;
        }
        m_rotateSpeed = 0;
        StartCoroutine(spawnSoul());
        while (true)
        {
            morrendoFloat -= morrendoSpeed;
            if (morrendoFloat > 0)
            {
                piramidMaterial.SetFloat("_Saturacao", morrendoFloat);
            }
            else
            {
                piramidMaterial.SetFloat("_alphaPiramide", morrendoFloat * -1 / 4);
            }
            yield return new WaitForSeconds(0.05f);
        }
    }

    IEnumerator spawnSoul()
    {
        yield return new WaitForSeconds(5);
        Instantiate(soul, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
