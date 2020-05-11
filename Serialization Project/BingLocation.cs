using System;
using System.Collections.Generic;
using System.Text;

namespace Serialization_Project
{
    public class BingLocation
    {
        public string authenticationResultCode { get; set; }
        public string brandLogoUri { get; set; }
        public string copyright { get; set; }
        public List<ResourceSet> resourceSets { get; set; }
    }

    public class ResourceSet
    {
        public int estimatedTotal { get; set; }
        public List<ResourceClass> resources { get; set; }
    }

    public class ResourceClass
    {
        public string name { get; set; }
        public string confidence { get; set; }
        public string entityType { get; set; }

    }
}
