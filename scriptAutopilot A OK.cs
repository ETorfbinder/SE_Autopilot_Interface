//      ANLEITUNG

//      (1.)     Aufbau: 3 Programmierbare Blöcke, 1 Timerblock (3sek), 1 Remoteblock
//      (2.)    Isy's Docking Script in "Autodock"-Computer
//      (3.)    Autopilotprogramm A und B in Computer
//      (4.)    timerName setzen
//      (5.)    timer Wert nullen
//      (6.)    Timer auf Grid finden
//      (7.)    WAYPOINTS setzen/aktualisieren/neues if-else erstellen
//      (8.)    Timerblock auf 3sek. stellen und Autopilot B mit Argumenten setzen.
//      (9.)    Autopilot B bearbeiten
//      (10.)   Autopilot A mit Argument ausführen
//
//     ACHTUNG: Währen Scriptausführung nicht den Remoteblock belegen.



String remoteName = "CGD - Remote";
String timerPBbase1Name = "CGD - Timer: Autopilot B - Base";
// ADD TIMERNAME    ======================================================================== (4.)


IMyRemoteControl remote = null;
IMyTimerBlock timerPBbase1 = null;
// NULL TIMER WERT    ======================================================================== (5.)


public void Main(string args)
{

    // Remote Control
    remote = GridTerminalSystem.GetBlockWithName(remoteName) as IMyRemoteControl;

    // Timer für Autopilot-Programm B
    // ADD MORE TIMER BELOW    ======================================================================== (6.)
    timerPBbase1 = GridTerminalSystem.GetBlockWithName(timerPBbase1Name) as IMyTimerBlock;
    // ADD MORE TIMER ABOVE

    // Waypoints löschen
    remote.ClearWaypoints();

    if (args == "base1")
    {
        // ADD WAYPOINTS BELOW    ======================================================================== (7.)
        Vector3D base1_100_0 = new Vector3D(-56914.66, 22209.01, 790.65);
        remote.AddWaypoint(base1_100_0, "BASE1 100/0");
        // ADD WAYPOINTS ABOVE


        remote.SetAutoPilotEnabled(true);
        timerPBbase1.GetActionWithName("Start").Apply(timerPBbase1);
        Echo("Running route: base1");
    }

    else if (args == "mg1")
    {
        // ADD WAYPOINTS BELOW
        Vector3D mg1_100_0 = new Vector3D(-56533.1, 23362.46, 868.84);
        remote.AddWaypoint(mg1_100_0, "Mg1 100/0");
        // ADD WAYPOINTS ABOVE


        remote.SetAutoPilotEnabled(true);
        timerPBbase1.GetActionWithName("Start").Apply(timerPBbase1);
        Echo("Running route: mg1");
    }

    else
    {
        Echo("Error: route (Autopilot A)");
    };
}