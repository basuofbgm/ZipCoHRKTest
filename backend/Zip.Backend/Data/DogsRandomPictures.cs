using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Zip.Backend.Data
{
    [Table("dogs_randompictures")]
  public class DogsRandomPictures
  {
    [Key]
    public Guid Id { get; set; }
    [Column("filesizebytes")]
    public long FileSize { get; set; }
    [Column("picture_url")]
    public string Pictureurl { get; set; }
    public DateTime Created { get; set; }
  }
}
