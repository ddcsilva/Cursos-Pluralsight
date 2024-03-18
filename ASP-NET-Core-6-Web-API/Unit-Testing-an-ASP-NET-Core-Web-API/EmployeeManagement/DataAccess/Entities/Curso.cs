using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagement.DataAccess.Entities
{
    public class Curso
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public bool EhNovo { get; set; } = true;
        public string Title { get; set; }         
        public List<FuncionarioInterno> FuncionariosQueParticiparam { get; set; } 
            = new List<FuncionarioInterno>();

        public Curso(string title)
        {
            Title = title;
        }
    }
}
