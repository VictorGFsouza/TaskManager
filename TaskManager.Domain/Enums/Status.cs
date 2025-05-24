using System.ComponentModel.DataAnnotations;

namespace TaskManager.Domain.Enums
{
    public enum Status
    {
        [Display(Name = "Pendente")]
        Pendente = 1,

        [Display(Name = "Em progresso")]
        EmProgresso = 2,

        [Display(Name = "Concluída")]
        Concluida = 3
    }
}
