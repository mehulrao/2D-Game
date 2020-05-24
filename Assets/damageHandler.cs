using UnityEngine;
using UnityEngine.SceneManagement;

public class damageHandler : MonoBehaviour {
    public int maxHealth = 10;
    public int currentHealth;
    public HealthBar healthBar;
    public Animator animator;
    float curTime = 0;
    float nextDamage = 1;

    public Material mat;

    private void Start() {
        currentHealth = maxHealth;
        healthBar.setMaxHealth(maxHealth);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        //Check the provided Collider2D parameter other to see if it is tagged "PickUp", if it is...
        if (other.gameObject.CompareTag("Damage Floor"))
        {
            if (curTime <= 0)
            {
                takeDamage(10);
                curTime = nextDamage;
            }
        }
    }

    void OnTriggerStay2D(Collider2D other) {
        if (other.gameObject.CompareTag("Damage"))
        {
            //Debug.Log("Entered");
            if (curTime <= 0)
            {
                takeDamage(1);
                curTime = nextDamage;
            }
        }
    }

    void takeDamage(int damage)
    {
        animator.SetBool("isHurt", true); //Run hurt animation
        currentHealth = (currentHealth - damage); //Subtract damage from current health
        healthBar.setHealth(currentHealth);  //Sets health to currentHealth by calling HealthBar.cs
        Invoke("backToIdle", .5f);   //Calls "backToIdle" Function after .5 seconds (sub algo 1)
        if (currentHealth <= 0) //Checks if the health of the player is 0
        {
            Die(); //Runs Die Function (sub algo 2)
        }
    }

    void backToIdle()
    {
        animator.SetBool("isHurt", false); //Stops playing hurt animation
        curTime = 0; //Resets time after last damage
    }

    void Die()
    {
        currentHealth = maxHealth; //Set health to max due to player death
        healthBar.setHealth(currentHealth); //Set healthBar back to max
        Scene thisScene = SceneManager.GetActiveScene(); //Store current scene in a variable
        SceneManager.LoadScene(thisScene.buildIndex + 2); //Load Death Scene(main scene + 2)
    }
}