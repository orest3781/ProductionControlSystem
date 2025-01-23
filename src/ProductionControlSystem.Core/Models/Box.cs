namespace ProductionControlSystem.Core.Models
    {
    public class Box
        {
        public int Id { get; set; }
        public string BoxCode { get; set; } = default!; // e.g., "B000001"
        public string BoxType { get; set; } = "Standard";
        public string Status { get; set; } = "pending_check";

        public int ShipmentId { get; set; }
        public Shipment Shipment { get; set; } = default!;
        }
    }
