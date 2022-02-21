// CompetitorDetailsDto.cs
//
// © 2021 FESB. All rights reserved.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TimeKeeper.Business.Services.Enumerations;
using TimeKeeper.Domain.Models;

namespace TimeKeeper.Business.DTOs;

public class CompetitorDetailsDto
{
    private CompetitorDetailsDto()
    {
    }



    public int Id { get; private set; }
    public string Name { get; private set; }
    public ushort StartNo { get; private set; }
    public ushort? TeamId { get; private set; }
    public ushort? BicycleId { get; private set; }

    public static Expression<Func<Competitor,CompetitorDetailsDto>> Projection
    {
        get
        {
            return competitor => new CompetitorDetailsDto
            {
                Id = competitor.Id,
                Name = competitor.Name,
                StartNo = competitor.StartNo,
                TeamId = competitor.TeamId,
                BicycleId = competitor.BicycleId
            };
        }
    }




}






