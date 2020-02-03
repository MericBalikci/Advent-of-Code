using System;
using System.Linq;
using System.Collections.Generic;

/// <summary>
/// ----- IntCode V2 -----
/// Upgraded version of the intcode.
/// </summary>
public static class IntCode_V2
{
    #region Fields

    public static List<long> CurrentProgram = new List<long>(1000);
    public static Queue<long> SystemId = new Queue<long>();
    private static List<long> Output = new List<long>();
    private static int IndexPointer = 0;
    private static int RelativeBase = 0;

    private static List<long> Saved_Program;
    private static Queue<long> Saved_SystemId;
    private static List<long> Saved_Output;
    private static int Saved_IndexPointer;
    private static int Saved_RelativeBase;

    #endregion
    
    #region Methods

    public static long Run(List<long> Program)
    {
        CurrentProgram = Program;
        IndexPointer = 0;
        while (true)
        {
            Console.WriteLine("IndexPointer: " + IndexPointer);
            char[] opcode = ProcessOpcode(Program[(int) IndexPointer]);
            if (new string(opcode, 3, 2) == "99")
            {
                Console.WriteLine("In the 99");
                long output = Output.Last();
                IndexPointer = -1;
                SaveMemory();
                return output;
            }

            long FirstParameter;
            long SecondParameter;
            switch (new string(opcode, 3, 2))
            {
                case "01":
                    FirstParameter = GetByIndex(IndexPointer + 1, GetMode(opcode, 2));
                    SecondParameter = GetByIndex(IndexPointer + 2, GetMode(opcode, 1));
                    SetByIndex(IndexPointer + 3, FirstParameter + SecondParameter, GetMode(opcode, 0));
                    IndexPointer += 4;
                    break;
                case "02":
                    FirstParameter = GetByIndex(IndexPointer + 1, GetMode(opcode, 2));
                    SecondParameter = GetByIndex(IndexPointer + 2, GetMode(opcode, 1));
                    SetByIndex(IndexPointer + 3, FirstParameter * SecondParameter, GetMode(opcode, 0));
                    IndexPointer += 4;
                    break;
                case "03":
                    SetByIndex(IndexPointer + 1, SystemId.First(), GetMode(opcode, 2));
                    SystemId.Dequeue();
                    IndexPointer += 2;
                    break;
                case "04":
                    Output.Add(GetByIndex(IndexPointer + 1, GetMode(opcode, 2)));
                    IndexPointer += 2;
                    SaveMemory();
                    return Output.Last();
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
                        SetByIndex(IndexPointer + 3, 1, GetMode(opcode, 0));
                    }
                    else
                    {
                        SetByIndex(IndexPointer + 3, 0, GetMode(opcode, 0));
                    }

                    IndexPointer += 4;
                    break;
                case "08":
                    FirstParameter = GetByIndex(IndexPointer + 1, GetMode(opcode, 2));
                    SecondParameter = GetByIndex(IndexPointer + 2, GetMode(opcode, 1));
                    if (FirstParameter.Equals(SecondParameter))
                    {
                        SetByIndex(IndexPointer + 3, 1, GetMode(opcode, 0));
                    }
                    else
                    {
                        SetByIndex(IndexPointer + 3, 0, GetMode(opcode, 0));
                    }

                    IndexPointer += 4;
                    break;
                case "09":
                    RelativeBase += (int) GetByIndex(IndexPointer + 1, GetMode(opcode, 2));
                    IndexPointer += 2;
                    break;
                default:
                    Console.WriteLine("opcode is out of range!");
                    throw new ArgumentOutOfRangeException(nameof(opcode), opcode, "Opcode is OutOfRange");
            }
        }
    }

    private static ParameterMode GetMode(char[] parameterContainer, int index)
    {
        switch (new string(parameterContainer, index, 1))
        {
            case "0":
                return ParameterMode.Position;
            case "1":
                return ParameterMode.Immediate;
            case "2":
                return ParameterMode.Relative;
            default:
                throw new ArgumentOutOfRangeException(nameof(parameterContainer), parameterContainer,
                    "Parameter mode of the item at index of" + index + "in " + parameterContainer +
                    "could not be found!!");
        }
    }

    private static long GetByIndex(int index, ParameterMode mode)
    {
        int temp;
        switch (mode)
        {
            case ParameterMode.Position:
                temp = (int) CurrentProgram[index];
                return CurrentProgram[temp];
            case ParameterMode.Immediate:
                return CurrentProgram[index];
            case ParameterMode.Relative:
                temp = (int) CurrentProgram[index] + RelativeBase;
                return CurrentProgram[temp];
            default:
                throw new ArgumentOutOfRangeException(nameof(mode), mode, null);
        }
    }

    private static void SetByIndex(int index, long val, ParameterMode mode)
    {
        switch (mode)
        {
            case ParameterMode.Position:
                int tempIndex = (int) CurrentProgram[index];
                Console.WriteLine(index + "   " + tempIndex + "  " + CurrentProgram.Count);
                if (CurrentProgram.Count >= tempIndex)
                {
                    CurrentProgram[tempIndex] = val;
                }
                else
                {
                    CurrentProgram.Insert(tempIndex, val);
                }

                break;
            case ParameterMode.Immediate:
                CurrentProgram[index] = val;
                break;
            case ParameterMode.Relative:
                CurrentProgram[(int) CurrentProgram[(int) index] + (int) RelativeBase] = val;
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
            OpcodeProcessed[OpcodeProcessed.Length - OpcodeString.Length + i] = OpcodeString[i];
        }

        return OpcodeProcessed;
    }

    public static void ClearMemory()
    {
        IndexPointer = 0;
        RelativeBase = 0;
        CurrentProgram = null;
        SystemId = null;
        Output = null;
    }

    public static void SaveMemory()
    {
        Saved_Program = CurrentProgram;
        Saved_SystemId = SystemId;
        Saved_IndexPointer = IndexPointer;
        Saved_Output = Output;
        Saved_RelativeBase = RelativeBase;
    }

    public static void LoadMemory()
    {
        IndexPointer = Saved_IndexPointer;
        RelativeBase = Saved_RelativeBase;
        CurrentProgram = Saved_Program;
        SystemId = Saved_SystemId;
        Output = Saved_Output;
    }

    #endregion
}