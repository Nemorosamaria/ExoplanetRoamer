namespace ExoplanetRoamer.Models
{
    public class Planet
    {
        /// <summary>
        /// Stellar name most commonly used in the literature.
        /// </summary>
        public string pl_hostname { get; set; }
        /// <summary>
        /// Letter assigned to the planetary component of a planetary system.
        /// </summary>
        public string pl_letter { get; set; }
        /// <summary>
        /// Planet name most commonly used in the literature.
        /// </summary>
        public string pl_name { get; set; }
        /// <summary>
        /// Method by which the planet was first identified
        /// </summary>
        public string pl_discmethod { get; set; } // This could be enum / class
        /// <summary>
        /// Flag indicating whether the confirmation status of a planet has been questioned in the published literature (1=yes, 0=no) 
        /// </summary>
        public bool? pl_controvflag { get; set; }
        /// <summary>
        /// Number of planets in the planetary system.
        /// </summary>
        public int? pl_pnum { get; set; }
        /// <summary>
        /// Time the planet takes to make a complete orbit around the host star or system.
        /// </summary>
        public double? pl_orbper { get; set; }

        //public int OrbitalPeriodUpper { get; set; }
        //public int OrbitalPeriodLower { get; set; }
        //public int OrbitalPeriodLimitFlag { get; set; }
        //public int OrbitalPeriodReference { get; set; }

    }
}