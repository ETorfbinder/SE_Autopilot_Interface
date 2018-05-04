String remoteName = "CGD - Remote";
String dockingName = "CGD - Script: Autodock";
String timerPBbase1Name = "CGD - Timer: Autopilot B - Base";

IMyRemoteControl remote = null;
IMyProgrammableBlock docking = null;
IMyTimerBlock timerPBbase1 = null;

List<TerminalActionParameter> argsOut = new List<TerminalActionParameter>();

public void Main(string args)
{
    
    // Remote Control
    remote = GridTerminalSystem.GetBlockWithName(remoteName) as IMyRemoteControl;

    // Programmierbarer Block Docking
    docking = GridTerminalSystem.GetBlockWithName(dockingName) as IMyProgrammableBlock;

    // Timer für Autopilot-Programm B
    timerPBbase1 = GridTerminalSystem.GetBlockWithName(timerPBbase1Name) as IMyTimerBlock;

    if (remote.GetValue<bool>("AutoPilot") == true) {
        timerPBbase1.GetActionWithName("Start").Apply(timerPBbase1);
    } else
    {
        argsOut.Clear();
        argsOut.Add(TerminalActionParameter.Get("BASE1"));
        docking.ApplyAction("Run", argsOut);
        Echo("Executed script");
    }
}