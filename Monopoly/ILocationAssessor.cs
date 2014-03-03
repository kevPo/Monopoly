using System;
namespace Monopoly
{
    public interface ILocationAssessor
    {
        Int32 GetAssesmentFor(String location, Int32 playerBalance);
    }
}
