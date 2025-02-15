﻿using MomBeatPvz.Core.Enums;
using MomBeatPvz.Core.Model;
using MomBeatPvz.Core.ModelUpdate;

namespace MomBeatPvz.Api.Contracts.Championship
{
    public record MatchUpdateRequestDto(
        long Id,
        Trackable<bool>? IsCompleted,
        Dictionary<long, double>? Results);
}
