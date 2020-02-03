using System;
using System.Collections.Generic;

public static class Intcode
{
    public static int indexPointer;

    public static char[] parameterMode = null;

    public static int systemIdIndex = 0;

    public static int CalculateOpcode(List<int> commandList, List<int> systemId)
    {
        while (true)
        {
            if (commandList[indexPointer] == 99)
            {
                return systemId[systemIdIndex];
            }

            int param1;
            int param2;
            switch (commandList[indexPointer])
            {
                case 1:
                    param1 = GetByIndex(commandList, indexPointer + 1, ParameterMode.Position);
                    param2 = GetByIndex(commandList, indexPointer + 2, ParameterMode.Position);
                    SetByIndex(commandList, indexPointer + 3, param1 + param2, ParameterMode.Position);
                    indexPointer += 4;
                    break;
                case 2:
                    param1 = GetByIndex(commandList, indexPointer + 1, ParameterMode.Position);
                    param2 = GetByIndex(commandList, indexPointer + 2, ParameterMode.Position);
                    SetByIndex(commandList, indexPointer + 3, param1 * param2, ParameterMode.Position);
                    indexPointer += 4;
                    break;
                case 3:
                    Console.WriteLine("idIndex:" + systemIdIndex);
                    SetByIndex(commandList, indexPointer + 1, systemId[systemIdIndex], ParameterMode.Position);
                    systemIdIndex += 1;
                    indexPointer += 2;
                    break;
                case 4:
                    systemId[systemIdIndex] = GetByIndex(commandList, indexPointer + 1, ParameterMode.Position);
                    indexPointer += 2;
                    break;
                case 5:
                    param1 = GetByIndex(commandList, indexPointer + 1, ParameterMode.Position);
                    if (!param1.Equals(0))
                    {
                        param2 = GetByIndex(commandList, indexPointer + 2, ParameterMode.Position);
                        indexPointer = param2;
                    }
                    else
                    {
                        indexPointer += 3;
                    }

                    break;
                case 6:
                    param1 = GetByIndex(commandList, indexPointer + 1, ParameterMode.Position);
                    if (param1.Equals(0))
                    {
                        param2 = GetByIndex(commandList, indexPointer + 2, ParameterMode.Position);
                        indexPointer = param2;
                    }
                    else
                    {
                        indexPointer += 3;
                    }

                    break;
                case 7:
                    param1 = GetByIndex(commandList, indexPointer + 1, ParameterMode.Position);
                    param2 = GetByIndex(commandList, indexPointer + 2, ParameterMode.Position);
                    if (param1 < param2)
                    {
                        SetByIndex(commandList, indexPointer + 3, 1, ParameterMode.Position);
                    }
                    else
                    {
                        SetByIndex(commandList, indexPointer + 3, 0, ParameterMode.Position);
                    }

                    indexPointer += 4;
                    break;
                case 8:
                    param1 = GetByIndex(commandList, indexPointer + 1, ParameterMode.Position);
                    param2 = GetByIndex(commandList, indexPointer + 2, ParameterMode.Position);
                    if (param1.Equals(param2))
                    {
                        SetByIndex(commandList, indexPointer + 3, 1, ParameterMode.Position);
                    }
                    else
                    {
                        SetByIndex(commandList, indexPointer + 3, 0, ParameterMode.Position);
                    }

                    indexPointer += 4;
                    break;
                default:
                    switch (commandList[indexPointer].ToString().Length)
                    {
                        case 2:
                            parameterMode = new char[5];
                            parameterMode[0] = Char.Parse("0");
                            parameterMode[1] = Char.Parse("0");
                            parameterMode[2] = Char.Parse("0");
                            for (int i = 3; i < 5; i++)
                            {
                                parameterMode[i] = commandList[indexPointer].ToString()[i - 3];
                            }

                            break;
                        case 3:
                        {
                            parameterMode = new char[5];
                            parameterMode[0] = Char.Parse("0");
                            parameterMode[1] = Char.Parse("0");
                            for (int i = 2; i < 5; i++)
                            {
                                parameterMode[i] = commandList[indexPointer].ToString()[i - 2];
                            }

                            break;
                        }
                        case 4:
                        {
                            parameterMode = new char[5];
                            parameterMode[0] = Char.Parse("0");
                            for (int i = 1; i < 5; i++)
                            {
                                parameterMode[i] = commandList[indexPointer].ToString()[i - 1];
                            }

                            break;
                        }
                        case 5:
                            parameterMode = commandList[indexPointer].ToString().ToCharArray();
                            break;
                        default:
                            Console.WriteLine("Parameter is longer than 5!!");
                            throw new ArgumentOutOfRangeException();
                    }

                    if (parameterMode == null)
                    {
                        Console.WriteLine("ParameterMode is null");
                        throw new NullReferenceException();
                    }

                    ParameterMode param1Mode;
                    ParameterMode param2Mode;
                    ParameterMode param3Mode;
                    switch (parameterMode[4].ToString())
                    {
                        case "1":
                            param1Mode = GetParameterModeOfItem(parameterMode, 2);
                            param2Mode = GetParameterModeOfItem(parameterMode, 1);
                            param3Mode = GetParameterModeOfItem(parameterMode, 0);
                            param1 = GetByIndex(commandList, indexPointer + 1, param1Mode);
                            param2 = GetByIndex(commandList, indexPointer + 2, param2Mode);
                            SetByIndex(commandList, indexPointer + 3, param1 + param2, param3Mode);
                            indexPointer += 4;
                            break;
                        case "2":
                            param1Mode = GetParameterModeOfItem(parameterMode, 2);
                            param2Mode = GetParameterModeOfItem(parameterMode, 1);
                            param3Mode = GetParameterModeOfItem(parameterMode, 0);
                            param1 = GetByIndex(commandList, indexPointer + 1, param1Mode);
                            param2 = GetByIndex(commandList, indexPointer + 2, param2Mode);
                            SetByIndex(commandList, indexPointer + 3, param1 * param2, param3Mode);
                            indexPointer += 4;
                            break;
                        case "3":
                            param1Mode = GetParameterModeOfItem(parameterMode, 2);
                            SetByIndex(commandList, indexPointer + 1, systemId[systemIdIndex], param1Mode);
                            systemIdIndex += 1;
                            indexPointer += 2;
                            break;
                        case "4":
                            param1Mode = GetParameterModeOfItem(parameterMode, 2);
                            systemId[systemIdIndex] = GetByIndex(commandList, indexPointer + 1, param1Mode);
                            indexPointer += 2;
                            break;
                        case "5":
                            param1Mode = GetParameterModeOfItem(parameterMode, 2);
                            param1 = GetByIndex(commandList, indexPointer + 1, param1Mode);
                            if (!param1.Equals(0))
                            {
                                param2Mode = GetParameterModeOfItem(parameterMode, 1);
                                param2 = GetByIndex(commandList, indexPointer + 2, param2Mode);
                                indexPointer = param2;
                            }
                            else
                            {
                                indexPointer += 3;
                            }

                            break;
                        case "6":
                            param1Mode = GetParameterModeOfItem(parameterMode, 2);
                            param1 = GetByIndex(commandList, indexPointer + 1, param1Mode);
                            if (param1.Equals(0))
                            {
                                param2Mode = GetParameterModeOfItem(parameterMode, 1);
                                param2 = GetByIndex(commandList, indexPointer + 2, param2Mode);
                                indexPointer = param2;
                            }
                            else
                            {
                                indexPointer += 3;
                            }

                            break;
                        case "7":
                            param1Mode = GetParameterModeOfItem(parameterMode, 2);
                            param2Mode = GetParameterModeOfItem(parameterMode, 1);
                            param3Mode = GetParameterModeOfItem(parameterMode, 0);
                            param1 = GetByIndex(commandList, indexPointer + 1, param1Mode);
                            param2 = GetByIndex(commandList, indexPointer + 2, param2Mode);
                            if (param1 < param2)
                            {
                                SetByIndex(commandList, indexPointer + 3, 1, param3Mode);
                            }
                            else
                            {
                                SetByIndex(commandList, indexPointer + 3, 0, param3Mode);
                            }

                            indexPointer += 4;
                            break;
                        case "8":
                            param1Mode = GetParameterModeOfItem(parameterMode, 2);
                            param2Mode = GetParameterModeOfItem(parameterMode, 1);
                            param3Mode = GetParameterModeOfItem(parameterMode, 0);
                            param1 = GetByIndex(commandList, indexPointer + 1, param1Mode);
                            param2 = GetByIndex(commandList, indexPointer + 2, param2Mode);
                            if (param1.Equals(param2))
                            {
                                SetByIndex(commandList, indexPointer + 3, 1, param3Mode);
                            }
                            else
                            {
                                SetByIndex(commandList, indexPointer + 3, 0, param3Mode);
                            }

                            indexPointer += 4;
                            break;
                        case "9":
                            return systemId[systemIdIndex];
                        default:
                            Console.WriteLine("Something is wrong!!");
                            break;
                    }

                    break;
            }
        }
    }

    public static int GetByIndex(List<int> commandList, int getIndex, ParameterMode mode)
    {
        switch (mode)
        {
            case ParameterMode.Position:
                return commandList[commandList[getIndex]];
            case ParameterMode.Immediate:
                return commandList[getIndex];
            default:
                Console.WriteLine("Parameter Mode of the item is wrong at " + getIndex.ToString());
                throw new ArgumentOutOfRangeException();
        }
    }

    public static void SetByIndex(List<int> commandList, int setIndex, int val, ParameterMode mode)
    {
        switch (mode)
        {
            case ParameterMode.Position:
                commandList[commandList[setIndex]] = val;
                break;
            case ParameterMode.Immediate:
                commandList[setIndex] = val;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(mode), mode, null);
        }
    }

    public static ParameterMode GetParameterModeOfItem(char[] parameter, int indexOfItem)
    {
        switch (parameter[indexOfItem].ToString())
        {
            case "0":
                return ParameterMode.Position;
            case "1":
                return ParameterMode.Immediate;
            default:
                Console.WriteLine("Could not find parameter of the item at" + indexOfItem);
                throw new ArgumentOutOfRangeException();
        }
    }
}