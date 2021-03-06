﻿using System;
using System.Collections.Generic;
using System.Linq;
using WebPixPrincipalRepository.Entity;

namespace WebPixPrincipalRepository
{
    public class UsuarioDAO
    {
        public static Usuario Save(Usuario obj)
        {
            obj.DataCriacao = DateTime.Now;
            obj.DateAlteracao = DateTime.Now;
            try
            {
                if (obj.ID == 0)
                {
                    using (var db = new WebPixContext())
                    {
                        db.Usuario.Add(obj);
                        db.SaveChanges();
                        return obj;
                    }
                }
                else
                {
                    obj.DateAlteracao = DateTime.Now;
                    using (var db = new WebPixContext())
                    {
                        db.Usuario.Update(obj);
                        db.SaveChanges();
                        return obj;
                    }
                }
            }
            catch (Exception e)
            {
                return new Usuario();
            }
        }
        public static List<Usuario> GetAll()
        {
            try
            {
                using (var db = new WebPixContext())
                {
                    return db.Usuario.Where(x => x.Ativo == true).ToList();
                }
            }
            catch (Exception e)
            {
                return new List<Usuario>();
            }

        }
        public static bool Remove(Usuario obj)
        {
            try
            {
                using (var db = new WebPixContext())
                {
                    db.Usuario.Remove(obj);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                ////
                return false;
            }

        }

        public static Usuario GetById(int idCliente, int id)
        {
            try
            {
                using (var db = new WebPixContext())
                {
                    var user = db.Usuario.Where(x => x.idCliente.Equals(idCliente) && x.ID.Equals(id)).SingleOrDefault();
                    return user;
                }
            }
            catch (Exception e)
            {
                return new Usuario();
            }
        }

        public static IEnumerable<Usuario> GetByIds(int idCliente, IEnumerable<int> ids)
        {
            try
            {
                using (var db = new WebPixContext())
                {
                    var users = db.Usuario.Where(x => x.idCliente.Equals(idCliente) && ids.Contains(x.ID));
                    return users.ToList();
                }
            }
            catch (Exception e)
            {
                return new List<Usuario>();
            }
        }

        public static Usuario GetUsuario(string login, string senha, int idCliente)
        {
            try
            {
                using (var db = new WebPixContext())
                {
                    var users = db.Usuario.Where(x => x.idCliente.Equals(idCliente) && x.Login.Equals(login) && x.Senha.Equals(senha));
                    return users.FirstOrDefault();
                }
            }
            catch (Exception e)
            {
                return new Usuario();
            }
        }
    }
}
