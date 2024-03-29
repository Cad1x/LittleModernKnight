using UnityEngine;

public class PlayerAnim : MonoBehaviour
{

    public ThrowingRock throwingRock;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            anim.SetBool("isJumping", true);
        }

        if (throwingRock.CanThrow() == true && Input.GetKey(KeyCode.Mouse0))
        {
            anim.SetTrigger("throw");
        }

    }
}
