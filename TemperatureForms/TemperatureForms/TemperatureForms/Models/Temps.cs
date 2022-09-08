namespace TemperatureForms.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    class Temps
    {
        public string Celsius { get; set; }
        public string Far { get; set; }

        public Temps (string celsius, string far)
        {
            this.Celsius = celsius;
            this.Far = far;
        }

        /*
        public override string ToString()
        {
            return celsius+" "+far;
        }
        */

    }
}
