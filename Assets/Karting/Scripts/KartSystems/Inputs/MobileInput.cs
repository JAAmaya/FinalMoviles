using UnityEngine;

namespace KartGame.KartSystems
{

    public class MobileInput : BaseInput
    {
        public string TurnInputName = "Horizontal";
        public string AccelerateButtonName = "Accelerate";
        public string BrakeButtonName = "Brake";

        private void Awake()
        {
            //if (SystemInfo.supportsGyroscope)
            //{
            //    Input.gyro.enabled = true;
            //}
            //else Destroy(GetComponent<MobileInput>());
        }

        public override InputData GenerateInput()
        {
            Input.gyro.enabled = true;
            return new InputData
            {
                //Accelerate = breaking ? false : IsAccelerating(),
                Accelerate = IsAccelerating(),
                Brake = IsBraking(),
                //TurnInput = Input.gyro.attitude.x * 3.5f
                TurnInput = Input.acceleration.x *1.4f
            };
        }

        bool IsBraking()
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
