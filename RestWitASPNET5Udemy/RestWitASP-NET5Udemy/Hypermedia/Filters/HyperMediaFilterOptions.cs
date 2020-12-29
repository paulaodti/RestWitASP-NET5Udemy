using RestWitASP_NET5Udemy.Hypermedia.Abstract;
using System.Collections.Generic;

namespace RestWitASP_NET5Udemy.Hypermedia.Filters
{
    public class HyperMediaFilterOptions
    {
        public List<IResponseEnricher> ContentResponseEnricherList { get; set; } = new List<IResponseEnricher>();
    }
}
