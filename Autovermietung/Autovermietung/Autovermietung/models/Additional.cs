using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autovermietung.models
{
    public class Additional
    {
        public int Id { get; set; }
        public bool ChildSeat { get; set; }
        public bool Navigation { get; set; }
        public bool SkiRack { get; set; }
        public bool SnowChains { get; set; }
        public bool RoofRack { get; set; }
        public bool BikeRack { get; set; }

        public Additional() : this(false, false, false, false, false, false) { }

        public Additional(bool cs, bool navi, bool sr, bool sc, bool rr, bool br)
        {
            ChildSeat = cs; Navigation = navi; SkiRack = sr; SnowChains = sc; RoofRack = rr; BikeRack = br;
        }
        public override string ToString()
        {
            return $"ChildSeat: {ChildSeat}, Navigation: {Navigation}, SkiRack: {SkiRack}, SnowChains: {SnowChains}, " +
                $"RoofRack: {RoofRack}, BikeRack: {BikeRack}";
        }
    }
}
