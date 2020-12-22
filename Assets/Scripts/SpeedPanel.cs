using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class SpeedPanel : MonoBehaviour
{
    List<GameObject> speedButtons = new List<GameObject>();
    [SerializeField] GameObject waveObject;
    [SerializeField] TextMeshProUGUI[] propertiesArray;
    const string WAVELENGTH1 = "W1=";
    const string FREQUENCY1 = "F1=";
    const string WAVELENGTH2 = "W2=";
    const string FREQUENCY2 = "F2=";
    void Start()
    {
       for(int i=0;i<transform.childCount;i++)
        {
            speedButtons.Add(transform.GetChild(i).gameObject);
        }
    }

    public void SwitchSpeed()
    {
        foreach(GameObject button in speedButtons)
        {
            GameObject initialChild = button.gameObject.transform.GetChild(0).gameObject;
            initialChild.GetComponent<TextMeshProUGUI>().color=new Color(0.4528302f, 0.4528302f, 0.4528302f);
        }
        switch(EventSystem.current.currentSelectedGameObject.name)
        {
            case "Option1":
                SwitchColor(0);
                UpdateProperties("1.65 m","200 Hz","1.65 m","200 Hz");
                SetWaveEffect(0);
                break;
            case "Option2":
                SwitchColor(1);
                UpdateProperties("1.72 m", "192 Hz", "1.58 m", "208 Hz");
                SetWaveEffect(1);
                break;
            case "Option3":
                SwitchColor(2);
                UpdateProperties("1.78 m", "184 Hz", "1.51 m", "215 Hz");
                SetWaveEffect(2);
                break;
            case "Option4":
                SwitchColor(3);
                UpdateProperties("1.92 m", "171 Hz", "1.37 m", "240 Hz");
                SetWaveEffect(3);
                break;
        }

    }

    private void UpdateProperties(string string1,string string2, string string3, string string4)
    {
        propertiesArray[0].text = WAVELENGTH1 + string1;
        propertiesArray[1].text = FREQUENCY1 + string2;
        propertiesArray[2].text = WAVELENGTH2 + string3;
        propertiesArray[3].text = FREQUENCY2 + string4;
    }

    private void SwitchColor(int index)
    {
        GameObject initialChild = speedButtons[index].transform.GetChild(0).gameObject;
        initialChild.GetComponent<TextMeshProUGUI>().color = new Color(0.02352941f, 0.145098f, 0.4f);
    }

    private void SetWaveEffect(int index)
    {
        for(int i=0;i<waveObject.transform.childCount;i++)
        {
            waveObject.transform.GetChild(i).gameObject.SetActive(false);
        }
        waveObject.transform.GetChild(index).gameObject.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
