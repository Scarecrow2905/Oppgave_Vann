using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oppgave_Vann
{
    public class Water
    {
        public Water (int amount, int temperature, double? proportion = null)
        {

            Amount = amount;
            Temperature = temperature;
            State = temperature <= 0 ? WaterState.Ice : 
                    temperature > 100 ? WaterState.Gas :
                    WaterState.Fluid;

            if (Temperature != 100 && Temperature != 0) return;
            if (proportion == null)
            {
                throw new ArgumentException("When temperature is 0 or 100, you must provide a value for proportion");
            }

            ProportionFirstState = proportion.Value;

            if (ProportionFirstState == 1) return;
            if (ProportionFirstState == 0) State = temperature == 0 ? WaterState.Fluid : WaterState.Gas;
            else State = temperature == 0 ? WaterState.IceAndFluid : WaterState.FluidAndGas;

        }
        public WaterState State { get; set; }
        public int Amount { get; set; }
        public int Temperature { get; set; }
        public double ProportionFirstState { get; set; }
        
        public enum WaterState
        {
            Fluid, Ice, Gas, FluidAndGas, IceAndFluid
        }
    }
}
