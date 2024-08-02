using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Comun.Enums
{
    public enum RolEnum
    {
        Administrador,
        /*
         Refiere al Administrador General del Sistema (DUEÑO DE SISTEMA).
         */
        AdministradorGeneral,
        /*
         Refiere al Administrador General del Sistema (DUEÑO DE NEGOCIO).
         Es decir aquel que puede controlar TODO (CRUD):
            - Productos
            - Categorias
            - Marcas
            - Usuarios
            - Roles
         */

        AdministradorInterno,
        /*
         Refiere al Administrador Interno del Sistema (ENCARGADO DE NEGOCIO).
         Es decir aquel que puede controlar lo relacionado al Negocio (CRUD):
            - Productos
            - Categorias
            - Marcas.
         */

        UsuarioInterno,
        /*
         Refiere al Usuario Interno del Sistema (EMPLEADO DE NEGOCIO).
         Es decir aquel que puede controlar lo relacionado a las Acciones del Negocio (CRUD):
            **DEFINIR ACCIONES DEL NEGOCIO:
            - Vender productos
            - Gestionar devoluciones de productos
         */

        UsuarioExterno
        /*
        Refiere al Usuario Externo del Sistema (CLIENTE DE NEGOCIO).
        Es decir aquel que ingresa vía WEB a Comprar Productos.
        */
    }
}
