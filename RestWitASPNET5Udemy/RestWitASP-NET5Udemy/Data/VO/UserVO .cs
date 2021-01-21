using RestWitASP_NET5Udemy.Hypermedia;
using RestWitASP_NET5Udemy.Hypermedia.Abstract;
using System;
using System.Collections.Generic;

namespace RestWitASP_NET5Udemy.Data.VO
{
    public class UserVO : ISupportsHyperMedia
    {
        public long Id { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string Gender { get; set; }

        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();
    }
}
