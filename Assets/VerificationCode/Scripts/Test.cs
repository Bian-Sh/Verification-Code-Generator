using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Test : MonoBehaviour
{
    public int width=500;
    public int height=250;
    public int num = 4;

    public Text text;
    public Button button;
    public Button exit_button;
    private Image image;

    private void Start()
    {
        Screen.SetResolution(480,320,false);
        image = GetComponent<Image>();
        button.onClick.AddListener(OnButtonClicked);
        exit_button.onClick.AddListener(()=>Application.Quit());
    }

    private void OnButtonClicked()
    {
        var code = ShowVerificationCode(image,width,height,num);
        text.text = code;
    }

    


    /// <summary>
    /// 显示图片验证码
    /// </summary>
    /// <param name="img">显示验证码的image组件</param>
    /// <param name="imgWidth">图片宽度，150</param>
    /// <param name="imgHeight">图片高度， 60</param>
    /// <param name="length">字符长度，一般为4</param>
    /// <returns>验证码字符串</returns>
    private string ShowVerificationCode(Image img, int imgWidth, int imgHeight, int length)
    {
        VerificationCode vCode = new VerificationCode(imgWidth, imgHeight, length);
        Texture2D texture = VerificationCode.Image2Texture(vCode.Image);
        img.sprite = Sprite.Create(texture, new Rect(0, 0, imgWidth, imgHeight), new Vector2(0.5f, 0.5f), 125);
        return vCode.Text;
    }
}
