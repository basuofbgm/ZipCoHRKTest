using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Zip.Backend.Data
{
  [Table("guest_book")]
  public class Guest
  {
    public Guid Id { get; set; }
    [Column("first_name")]
    public string FirstName { get; set; }
    [Column("last_name")]
    public string LastName { get; set; }
    public DateTime Created { get; set; }
  }
}
