using Registro.DAL;
using Registro.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Registro.BLL
{
    public class PersonasBll
    {
        ///Metodo guardar
        public static bool Guardar(Personas p)
        {
            bool paso = false;
            Contexto c = new Contexto();

            try
            {
                if (c.Personas.Add(p) != null)
                    paso = c.SaveChanges() > 0;
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                c.Dispose();
            }

            return paso;
        }///fin


        public static bool Modificar(Personas p)//modificar
        {
            bool paso = false;
            Contexto c = new Contexto();

            try
            {
                var Anterior = c.Personas.Find(p.PersonaID);
                foreach(var item in Anterior.Telefono)
                {
                    if (!p.Telefono.Exists(d => d.ID == item.ID))
                        c.Entry(item).State = EntityState.Deleted;
                }

                c.Entry(p).State = EntityState.Modified;
                paso = (c.SaveChanges() > 0);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                c.Dispose();
            }

            return paso;

        }//                            fin

        public static bool Eliminar(int id)//                    eliminar
        {
            bool paso = false;
            Contexto c = new Contexto();

            try
            {
                var eliminar = c.Personas.Find(id);
                c.Entry(eliminar).State = System.Data.Entity.EntityState.Deleted;

                paso = (c.SaveChanges() > 0);
            }
            catch
            {
                throw;
            }
            finally
            {
                c.Dispose();
            }

            return paso;
        }//                                  fin


        public static Personas Buscar(int id)//            buscar por id
        {
            Contexto c = new Contexto();
            Personas p = new Personas();

            try
            {
                p = c.Personas.Find(id);
                p.Telefono.Count();
            }
            catch
            {
                throw;
            }
            finally
            {
                c.Dispose();
            }

            return paso;
        }//                       fin

        public static List<Personas> GetList(Expression<Func<Personas,bool>> p) //               listar
        {
            List<Personas> lista = new List<Personas>();
            Contexto c = new Contexto();
            try
            {
                lista = c.Personas.Where(p).ToList();
            }
            catch
            {
                throw;
            }
            finally
            {
                c.Dispose();
            }

            return lista;
        }///                               fin
        
    }
}
