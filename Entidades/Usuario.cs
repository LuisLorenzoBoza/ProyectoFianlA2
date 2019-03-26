﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
    public class Usuario
    {
        [Key]
        public int UsuarioId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public int Ordenes { get; set; }

        public Usuario()
        {
            UsuarioId = 0;
            Nombre = string.Empty;
            Apellido = string.Empty;
            Email = string.Empty;
            Ordenes = 0;
        }

        public Usuario(int usuarioId, string nombre, string apellido, string email, int ordenes)
        {
            UsuarioId = usuarioId;
            Nombre = nombre;
            Apellido = apellido;
            Email = email;
            Ordenes = ordenes;
        }
    }
}
