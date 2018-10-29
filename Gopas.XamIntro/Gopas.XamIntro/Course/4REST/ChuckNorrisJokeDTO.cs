using System;
using System.Collections.Generic;
using System.Text;

namespace Gopas.XamIntro.Course._4REST
{
    class ChuckNorrisJokeDTO
    {
        public List<string> category { get; set; }
        public string icon_url { get; set; }
        public string id { get; set; }
        public string url { get; set; }
        public string value { get; set; }
    }
}
