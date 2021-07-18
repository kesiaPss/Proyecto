using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.CitasMedicas
{
    public class MedicosBL
    {
        Contexto _contexto;
        public BindingList<Medico> ListaMedicos { get; set; }

        public MedicosBL()
        {
            _contexto = new Contexto();
            ListaMedicos = new BindingList<Medico>();
        }

        public BindingList<Medico> ObtenerMedicos()
        {

            _contexto.Medicos.Load();
            ListaMedicos = _contexto.Medicos.Local.ToBindingList();
            return ListaMedicos;
        }
    }
    public class Medico
    {
        public int Id { get; set; }
        public string Descripcion  { get; set; }
    }
}
