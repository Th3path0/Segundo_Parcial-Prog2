using Capa_Acceso_Datos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class N_cat
    {
        public D_cat objDato = new D_cat();
        public List<E_cat> ListarContactos(string Buscar)
        {
            return objDato.ListarContactos(Buscar);

        }
        public void InsertarCategoria(E_cat Contacto)
        {
            objDato.InsertarCont(Contacto);
        }
        public void EditandoCategoria(E_cat Contacto)
        {
            objDato.EditarCont(Contacto);
        }
        public void EliminandoCategoria(E_cat Contacto)
        {
            objDato.EliminarCont(Contacto);
        }


    }
}
