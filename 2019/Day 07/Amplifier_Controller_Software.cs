using System;
using System.Linq;
using AdventOfCode.Utils;
using System.Collections.Generic;

namespace AdventOfCode_2019
{
    public class Amplifier_Controller_Software
    {
        /// <summary>
        /// 
        /// </summary>
        public static Amplifier_Controller_Software currentSoftware;
        
        /// <summary>
        /// 
        /// </summary>
        private static List<long> possibleOutputs= new List<long>(); 
        
        /// <summary>
        /// Amplifier Controller Software
        /// </summary>
        private static List<long> ACS = new List<long>()
        {
            3,8,1001,8,10,8,105,1,0,0,21,46,63,76,97,118,199,280,361,442,99999,3,9,102,4,9,9,101,2,9,9,1002,9,5,9,101,4,9,9,102,2,9,9,4,9,99,3,9,101,5,9,9,102,3,9,9,101,3,9,9,4,9,99,3,9,1001,9,2,9,102,3,9,9,4,9,99,3,9,1002,9,5,9,101,4,9,9,1002,9,3,9,101,2,9,9,4,9,99,3,9,1002,9,5,9,101,3,9,9,1002,9,5,9,1001,9,5,9,4,9,99,3,9,102,2,9,9,4,9,3,9,1002,9,2,9,4,9,3,9,1002,9,2,9,4,9,3,9,1001,9,1,9,4,9,3,9,101,1,9,9,4,9,3,9,1001,9,1,9,4,9,3,9,1002,9,2,9,4,9,3,9,1001,9,2,9,4,9,3,9,102,2,9,9,4,9,3,9,102,2,9,9,4,9,99,3,9,1002,9,2,9,4,9,3,9,101,2,9,9,4,9,3,9,1001,9,1,9,4,9,3,9,101,2,9,9,4,9,3,9,102,2,9,9,4,9,3,9,1002,9,2,9,4,9,3,9,1002,9,2,9,4,9,3,9,101,2,9,9,4,9,3,9,1001,9,1,9,4,9,3,9,102,2,9,9,4,9,99,3,9,102,2,9,9,4,9,3,9,102,2,9,9,4,9,3,9,102,2,9,9,4,9,3,9,1001,9,2,9,4,9,3,9,101,1,9,9,4,9,3,9,101,2,9,9,4,9,3,9,102,2,9,9,4,9,3,9,102,2,9,9,4,9,3,9,1001,9,2,9,4,9,3,9,101,1,9,9,4,9,99,3,9,1002,9,2,9,4,9,3,9,102,2,9,9,4,9,3,9,1001,9,2,9,4,9,3,9,101,1,9,9,4,9,3,9,1001,9,1,9,4,9,3,9,1001,9,2,9,4,9,3,9,102,2,9,9,4,9,3,9,101,1,9,9,4,9,3,9,1001,9,1,9,4,9,3,9,101,2,9,9,4,9,99,3,9,101,1,9,9,4,9,3,9,1002,9,2,9,4,9,3,9,102,2,9,9,4,9,3,9,1002,9,2,9,4,9,3,9,102,2,9,9,4,9,3,9,101,1,9,9,4,9,3,9,101,2,9,9,4,9,3,9,1001,9,2,9,4,9,3,9,102,2,9,9,4,9,3,9,101,2,9,9,4,9,99
        };
        
        /// <summary>
        /// 
        /// </summary>
        public int PhaseSetting;
        
        /// <summary>
        /// 
        /// </summary>
        public List<long> Program;
        
        /// <summary>
        /// 
        /// </summary>
        public Queue<long> SystemId = new Queue<long>();
        
        /// <summary>
        /// 
        /// </summary>
        public long IndexPointer = 0;
        
        /// <summary>
        /// 
        /// </summary>
        public long Output;

        /// <summary>
        /// Constructor of the Amplifier Controller Software.
        /// </summary>
        /// <param name="phaseSetting">Phase setting of the Amplifier Controller Software.</param>
        /// <param name="program">Opcode sequence of the Amplifier Controller Software.</param>
        public Amplifier_Controller_Software(int phaseSetting, List<long> program)
        {
            this.PhaseSetting = phaseSetting;
            this.Program = program;
        }

        private static void RunFeedbackLoop(string phaseSettings)
        {
            String_Utils.GetPermutationOfString(phaseSettings, 0, 4);
            foreach (string str in String_Utils.PermutationOfString)
            {
                int phaseA = Int32.Parse(str[0].ToString());
                int phaseB = Int32.Parse(str[1].ToString());
                int phaseC = Int32.Parse(str[2].ToString());
                int phaseD = Int32.Parse(str[3].ToString());
                int phaseE = Int32.Parse(str[4].ToString());
                
                Amplifier_Controller_Software A = new Amplifier_Controller_Software(phaseA,ACS);
                Amplifier_Controller_Software B = new Amplifier_Controller_Software(phaseB,ACS);
                Amplifier_Controller_Software C = new Amplifier_Controller_Software(phaseC,ACS);
                Amplifier_Controller_Software D = new Amplifier_Controller_Software(phaseD,ACS);
                Amplifier_Controller_Software E = new Amplifier_Controller_Software(phaseE,ACS);
                
                A.SystemId.Enqueue(A.PhaseSetting);
                A.SystemId.Enqueue(0);
                B.SystemId.Enqueue(B.PhaseSetting);
                C.SystemId.Enqueue(C.PhaseSetting);
                D.SystemId.Enqueue(D.PhaseSetting);
                E.SystemId.Enqueue(E.PhaseSetting);
                
                while (!E.IndexPointer.Equals(-1))
                {
                    Amplifier_Controller_Software.currentSoftware = A;
                    IntCode_V2.LoadMemory();
                    A.Output = IntCode_V2.Run(A.Program);

                    B.SystemId.Enqueue(A.Output);
                    IntCode_V2.ClearMemory();
                    Amplifier_Controller_Software.currentSoftware = B;
                    IntCode_V2.LoadMemory();
                    B.Output = IntCode_V2.Run(B.Program);
                    
                    C.SystemId.Enqueue(B.Output);
                    IntCode_V2.ClearMemory();
                    Amplifier_Controller_Software.currentSoftware = C;
                    IntCode_V2.LoadMemory();
                    C.Output = IntCode_V2.Run(C.Program);
                    
                    D.SystemId.Enqueue(C.Output);
                    IntCode_V2.ClearMemory();
                    Amplifier_Controller_Software.currentSoftware = D;
                    IntCode_V2.LoadMemory();
                    D.Output = IntCode_V2.Run(D.Program);
                    
                    E.SystemId.Enqueue(D.Output);
                    IntCode_V2.ClearMemory();
                    Amplifier_Controller_Software.currentSoftware = E;
                    IntCode_V2.LoadMemory();
                    E.Output = IntCode_V2.Run(E.Program);

                    if (!E.IndexPointer.Equals(-1))
                    {
                        A.SystemId.Enqueue(E.Output);
                    }
                }
                possibleOutputs.Add(E.Output);
            }
            Console.WriteLine(possibleOutputs.Max());
        }
    }
}