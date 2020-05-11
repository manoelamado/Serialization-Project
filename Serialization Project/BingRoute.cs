using System;
using System.Collections.Generic;
using System.Text;

namespace Serialization_Project
{
    class BingRoute
    {
        public string authenticationResultCode { get; set; }
        public string brandLogoUri { get; set; }
        public string copyright { get; set; }
        public List<RteResourceSet> resourceSets { get; set; }
    }

    public class RteResourceSet
    {
        public int estimatedTotal { get; set; }
        public List<RteResource> resources { get; set; }
    }

    public class RteResource
    {
        public string _type { get; set; }
        public string id { get; set; }
        public string distinceUnit { get; set; }
        public string durationUnit { get; set; }
        public List<RouteLeg> routeLegs { get; set; }
    }

    public class RouteLeg
    {
        public string description { get; set; }
        public List<ItineraryItem> itineraryItems { get; set; }
    }

    public class ItineraryItem
    {
        public string compassDirection { get; set; }

        public Point maneuverPoint { get; set; }
    }

    public class Point
    {
        public string type { get; set; }

        public List<double> coordinates { get; set; }
    }
}
