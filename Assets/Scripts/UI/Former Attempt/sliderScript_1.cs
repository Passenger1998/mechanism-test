using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sliderScript_1 : MonoBehaviour
{

    public playerBattleSystem playerBattleSystem;
    public Image fillImage;
    private Slider slider;

    void Awake()
    {
        slider = GetComponent<Slider>();
    }
 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float fillValue = playerBattleSystem.player_hp / playerBattleSystem.max_hp;
        slider.value = fillValue;
    }
}
