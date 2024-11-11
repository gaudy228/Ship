using System.Collections;
using UnityEngine;

public class Puff : MonoBehaviour
{
    private Animator anim;
    [SerializeField] Player player;
    private bool isTrigger;
    [SerializeField] private Topka topka;
    private bool oneMake = true;
    public bool canRun = true;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isTrigger && player.canPuff)
        {
            isTrigger = false;
            anim.SetTrigger("jump");
            canRun = false;
            player.rb.velocity = Vector2.zero;
        }
        if(topka.puffCount <= 1 || topka.energy <= 0)
        {
            topka.puffCount = 1;
            oneMake = true;
            StopCoroutine(MinusPuff());
        }
    }
    public void CanRunAndJumpPlayer()
    {
        canRun = true;
    }
    public void TopkaPuff()
    {
        if(topka.puffCount < 8 && topka.fuel > 0)
        {
            topka.puffCount++;
            topka.energy ++;
            if(oneMake)
            {
                oneMake = false;
                StartCoroutine(MinusPuff());
            }
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isTrigger = true;
            
        }
    }
    private IEnumerator MinusPuff()
    {

        yield return new WaitForSecondsRealtime(25);
        if(topka.puffCount > 1)
        {
            topka.puffCount--;

        }
        
        StartCoroutine(MinusPuff());
    }
}
