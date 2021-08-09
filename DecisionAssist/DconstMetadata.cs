using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DecisionAssist
{

    [Serializable]
    [XmlRoot("Constraint")]
    class DconstMetadata
    {
       
            [XmlElement("id")]
            public int Dc_id { get; set; }

            [XmlElement("Dc_name")]
            public string FR_name { get; set; }

            [XmlElement("Dc_des")]
            public string FR_desc { get; set; }
            [XmlElement("pdc_id")]
            public int PDC_id { get; set; }
        }

        [MetadataType(typeof(DconstMetadata))]
        public partial class dc
        {

        }
}

