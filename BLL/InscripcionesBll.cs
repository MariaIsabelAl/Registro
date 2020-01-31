using System;
using System.Collections.Generic;
using System.Text;
using Registro.DAL;
using Registro.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Linq;

namespace Registro.BLL
{
    public class InscripcionesBll
    {
        public static bool GuardarInscripcion(Inscripciones inscripcione)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                if (contexto.Inscripciones.Add(inscripcione) != null)
                    paso = contexto.SaveChanges() > 0 && AfectarBalance(inscripcione);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }


        public static bool AfectarBalance(Inscripciones inscripciones)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Personas.Find(inscripciones.PersonaId).Balance += inscripciones.Balance;
                paso = contexto.SaveChanges() > 0;

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }

        public static bool AfectarBalanceModificar(Inscripciones inscripciones)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Personas.Find(inscripciones.PersonaId).Balance += inscripciones.Deposito;
                paso = contexto.SaveChanges() > 0;

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }

        public static bool ModificarInscripcion(Inscripciones inscripciones)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                if (inscripciones.Deposito > 0)
                {
                    contexto.Entry(inscripciones).State = EntityState.Modified;
                   paso = contexto.SaveChanges() > 0 && AfectarBalanceModificar(inscripciones);
                }
                else
                {
                    contexto.Entry(inscripciones).State = EntityState.Modified;
                    paso = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }

        public static bool EliminarInscripcion(int id, int PerosnasID)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Inscripciones.Find(id).Balance = 0;
                contexto.Personas.Find(PerosnasID).Balance = 0;
                paso = (contexto.SaveChanges() > 0);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        public static Inscripciones Buscar(int id)// buscar inscripcion
        {
            Inscripciones inscripciones = new Inscripciones();
            Contexto contexto = new Contexto();

            try
            {
                inscripciones = contexto.Inscripciones.Find(id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return inscripciones;
        }

        public static List<Inscripciones> GetList(Expression<Func<Inscripciones, bool>> inscripciones)//lista inscripciones
        {
            List<Inscripciones> Lista = new List<Inscripciones>();

            Contexto contexto = new Contexto();
            try
            {
                Lista = contexto.Inscripciones.Where(inscripciones).ToList();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return Lista;
        }
    }
}
