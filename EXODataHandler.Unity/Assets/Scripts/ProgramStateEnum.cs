using System;

[Flags]
public enum ProgramStateEnum
{
    askingforfile = 0,
    selectDataToSort = 1,
    inDataSorter = 2,
    inSpecificInterface = 4
}
