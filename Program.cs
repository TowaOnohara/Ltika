using System;
using System.Collections;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Presentation;
using Microsoft.SPOT.Presentation.Controls;
using Microsoft.SPOT.Presentation.Media;
using Microsoft.SPOT.Presentation.Shapes;
using Microsoft.SPOT.Touch;

using Gadgeteer.Networking;
using GT = Gadgeteer;
using GTM = Gadgeteer.Modules;
using Gadgeteer.Modules.GHIElectronics;

namespace Ltika
{
    public partial class Program
    {
        // This method is run when the mainboard is powered up or reset.   
        void ProgramStarted()
        {
            Debug.Print("Program Started");

            GT.Timer timer = new GT.Timer(500); // every second (500ms)
            timer.Tick += timer_Tick;
            timer.Start();
        }

        bool value = false;
        int ledval = 0;
        void timer_Tick(GT.Timer timer)
        {
            Mainboard.SetDebugLED(value = !value);
            ledval = (ledval++) % 6 + 1;
            led7R.TurnLightOn(ledval, true);
        }
    }
}
