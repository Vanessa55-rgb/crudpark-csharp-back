using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudPark.Models
{
    public enum TicketType { Guest = 0, Monthly = 1 }

    public class Ticket
    {
        public int Id { get; set; }
        [Required]
        public string Folio { get; set; }
        [Required]
        public string Plate { get; set; }
        public TicketType Type { get; set; }
        public DateTime EntryAt { get; set; }
        public DateTime? ExitAt { get; set; }
        public int? OperatorId { get; set; }
        public bool Paid { get; set; }
        public decimal? Amount { get; set; }

        [NotMapped]
        public long EntryUnix => new DateTimeOffset(EntryAt).ToUnixTimeSeconds();

        public string GetQrPayload() => $"TICKET:{Folio}|PLATE:{Plate}|DATE:{EntryUnix}";
    }
}