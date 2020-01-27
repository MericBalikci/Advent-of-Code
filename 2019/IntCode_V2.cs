using System;
using System.Linq;
using System.Collections.Generic;

namespace AdventOfCode_2019
{
    /// <summary>
    /// ----- IntCode V2 -----
    /// Upgraded version of the intcode.
    /// </summary>
    public static class IntCode_V2
    {
        public static List<long> Program = new List<long>(1000);
        public static Queue<long> SystemId = new Queue<long>();
        public static List<long> Output = new List<long>();
        public static int IndexPointer = 0;
        public static int RelativeBase = 0;
        
        public static List<long> Saved_Program;
        public static Queue<long> Saved_SystemId;
        public static List<long> Saved_Output;
        public static int Saved_IndexPointer;
        public static int Saved_RelativeBase;
        
        #region Methods
        public static long Run()
        {
            IndexPointer = 0;
            long FirstParameter;
            long SecondParameter;
            while (true)
            {
                Console.WriteLine("IndexPointer: " + IndexPointer);
                char[] opcode = ProcessOpcode(Program[(int)IndexPointer]);
                if (new string(opcode,3,2) == "99")
                {
                    Console.WriteLine("In the 99");
                    long output = Output.Last();
                    IndexPointer = -1;
                    SaveMemory();
                    return output;
                }
                switch (new string(opcode,3,2))
                {
                    case "01":
                        FirstParameter = GetByIndex(IndexPointer + 1, GetMode(opcode,2));
                        SecondParameter = GetByIndex(IndexPointer + 2, GetMode(opcode,1));
                        SetByIndex(IndexPointer+3,FirstParameter + SecondParameter,GetMode(opcode,0));
                        IndexPointer += 4; 
                        break;
                    case "02":
                        FirstParameter = GetByIndex(IndexPointer + 1, GetMode(opcode,2));
                        SecondParameter = GetByIndex(IndexPointer + 2, GetMode(opcode,1));
                        SetByIndex(IndexPointer+3,FirstParameter*SecondParameter,GetMode(opcode,0));
                        IndexPointer += 4;
                        break;
                    case "03":
                        SetByIndex(IndexPointer+1,SystemId.First(),GetMode(opcode, 2));
                        SystemId.Dequeue();
                        IndexPointer += 2;
                        break;
                    case "04":
                        Output.Add(GetByIndex(IndexPointer + 1, GetMode(opcode, 2)));
                        IndexPointer += 2;
                        SaveMemory();
                        return Output.Last();
                        Console.WriteLine(Output.Last());
                        break;
                    case "05":
                        FirstParameter = GetByIndex(IndexPointer + 1, GetMode(opcode, 2));
                        if (!FirstParameter.Equals(0))
                        {
                            IndexPointer = (int) GetByIndex(IndexPointer + 2, GetMode(opcode, 1));
                        }
                        else
                        {
                            IndexPointer += 3;
                        }
                        break;
                    case "06":
                        FirstParameter = GetByIndex(IndexPointer + 1, GetMode(opcode, 2));
                        if (FirstParameter.Equals(0))
                        {
                            IndexPointer = (int) GetByIndex(IndexPointer + 2, GetMode(opcode, 1));
                        }
                        else
                        {
                            IndexPointer += 3;
                        }
                        break;
                    case "07":
                        FirstParameter = GetByIndex(IndexPointer + 1, GetMode(opcode, 2));
                        SecondParameter = GetByIndex(IndexPointer + 2, GetMode(opcode, 1));
                        if (FirstParameter < SecondParameter)
                        {
                            SetByIndex(IndexPointer+3,1,GetMode(opcode,0));
                        }
                        else
                        {
                            SetByIndex(IndexPointer+3,0,GetMode(opcode,0));
                        }
                        IndexPointer += 4;
                        break;
                    case "08":
                        FirstParameter = GetByIndex(IndexPointer + 1, GetMode(opcode, 2));
                        SecondParameter = GetByIndex(IndexPointer + 2, GetMode(opcode, 1));
                        if (FirstParameter.Equals(SecondParameter))
                        {
                            SetByIndex(IndexPointer+3,1,GetMode(opcode,0));
                        }
                        else
                        {
                            SetByIndex(IndexPointer+3,0,GetMode(opcode,0));
                        }
                        IndexPointer += 4;
                        break;
                    case  "09":
                        RelativeBase += (int) GetByIndex(IndexPointer + 1, GetMode(opcode, 2));
                        IndexPointer += 2;
                        break;
                    default:
                        Console.WriteLine("opcode is out of range!");
                        throw new ArgumentOutOfRangeException(nameof(opcode),opcode,"Opcode is OutOfRange");
                }
            }
        }
        private static ParameterMode GetMode(char[] parameterContainer, int index)
        {
            switch (new string(parameterContainer,index,1))
            {
                case "0":
                    return ParameterMode.Position;
                case "1":
                    return ParameterMode.Immediate;
                case "2":
                    return ParameterMode.Relative;
                default:
                    throw new ArgumentOutOfRangeException(nameof(parameterContainer),parameterContainer, 
                        "Parameter mode of the item at index of"+index+"in " + parameterContainer+"could not be found!!");
            }
        }
        private static long GetByIndex(int index, ParameterMode mode)
        {
            int temp;
            switch (mode)
            {
                case ParameterMode.Position:
                    temp = (int) Program[index];
                    return Program[temp];
                case ParameterMode.Immediate:
                    return Program[index];
                case ParameterMode.Relative:
                    temp = (int) Program[index] + RelativeBase;
                    return Program[temp];
                default:
                    throw new ArgumentOutOfRangeException(nameof(mode), mode, null);
            }
        }
        private static void SetByIndex(int index, long val, ParameterMode mode)
        {
            switch (mode)
            {
                case ParameterMode.Position:
                    int tempIndex = (int) Program[index];
                    Console.WriteLine(index+"   "+tempIndex+"  " + Program.Count);
                    if (Program.Count >= tempIndex)
                    {
                        Program[tempIndex] = val;
                    }
                    else
                    {
                        Program.Insert(tempIndex,val);
                    }
                    break;
                case ParameterMode.Immediate:
                    Program[index] = val;
                    break;
                case ParameterMode.Relative:
                    Program[(int) Program[(int) index] + (int) RelativeBase] = val;
                    break;
                default:
                    Console.WriteLine("Parameter mode is not valid!");
                    throw new ArgumentOutOfRangeException(nameof(mode), mode, null);
            }
        }
        private static char[] ProcessOpcode(long Opcode)
        {
            string defaultOpcode = "00000";
            string OpcodeString = Opcode.ToString();
            char[] OpcodeProcessed = defaultOpcode.ToCharArray();
            for (int i = 0; i < OpcodeString.Length; i++)
            {
                OpcodeProcessed[OpcodeProcessed.Length - OpcodeString.Length + i ] = OpcodeString[i];
            }
            return OpcodeProcessed;
        }
        public static void ClearMemory()
        {
            IndexPointer = 0;
            RelativeBase = 0;
            Program = null;
            SystemId = null;
            Output = null;
        }
        public static void SaveMemory()
        {
            Saved_Program = Program;
            Saved_SystemId = SystemId;
            Saved_IndexPointer= IndexPointer;
            Saved_Output = Output;
            Saved_RelativeBase = RelativeBase;
        }
        public static void LoadMemory()
        {
            IndexPointer = Saved_IndexPointer;
            RelativeBase = Saved_RelativeBase;
            Program = Saved_Program;
            SystemId = Saved_SystemId;
            Output = Saved_Output;
        }
        #endregion
    }
}