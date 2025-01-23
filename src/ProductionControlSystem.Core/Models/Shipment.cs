namespace ProductionControlSystem.Core.Models
    {
    public class Shipment
        {
        public int Id { get; set; }
        public DateTime ReceivedAt { get; set; }
        public bool IsUrgent { get; set; }

        public int ProjectId { get; set; }
        public Project Project { get; set; } = default!;

        public ICollection<Box> Boxes { get; set; } = new List<Box>();
        }
    }

