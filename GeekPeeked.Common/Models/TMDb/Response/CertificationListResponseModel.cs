using System.Collections.Generic;

namespace GeekPeeked.Common.Models.TMDb.Response.CertificationList
{
    public class ResponseModel
    {
        public Certifications certifications { get; set; }
    }
    public class US
    {
        public string certification { get; set; }
        public string meaning { get; set; }
        public int order { get; set; }
    }

    public class CA
    {
        public string certification { get; set; }
        public string meaning { get; set; }
        public int order { get; set; }
    }

    public class AU
    {
        public string certification { get; set; }
        public string meaning { get; set; }
        public int order { get; set; }
    }

    public class DE
    {
        public string certification { get; set; }
        public string meaning { get; set; }
        public int order { get; set; }
    }

    public class FR
    {
        public string certification { get; set; }
        public string meaning { get; set; }
        public int order { get; set; }
    }

    public class NZ
    {
        public string certification { get; set; }
        public string meaning { get; set; }
        public int order { get; set; }
    }

    public class IN
    {
        public string certification { get; set; }
        public string meaning { get; set; }
        public int order { get; set; }
    }

    public class GB
    {
        public string certification { get; set; }
        public string meaning { get; set; }
        public int order { get; set; }
    }

    public class NL
    {
        public string certification { get; set; }
        public string meaning { get; set; }
        public int order { get; set; }
    }

    public class BR
    {
        public string certification { get; set; }
        public string meaning { get; set; }
        public int order { get; set; }
    }

    public class FI
    {
        public string certification { get; set; }
        public string meaning { get; set; }
        public int order { get; set; }
    }

    public class BG
    {
        public string certification { get; set; }
        public string meaning { get; set; }
        public int order { get; set; }
    }

    public class E
    {
        public string certification { get; set; }
        public string meaning { get; set; }
        public int order { get; set; }
    }

    public class PH
    {
        public string certification { get; set; }
        public string meaning { get; set; }
        public int order { get; set; }
    }

    public class PT
    {
        public string certification { get; set; }
        public string meaning { get; set; }
        public int order { get; set; }
    }

    public class Certifications
    {
        public List<US> US { get; set; }
        public List<CA> CA { get; set; }
        public List<AU> AU { get; set; }
        public List<DE> DE { get; set; }
        public List<FR> FR { get; set; }
        public List<NZ> NZ { get; set; }
        public List<IN> IN { get; set; }
        public List<GB> GB { get; set; }
        public List<NL> NL { get; set; }
        public List<BR> BR { get; set; }
        public List<FI> FI { get; set; }
        public List<BG> BG { get; set; }
        public List<E> ES { get; set; }
        public List<PH> PH { get; set; }
        public List<PT> PT { get; set; }
    }
}