using System.Data.Entity;

namespace BL.CitasMedicas
{
    public class DatosdeInicio : CreateDatabaseIfNotExists<Contexto>
    {
        protected override void Seed(Contexto contexto)
        {
            var usuarioAdmin = new Usuario();
            usuarioAdmin.Nombre = "admin";
            usuarioAdmin.Contrasena = "123";

            contexto.Usuarios.Add(usuarioAdmin);

            var motivoCita1 = new MotivoCita();
            motivoCita1.Descripcion = "Consulta General";
            contexto.MotivoCitas.Add(motivoCita1);

            var motivoCita2 = new MotivoCita();
            motivoCita2.Descripcion = "Terapia ";
            contexto.MotivoCitas.Add(motivoCita2);

            var motivoCita3 = new MotivoCita();
            motivoCita2.Descripcion = "Problemas en la Piel";
            contexto.MotivoCitas.Add(motivoCita3);

            var medico1 = new Medico();
            medico1.Descripcion = "Mauricio Calderon - Doctor General";
            contexto.Medicos.Add(medico1);

            var medico2 = new Medico();
            medico2.Descripcion = "Paola Valencia - Psicologo";
            contexto.Medicos.Add(medico2);

            var medico3 = new Medico();
            medico3.Descripcion = "Megan Mendoza - Dermatologo";
            contexto.Medicos.Add(medico3);

            base.Seed(contexto);



        }
    }
}