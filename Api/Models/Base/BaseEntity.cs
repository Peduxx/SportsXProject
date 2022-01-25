using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VettaProject.Api.Models.Base
{
    //Entidade base para demais entidades a serem criadas no banco de dados.
    public class BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        public DateTime? DeletionDate { get; set; }
    }
}