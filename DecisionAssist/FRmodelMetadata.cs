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
    [XmlRoot("FunctionalRequirement")]
    
    public class FRmodelMetadata
    {
        
        [XmlElement("FR_name")]
        public string FR_name{ get; set; }

        [XmlElement("FR_description")]
        public string FR_desc { get; set; }

        [XmlElement("concategory_type")]
        public string c_type { get; set; }

        public int Project_id { get; set; }
        






    }
    [MetadataType(typeof(FRmodelMetadata))]
    public partial class FunctReq
    {

    }
  
}
