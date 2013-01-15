using System;
using System.Collections.Generic;

namespace nRage.Contract.Tvrage
{
    [Serializable]
    public class ShowInfoResponse
    {

        /// <summary>
        /// Tvrage.com show Id
        /// </summary>
        public int ShowId { get; set; }

        /// <summary>
        /// Show name
        /// </summary>
        public string ShowName { get; set; }

        /// <summary>
        /// Tvrage.com URL for show info
        /// </summary>
        public string ShowLink { get; set; }        

        /// <summary>
        /// Number of seasons currently produced
        /// </summary>
        public string Seasons { get; set; }

        /// <summary>
        /// Year that the show commenced airing (YYYY)
        /// </summary>
        public string Started { get; set; }

        /// <summary>
        /// The date that the show commenced airing
        /// </summary>
        public string StartDate {get;set;}

        /// <summary>
        /// Year that the show was canceled (YYYY || na?)
        /// </summary>
        public string Ended { get; set; }

        /// <summary>
        /// 2-character code for show's country of origin/production
        /// </summary>
        public string OriginCountry { get; set; }        

        /// <summary>
        /// Current status of the show
        /// </summary>
        /// <example>"Canceled/Ended"</example>
        public string Status { get; set; }

        /// <summary>
        /// Don't care
        /// </summary>
        /// <example>"Scripted"</example>
        public string Classification { get; set; }

        /// <summary>
        /// List of genres
        /// </summary>
        /// <example>"Action"</example>
        /// <example>"Adventure"</example>
        /// <example>"Comedy"</example>
        public ICollection<string> Genres { get; set; }

        public string RunTime{get;set;}

        /// <summary>
        /// Which network the show aired on
        /// </summary>
        /// <todo>
        /// * Support multiple networks
        /// * Support Country attribute
        /// </todo>
        public string Network{get;set;}

        public string AirTime {get;set;}

        public string AirDay{get;set;}

        public string TimeZone{get;set;}
    }
}
