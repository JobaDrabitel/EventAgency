namespace WpfApp5.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Activity")]
    public partial class Activity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [StringLength(250)]
        public string ActivityName { get; set; }

        public int? DayNumber { get; set; }

        public TimeSpan? StartTime { get; set; }

        public int? ModeratorId { get; set; }

        public int? Judge1Id { get; set; }

        public int? Judge2Id { get; set; }

        public int? Judge3Id { get; set; }

        public int? Judge4Id { get; set; }

        public int? Judge5Id { get; set; }

        public int? WinnerId { get; set; }

        public int? EventId { get; set; }

        public virtual Event Event { get; set; }

        public virtual User User { get; set; }

        public virtual User User1 { get; set; }

        public virtual User User2 { get; set; }

        public virtual User User3 { get; set; }

        public virtual User User4 { get; set; }

        public virtual User User5 { get; set; }

        public virtual User User6 { get; set; }
    }
}
