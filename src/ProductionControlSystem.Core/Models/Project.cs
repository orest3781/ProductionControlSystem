namespace ProductionControlSystem.Core.Models
    {
    public class Project
        {
        public int Id { get; set; }

        // e.g., P001
        public string ProjectCode { get; set; } = default!;
        public string Description { get; set; } = default!;

        public int ClientId { get; set; }
        public Client Client { get; set; } = default!;

        public ICollection<Shipment> Shipments { get; set; } = new List<Shipment>();
        }
    }
