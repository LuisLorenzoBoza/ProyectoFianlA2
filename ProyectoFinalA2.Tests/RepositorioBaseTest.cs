using System;
using BLL;
using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProyectoFinalA2.Tests
{
    [TestClass]
    public class RepositorioBaseTest
    {
        RepositorioBase<Usuarios> repositorio = new RepositorioBase<Usuarios>();
        Usuarios usuario = new Usuarios();

        [TestMethod]
        public void Guardar()
        {
            Assert.IsTrue(repositorio.Guardar(usuario));
        }

        [TestMethod]
        public void Buscar()
        {
            var usuario_var = repositorio.Buscar(1);

            Assert.IsNotNull(usuario_var);
        }

        [TestMethod]
        public void Modificar()
        {
            repositorio.Guardar(usuario);
            usuario.Nombre = "Prueba";
            Assert.IsTrue(repositorio.Modificar(usuario));
        }

        [TestMethod]
        public void Eliminar()
        {
            Assert.IsTrue(repositorio.Eliminar(1));
        }
    }
}
