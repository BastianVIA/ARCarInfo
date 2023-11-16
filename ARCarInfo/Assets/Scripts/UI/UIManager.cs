using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UIManager : MonoBehaviour
    {
        private Button calibrateBtn;
        private Button toggleModelBtn;
        private Color lightBlue = new Color(128/255f, 160/255f, 1, 1);
        private Color lightGreen = new Color(57/255f, 204/255f, 143/255f, 1);
        
        private CarController carController;

        public bool UIIsOpen { get; set; } = false;

        private void Awake()
        {
            calibrateBtn = GameObject.Find("CalibrateBtn").GetComponent<Button>();
            toggleModelBtn = GameObject.Find("ToggleModelBtn").GetComponent<Button>();
        }

        public void OnCalibrate()
        {
            carController = FindAnyObjectByType<CarController>().GetComponent<CarController>();
            if (carController == null) return;

            switch (calibrateBtn.GetComponentInChildren<TextMeshProUGUI>().text)
            {
                case "Calibrate":
                    ChangeBtnAppearance("Lock", lightBlue, calibrateBtn);
                    carController.UnlockModel();
                    break;
            
                case "Lock":
                    ChangeBtnAppearance("Calibrate", lightGreen, calibrateBtn);
                    carController.LockModel();
                    break;
            }
        }

        public void OnToggleModel()
        {
            carController = FindAnyObjectByType<CarController>().GetComponent<CarController>();
            if (carController == null) return;
        
            switch (toggleModelBtn.GetComponentInChildren<TextMeshProUGUI>().text)
            {
                case "Show":
                    ChangeBtnAppearance("Hide", lightBlue, toggleModelBtn);
                    carController.ShowModelParts();
                    break;
                case "Hide":
                    ChangeBtnAppearance("Show", lightGreen, toggleModelBtn);
                    carController.HideModelParts();
                    break;
            }
        }
    
        private void ChangeBtnAppearance(string btnText, Color color, Button button)
        {
            button.GetComponentInChildren<TextMeshProUGUI>().text = btnText;
            var colors = button.colors;
            colors.normalColor = color;
            colors.selectedColor = color;
            button.colors = colors;
        }
    }
}
