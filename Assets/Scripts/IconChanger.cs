using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SD
{
    public class IconChanger : MonoBehaviour
    {
        PlayerManager playerManager;

        public Sprite meleeIcon;
        public Sprite rangeIcon;

        private Sprite newSprite;

        private Image image;
        void Start()
        {
            playerManager = GameObject.FindWithTag("Player").GetComponent<PlayerManager>();
            image= GetComponent<Image>();
        }

        private void Update()
        {
            MeleeRangeImages();
        }
        public void MeleeRangeImages()
        {
            if(playerManager.weaponIsMelee == true)
            {
                newSprite = meleeIcon;
                ImageChange(newSprite);
            }
            else
            {
                newSprite = rangeIcon;
                ImageChange(newSprite);
            }
        }

        public void ImageChange(Sprite changeSprite)
        {
            image.sprite = changeSprite;            
        }
    }
}