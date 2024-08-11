using UnityEngine;
using UnityEngine.UI;

public class WheelAnimate : MonoBehaviour
{
    [SerializeField] RawImage[] _rawImage;


    public void MoveWheels(float input)
    {
        for (int i = 0; i < _rawImage.Length; i++)
        {
            _rawImage[i].uvRect = new Rect(_rawImage[i].uvRect.position + new Vector2(0,input)* Time.deltaTime, _rawImage[i].uvRect.size);
            //lastik görselinin uv rect kýsmýnda kendi pozisyonuna ek Y eksenine gelen girdiyi ekliyoruz 
        }
    }

}
