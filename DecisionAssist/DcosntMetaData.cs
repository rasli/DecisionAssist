using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DecisionAssist.Models
{
    [Serializable]
    [XmlRoot("Constraint")]
    class DcosntMetaData
    {
       // [XmlElement("id")]
//        public int Dc_id { get; set; }

        [XmlElement("Dc_name")]
        public string Dc_name { get; set; }

        [XmlElement("Dc_description")]
        public string Dc_des { get; set; }
      //  [XmlElement("pdc_id")]
        public int Project_id { get; set; }
    }

    [MetadataType(typeof(DcosntMetaData))]
    public partial class DConst
    {

    }

}
