using UnityEngine;

namespace KartGame.KartSystems
{

    public class MobileInput : BaseInput
    {
        public string TurnInputName = "Horizontal";
        public string AccelerateButtonName = "Accelerate";
        public string BrakeButtonName = "Brake";

        public override InputData GenerateInput()
        {
            bool breaking = IsBreaking();
            Input.gyro.enabled = true;
            return new InputData
            {
                Accelerate = breaking ? false : IsAccelerating(),
                Brake = breaking,
                TurnInput = -Input.gyro.attitude.x * 5.0f
            };
        }

        bool IsBreaking()
        {
            foreach (Touch touch in Input.touches)
            {
                if (touch.position.x < Screen.width / 2) return true;
            }
            return false;
        }

        bool IsAccelerating()
        {
            foreach (Touch touch in Input.touches)
            {
                if (touch.position.x > Screen.width / 2) return true;
            }
            return false;
        }
    }
}
