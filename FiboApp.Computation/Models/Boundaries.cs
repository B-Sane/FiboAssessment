using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace FiboApp.Computation.Models
{
    public class Boundaries
    {
        /// <summary>
        /// The required fibonacci lower boundary.
        /// </summary>
        [Required]
        [JsonProperty(PropertyName = "Start")]
        public uint Start { get; set; }  

        /// <summary>
        /// The required upper fibonacci boundary.
        /// </summary>
        [Required]
        [JsonProperty(PropertyName = "End")]
        public uint End { get; set; }   
    }
}
