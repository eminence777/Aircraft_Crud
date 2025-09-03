using Aircraft_Crud.DAL;
using Aircraft_Crud.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc;

namespace Aircraft_Crud.Service
{
    public class AeronaveService
    {
        private readonly Context _context;

        public AeronaveService(Context context)
        {
            _context = context;

        }

        public async Task<bool> Existe(int id)
        {
            return await _context.Aeronaves.AnyAsync(A => A.AeronavesId == id);
        }

        public async Task<bool> Insertar(Aeronaves aeronave)
        {
            _context.Aeronaves.Add(aeronave);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Modificar(Aeronaves aeronave)
        {
            var existente = await _context.Aeronaves.FindAsync(aeronave.AeronavesId);
            if (existente != null)
            {
                _context.Entry(existente).CurrentValues.SetValues(aeronave);
                return await _context.SaveChangesAsync() > 0;
            }
            return false;
        }

        public async Task<bool> Guardar(Aeronaves aeronave)
        {
            if (!await Existe(aeronave.AeronavesId))
                return await Insertar(aeronave);
            else
                return await Modificar(aeronave);

        }

        public async Task<bool> Eliminar(int id)
        {
            var eliminar = await _context.Aeronaves
                .Where(a => a.AeronavesId == id).ExecuteDeleteAsync();
            return eliminar > 0;
        }

        public async Task<Aeronaves?> Buscar(int id)
        {
            return await _context.Aeronaves.AsNoTracking()
                .FirstOrDefaultAsync(a => a.AeronavesId == id);
        }

        public async Task<List<Aeronaves>> Listar(Expression<Func<Aeronaves, bool>> criterio)
        {
            return await _context.Aeronaves
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }


        public async Task<bool> ValidarMatricula(string aeronave)
        {
            return await _context.Aeronaves.AnyAsync(a => a.Matricula == aeronave);
        }

    }

}
