using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using System.Timers;
using System.Net.Http;
using System.IO;

namespace KeyAuth
{
    class anticrack
    {
        private static string PR;

        public static void Start()
        {
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 2000;
            timer.Elapsed += Call;
            timer.Start();
        }

        static void Call(object sender, ElapsedEventArgs e)
        {
            KeyAuth.anticrack.Shock();
        }

        public static void restart()
        {
            System.Diagnostics.Process.Start("shutdown.exe", "-r -t 0");
        }
        public static void Shock()
        {
            try
            {
                foreach (Process processt in Process.GetProcessesByName("Process Monitor"))
                {
                    processt.Kill();
                    PR = processt.ProcessName;

                    restart();
                    Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process processtt in Process.GetProcessesByName("Procmon64"))
                {
                    processtt.Kill();
                    PR = processtt.ProcessName;

                    restart();
                    Application.Exit();
                    Environment.Exit(0);
                }

                foreach (Process process57 in Process.GetProcessesByName("ProcessHacker"))
                {
                    process57.Kill();
                    PR = process57.ProcessName;

                    Application.Exit();
                    Environment.Exit(0);

                }
                foreach (Process process58 in Process.GetProcessesByName("Procmon"))
                {
                    process58.Kill();
                    PR = process58.ProcessName;
                    //API.log(Auth.appName, process58.ProcessName);

                    restart();
                    Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process59 in Process.GetProcessesByName("Procmon32"))
                {
                    process59.Kill();
                    PR = process59.ProcessName;
                    //API.log(Auth.appName, process59.ProcessName);

                    restart();
                    Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process processk in Process.GetProcessesByName("ProcMonX"))
                {
                    processk.Kill();
                    PR = processk.ProcessName;
                    //API.log(Auth.appName, processk.ProcessName);

                    restart();
                    Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process processkk in Process.GetProcessesByName("apimonitor-x86"))
                {
                    processkk.Kill();
                    PR = processkk.ProcessName;
                    //API.log(Auth.appName, processkk.ProcessName);

                    restart();
                    Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process processll in Process.GetProcessesByName("apimonitor-x64"))
                {
                    processll.Kill();
                    PR = processll.ProcessName;
                    //API.log(Auth.appName, processll.ProcessName);

                    restart();
                    Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process processmm in Process.GetProcessesByName("SpyStudio"))
                {
                    processmm.Kill();
                    PR = processmm.ProcessName;
                    //API.log(Auth.appName, processmm.ProcessName);

                    restart();
                    Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process processnn in Process.GetProcessesByName("x32dbg"))
                {
                    processnn.Kill();
                    PR = processnn.ProcessName;
                    //API.log(Auth.appName, processnn.ProcessName);

                    restart();
                    Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process processoo in Process.GetProcessesByName("x64dbg"))
                {
                    processoo.Kill();
                    PR = processoo.ProcessName;
                    //API.log(Auth.appName, processoo.ProcessName);

                    restart();
                    Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process processpp in Process.GetProcessesByName("dnSpy-x86"))
                {
                    processpp.Kill();
                    PR = processpp.ProcessName;
                    //API.log(Auth.appName, processpp.ProcessName);

                    restart();
                    Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process processqq in Process.GetProcessesByName("dnSpy-x64"))
                {
                    processqq.Kill();
                    PR = processqq.ProcessName;
                    //API.log(Auth.appName, processqq.ProcessName);

                    restart();
                    Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process processgg in Process.GetProcessesByName("ollydbg"))
                {
                    processgg.Kill();
                    PR = processgg.ProcessName;
                    //API.log(Auth.appName, processgg.ProcessName);

                    restart();
                    Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process2 in Process.GetProcessesByName("ida"))
                {
                    process2.Kill();
                    PR = process2.ProcessName;
                    //API.log(Auth.appName, process2.ProcessName);

                    restart();
                    Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process3 in Process.GetProcessesByName("ida64"))
                {
                    process3.Kill();
                    PR = process3.ProcessName;
                    //API.log(Auth.appName, process3.ProcessName);

                    restart();
                    Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process4 in Process.GetProcessesByName("idag"))
                {
                    process4.Kill();
                    PR = process4.ProcessName;
                    //API.log(Auth.appName, process4.ProcessName);

                    restart();
                    Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process5 in Process.GetProcessesByName("idag64"))
                {
                    process5.Kill();
                    PR = process5.ProcessName;
                    //API.log(Auth.appName, process5.ProcessName);

                    restart();
                    Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process6 in Process.GetProcessesByName("idaw"))
                {
                    process6.Kill();
                    PR = process6.ProcessName;
                    //API.log(Auth.appName, process6.ProcessName);

                    restart();
                    Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process7 in Process.GetProcessesByName("idaw64"))
                {
                    process7.Kill();
                    PR = process7.ProcessName;
                    //API.log(Auth.appName, process7.ProcessName);

                    restart();
                    Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process8 in Process.GetProcessesByName("idaq"))
                {
                    process8.Kill();
                    PR = process8.ProcessName;
                    //API.log(Auth.appName, process8.ProcessName);

                    restart();
                    Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process9 in Process.GetProcessesByName("idaq64"))
                {
                    process9.Kill();
                    PR = process9.ProcessName;
                    //API.log(Auth.appName, process9.ProcessName);

                    restart();
                    Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process10 in Process.GetProcessesByName("idau"))
                {
                    process10.Kill();
                    PR = process10.ProcessName;
                    //API.log(Auth.appName, process10.ProcessName);

                    restart();
                    Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process11 in Process.GetProcessesByName("idau64"))
                {
                    process11.Kill();
                    PR = process11.ProcessName;
                    //API.log(Auth.appName, process11.ProcessName);

                    restart();
                    Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process12 in Process.GetProcessesByName("scylla"))
                {
                    process12.Kill();
                    PR = process12.ProcessName;
                    //API.log(Auth.appName, process12.ProcessName);

                    restart();
                    Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process13 in Process.GetProcessesByName("scylla_x64"))
                {
                    process13.Kill();
                    PR = process13.ProcessName;
                    //API.log(Auth.appName, process13.ProcessName);

                    restart();
                    Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process14 in Process.GetProcessesByName("scylla_x86"))
                {
                    process14.Kill();
                    PR = process14.ProcessName;
                    //API.log(Auth.appName, process14.ProcessName);

                    restart();
                    Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process15 in Process.GetProcessesByName("protection_id"))
                {
                    process15.Kill();
                    PR = process15.ProcessName;
                    //API.log(Auth.appName, process15.ProcessName);

                    restart();
                    Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process16 in Process.GetProcessesByName("x64dbg"))
                {
                    process16.Kill();
                    PR = process16.ProcessName;
                    //API.log(Auth.appName, process16.ProcessName);

                    restart();
                    Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process17 in Process.GetProcessesByName("x32dbg"))
                {
                    process17.Kill();
                    PR = process17.ProcessName;
                    //API.log(Auth.appName, process17.ProcessName);

                    restart();
                    Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process18 in Process.GetProcessesByName("windbg"))
                {
                    process18.Kill();
                    PR = process18.ProcessName;
                    //API.log(Auth.appName, process18.ProcessName);

                    restart();
                    Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process19 in Process.GetProcessesByName("reshacker"))
                {
                    process19.Kill();
                    PR = process19.ProcessName;
                    //API.log(Auth.appName, process19.ProcessName);

                    restart();
                    Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process20 in Process.GetProcessesByName("ImportREC"))
                {
                    process20.Kill();
                    PR = process20.ProcessName;
                    //API.log(Auth.appName, process20.ProcessName);

                    restart();
                    Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process21 in Process.GetProcessesByName("IMMUNITYDEBUGGER"))
                {
                    process21.Kill();
                    PR = process21.ProcessName;
                    //API.log(Auth.appName, process21.ProcessName);

                    restart();
                    Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process22 in Process.GetProcessesByName("MegaDumper"))
                {
                    process22.Kill();
                    PR = process22.ProcessName;
                    //API.log(Auth.appName, process22.ProcessName);

                    restart();
                    Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process23 in Process.GetProcessesByName("OLLYDBG"))
                {
                    process23.Kill();
                    PR = process23.ProcessName;
                    //API.log(Auth.appName, process23.ProcessName);

                    restart();
                    Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process24 in Process.GetProcessesByName("ida"))
                {
                    process24.Kill();
                    PR = process24.ProcessName;
                    //API.log(Auth.appName, process24.ProcessName);

                    restart();
                    Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process25 in Process.GetProcessesByName("disassembly"))
                {
                    process25.Kill();
                    PR = process25.ProcessName;
                    //API.log(Auth.appName, process25.ProcessName);

                    restart();
                    Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process26 in Process.GetProcessesByName("scylla"))
                {
                    process26.Kill();
                    PR = process26.ProcessName;
                    //API.log(Auth.appName, process26.ProcessName);

                    restart();
                    Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process27 in Process.GetProcessesByName("Debug"))
                {
                    process27.Kill();
                    PR = process27.ProcessName;
                    //API.log(Auth.appName, process27.ProcessName);

                    restart();
                    Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process28 in Process.GetProcessesByName("[CPU"))
                {
                    process28.Kill();
                    PR = process28.ProcessName;
                    //API.log(Auth.appName, process28.ProcessName);

                    restart();
                    Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process29 in Process.GetProcessesByName("Immunity"))
                {
                    process29.Kill();
                    PR = process29.ProcessName;
                    //API.log(Auth.appName, process29.ProcessName);

                    restart();
                    Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process30 in Process.GetProcessesByName("WinDbg"))
                {
                    process30.Kill();
                    PR = process30.ProcessName;
                    //API.log(Auth.appName, process30.ProcessName);

                    restart();
                    Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process31 in Process.GetProcessesByName("x32dbg"))
                {
                    process31.Kill();
                    PR = process31.ProcessName;
                    //API.log(Auth.appName, process31.ProcessName);

                    restart();
                    Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process32 in Process.GetProcessesByName("x64dbg"))
                {
                    process32.Kill();
                    PR = process32.ProcessName;
                    //API.log(Auth.appName, process32.ProcessName);

                    restart();
                    Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process33 in Process.GetProcessesByName("Import reconstructor"))
                {
                    process33.Kill();
                    PR = process33.ProcessName;
                    //API.log(Auth.appName, process33.ProcessName);

                    restart();
                    Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process34 in Process.GetProcessesByName("MegaDumper"))
                {
                    process34.Kill();
                    PR = process34.ProcessName;
                    //API.log(Auth.appName, process34.ProcessName);

                    restart();
                    Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process35 in Process.GetProcessesByName("MegaDumper 1. by CodeCracker / SnD"))
                {
                    process35.Kill();
                    PR = process35.ProcessName;
                    //API.log(Auth.appName, process35.ProcessName);

                    restart();
                    Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process36 in Process.GetProcessesByName("codecracker"))
                {
                    process36.Kill();
                    PR = process36.ProcessName;
                    //API.log(Auth.appName, process36.ProcessName);

                    restart();
                    Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process37 in Process.GetProcessesByName("x32dbg"))
                {
                    process37.Kill();
                    PR = process37.ProcessName;
                    //API.log(Auth.appName, process37.ProcessName);

                    restart();
                    Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process38 in Process.GetProcessesByName("x64dbg"))
                {
                    process38.Kill();
                    PR = process38.ProcessName;
                    //API.log(Auth.appName, process38.ProcessName);

                    restart();
                    Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process39 in Process.GetProcessesByName("ollydbg"))
                {
                    process39.Kill();
                    PR = process39.ProcessName;
                    //API.log(Auth.appName, process39.ProcessName);

                    restart();
                    Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process40 in Process.GetProcessesByName("ida -"))
                {
                    process40.Kill();
                    PR = process40.ProcessName;
                    //API.log(Auth.appName, process40.ProcessName);

                    restart();
                    Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process41 in Process.GetProcessesByName("charles"))
                {
                    process41.Kill();
                    PR = process41.ProcessName;
                    //API.log(Auth.appName, process41.ProcessName);

                    restart();
                    Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process42 in Process.GetProcessesByName("dnspy"))
                {
                    process42.Kill();
                    PR = process42.ProcessName;
                    //API.log(Auth.appName, process42.ProcessName);

                    restart();
                    Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process43 in Process.GetProcessesByName("simpleassembly"))
                {
                    process43.Kill();
                    PR = process43.ProcessName;
                    //API.log(Auth.appName, process43.ProcessName);

                    restart();
                    Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process44 in Process.GetProcessesByName("peek"))
                {
                    process44.Kill();
                    PR = process44.ProcessName;
                    //API.log(Auth.appName, process44.ProcessName);

                    restart();
                    Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process45 in Process.GetProcessesByName("httpanalyzer"))
                {
                    process45.Kill();
                    PR = process45.ProcessName;
                    //API.log(Auth.appName, process45.ProcessName);

                    restart();
                    Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process46 in Process.GetProcessesByName("httpdebug"))
                {
                    process46.Kill();
                    PR = process46.ProcessName;
                    //API.log(Auth.appName, process46.ProcessName);

                    restart();
                    Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process47 in Process.GetProcessesByName("fiddler"))
                {
                    process47.Kill();
                    PR = process47.ProcessName;
                    //API.log(Auth.appName, process47.ProcessName);

                    restart();
                    Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process48 in Process.GetProcessesByName("wireshark"))
                {
                    process48.Kill();
                    PR = process48.ProcessName;
                    //API.log(Auth.appName, process48.ProcessName);

                    restart();
                    Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process49 in Process.GetProcessesByName("dbx"))
                {
                    process49.Kill();
                    PR = process49.ProcessName;
                    //API.log(Auth.appName, process49.ProcessName);

                    restart();
                    Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process50 in Process.GetProcessesByName("mdbg"))
                {
                    process50.Kill();
                    PR = process50.ProcessName;
                    //API.log(Auth.appName, process50.ProcessName);

                    restart();
                    Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process51 in Process.GetProcessesByName("gdb"))
                {
                    process51.Kill();
                    PR = process51.ProcessName;
                    //API.log(Auth.appName, process51.ProcessName);

                    restart();
                    Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process52 in Process.GetProcessesByName("windbg"))
                {
                    process52.Kill();
                    PR = process52.ProcessName;
                    //API.log(Auth.appName, process52.ProcessName);

                    restart();
                    Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process53 in Process.GetProcessesByName("dbgclr"))
                {
                    process53.Kill();
                    PR = process53.ProcessName;
                    //API.log(Auth.appName, process53.ProcessName);

                    restart();
                    Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process54 in Process.GetProcessesByName("kdb"))
                {
                    process54.Kill();
                    PR = process54.ProcessName;
                    //API.log(Auth.appName, process54.ProcessName);

                    restart();
                    Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process55 in Process.GetProcessesByName("kgdb"))
                {
                    process55.Kill();
                    PR = process55.ProcessName;
                    //API.log(Auth.appName, process55.ProcessName);

                    restart();
                    Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process56 in Process.GetProcessesByName("mdb"))
                {
                    process56.Kill();
                    PR = process56.ProcessName;
                    //API.log(Auth.appName, process56.ProcessName);

                    restart();
                    Application.Exit();
                    Environment.Exit(0);
                }

                foreach (Process process68 in Process.GetProcessesByName("Reflector"))
                {
                    process68.Kill();
                    PR = process68.ProcessName;
                    //API.log(Auth.appName, process68.ProcessName);

                    restart();
                    Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process69 in Process.GetProcessesByName("ida"))
                {
                    process69.Kill();
                    PR = process69.ProcessName;
                    //API.log(Auth.appName, process69.ProcessName);

                    restart();
                    Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process70 in Process.GetProcessesByName("Black_Olly"))
                {
                    process70.Kill();
                    PR = process70.ProcessName;
                    //API.log(Auth.appName, process70.ProcessName);

                    restart();
                    Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process71 in Process.GetProcessesByName("OLLYDBG"))
                {
                    process71.Kill();
                    PR = process71.ProcessName;
                    //API.log(Auth.appName, process71.ProcessName);

                    restart();
                    Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process72 in Process.GetProcessesByName("BladeAPIMonitor"))
                {
                    process72.Kill();
                    PR = process72.ProcessName;
                    //API.log(Auth.appName, process72.ProcessName);

                    restart();
                    Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process73 in Process.GetProcessesByName("ProcMonX"))
                {
                    process73.Kill();
                    PR = process73.ProcessName;
                    //API.log(Auth.appName, process73.ProcessName);

                    restart();
                    Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process74 in Process.GetProcessesByName("Wireshark"))
                {
                    process74.Kill();
                    PR = process74.ProcessName;
                    //API.log(Auth.appName, process74.ProcessName);

                    restart();
                    Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process75 in Process.GetProcessesByName("ProcessActivityView"))
                {
                    process75.Kill();
                    PR = process75.ProcessName;
                    //API.log(Auth.appName, process80.ProcessName);

                    restart();
                    Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process76 in Process.GetProcessesByName("ranko"))
                {
                    process76.Kill();
                    PR = process76.ProcessName;
                    //API.log(Auth.appName, process79.ProcessName);

                    restart();
                    Application.Exit();
                    Environment.Exit(0);
                }

            }
            catch (Exception)
            {

            }
        }
    }
}
