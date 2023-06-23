 using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace VeesCostumesUI
{
    public sealed class CostumeSelectorUI : MonoBehaviour , IPointerClickHandler
    {
        enum TypeOfAccessory { Hair, Skin, Chestware};
        [SerializeField] TypeOfAccessory _type_of_accessory;

        [SerializeField] SpriteRenderer _players_skin_SR;
        [SerializeField] SpriteRenderer _players_hair_SR;
        [SerializeField] SpriteRenderer _players_chestware_SR;
        [SerializeField] SpriteRenderer _players_hat_SR;
        public void OnPointerClick(PointerEventData eventData)
        {
            if (_type_of_accessory == TypeOfAccessory.Hair)
            {
                _players_hair_SR.sprite = transform.Find("Hair_Color").GetComponent<Image>().sprite;
            } else if (_type_of_accessory == TypeOfAccessory.Skin) 
            {
                _players_skin_SR.sprite = transform.Find("Skin_Color").GetComponent<Image>().sprite;
            } else if (_type_of_accessory == TypeOfAccessory.Chestware)
            {
                _players_chestware_SR.sprite = transform.Find("Shirt_Color").GetComponent<Image>().sprite;
            }

        }
    }
}


