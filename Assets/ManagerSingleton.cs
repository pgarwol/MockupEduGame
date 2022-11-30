using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerSingleton : MonoBehaviour
{
    //Player variables - how much health
    public int playerCurrentHealth;

    //To b�dzie trzeba du�o testowa�, wpisuj� 30 bo takie jest w Hearthstone i jako� dzia�a
    public int playerMaxHealth = 30;

    //Ile mia� HP zaczynaj�c i ko�cz�c tur�? Mo�e potem si� przyda� do kart/item�w
    public int startedTurnWithHealth;
    public int endedTurnWithHealth;
    public int preBlockHealth;
    public bool hasBlockedAlready;

    //Blockade
    public int playerBlockade = 0;

    //PLACEHOLDER
    [SerializeField] private GameObject deathMessage;


    public static ManagerSingleton Instance { get; private set; }

    private void Awake()        
    {
        // start of singleton pattern
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        // end of singleton pattern
    }



    // Start is called before the first frame update
    void Start()
    {
        //Player starts at full health
        playerCurrentHealth = playerMaxHealth;

        startedTurnWithHealth = playerCurrentHealth;

        preBlockHealth = playerCurrentHealth;
    }

    // Update is called once per frame
    void Update()
    {

        //Dying logic
        if (playerCurrentHealth <= 0)
        {
            playerDeath();
        }
    }


    public void playerDeath()
    {
        //PLACEHOLDER
        //Display the death screen and message
        deathMessage.SetActive(true);
    }

    public void Heal(int healedAmount)
    {
        //Restore a set amount of health
        playerCurrentHealth += healedAmount;

        //Do not allow overheal
        if (playerCurrentHealth > playerMaxHealth) {
            playerCurrentHealth = playerMaxHealth;
        }
    }

    public void Barricade(int barricadeAmount)
    {
        // Same as healing but allow for overheal
        playerCurrentHealth += barricadeAmount;
    }

    public void Block(int blockAmount)
    {
        GameObject.Find("Enemy").GetComponent<EnemyBehaviuur>().damageCapability -= blockAmount;
    }

    public void ActivateDefensiveActionFromCard(int barricade, int block, int heal)
    {
        if (barricade != 0)
        {
            Barricade(barricade);
        }

        if (block != 0)
        {
            Block(block);
        }

        if (heal != 0)
        {
            Heal(heal);
        }
    }
}
