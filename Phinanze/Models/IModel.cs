using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Phinanze.Models
{
    /// <summary>
    /// Model interface
    /// </summary>
    public interface IModel
    {
        [Key]
        int Id { get; } // Models that extend BaseRepository do not need to define Id as BaseRepository already contains definition for Id method.


    }
}
