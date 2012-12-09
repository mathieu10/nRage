using System;
using System.Collections.Generic;


namespace nRage.Contract.TVRage
{
    [Serializable]
    public class ShowInfoResult
    {

        /// <summary>
        /// TVRage.com show ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Show name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// TVRage.com URL for show info
        /// </summary>
        public string Link { get; set; }

        /// <summary>
        /// 2-character code for show's country of origin/production
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Year that the show commenced (YYYY)
        /// </summary>
        public string Started { get; set; }

        /// <summary>
        /// Year that the show was canceled (YYYY || na?)
        /// </summary>
        public string Ended { get; set; }

        /// <summary>
        /// Number of seasons currently produced
        /// </summary>
        public string Seasons { get; set; }

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
    }
}
