﻿using System.Collections.Generic;

namespace nRage.Contract.Tvrage
{
    public class EpisodeListResultSeason
    {
        public string Number{get;set;}
        public List<EpisodeListResultEpisode> Episodes{get;set;}
    }
}