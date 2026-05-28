using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntornoGrafico
{
    public class ControladorPersona
    {
        private List<Persona> personaList;

        public ControladorPersona()
        {
            personaList = new List<Persona>();
        }

        public void AgregarPersona(Persona persona)
        {
            personaList.Add(persona);
        }

        public List<Persona> ObtenerPersonas()
        {
            return personaList;
        }

        public void EliminarPersona(Persona persona)
        {
            personaList.Remove(persona);
        }
    }
}
