using System;
namespace Monopoly
{
    public interface ILocationAssessor
    {
        MovementResult GetAssesmentFor(String location, Int32 playerBalance);
    }
}
