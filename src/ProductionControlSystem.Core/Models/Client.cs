namespace ProductionControlSystem.Core.Models
    {
    public class Client
        {
        public int Id { get; set; }

        // e.g., C0001
        public string ClientCode { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = default!;
        public int TurnaroundHours { get; set; }

        // Relationship
        public ICollection<Project> Projects { get; set; } = new List<Project>();
        }
    }

