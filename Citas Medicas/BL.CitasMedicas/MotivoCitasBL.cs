using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.CitasMedicas
{
    public class MotivoCitasBL
    {
        Contexto _contexto;
        public BindingList<MotivoCita> ListaMotivoCitas { get; set; }

        public MotivoCitasBL()
        {
            _contexto = new Contexto();
            ListaMotivoCitas = new BindingList<MotivoCita>();
        }

        public BindingList<MotivoCita> ObtenerMotivoCitas()
        {

            _contexto.MotivoCitas.Load();
            ListaMotivoCitas = _contexto.MotivoCitas.Local.ToBindingList();
            return ListaMotivoCitas;
        }
    }
    public class MotivoCita
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
    }
}
