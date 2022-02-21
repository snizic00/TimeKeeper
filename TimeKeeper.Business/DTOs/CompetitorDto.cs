using System.Linq.Expressions;
using TimeKeeper.Domain.Models;

namespace TimeKeeper.Business.DTOs;

public class CompetitorDto
{
    public CompetitorDto(string name, ushort startNo, ushort? teamId, ushort? bicycleId)
    {
        Name = name;
        StartNo = startNo;
        TeamId = teamId;
        BicycleId = bicycleId;
    }

    public string Name { get; }
    public ushort StartNo { get; }
    public ushort? TeamId { get; }
    public ushort? BicycleId { get; }

}
