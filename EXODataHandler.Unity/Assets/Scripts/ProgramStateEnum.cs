using System;

[Flags]
public enum ProgramStateEnum
{
    askingforfile = 0,
    selectDataToSort = 1,
    inDatasorter = 2,
    inSpecificInterface = 4
}
