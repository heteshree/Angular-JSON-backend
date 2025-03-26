using System.Text.Json.Serialization;

namespace RoadConstruction.Models
{
    public class DataModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ObservationData> Datas { get; set; }
    }

    public class ObservationData
    {
        public string SamplingTime { get; set; }
        public List<Property> Properties { get; set; }
    }

    public class Property
    {
        public string Label { get; set; }
        public object Value { get; set; }
    }
}
