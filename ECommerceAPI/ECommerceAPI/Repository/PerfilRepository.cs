﻿using ECommerceAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceAPI.Repository
{
    public interface PerfilRepository
    {
        void Gravar(Perfil perfil);
        List<Perfil> ListarTodos();
    }
}
