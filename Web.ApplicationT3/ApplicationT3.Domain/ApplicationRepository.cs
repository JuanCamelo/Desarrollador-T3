using ApplicationT3.Domain.Context;
using Azure;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Collections.Generic;
using ApplicationT3.Domain.Migrations;
using System;

namespace ApplicationT3.Domain
{
    public interface IApplicationRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetCurrentUserAsync();
        Task InsertAsync(AccionTable accion);
        Task UpdateAsync(AccionTable accion);
        Task DeleteAsync(AccionTable accion);
    }


    public class ApplicationRepository<TEntity> : IApplicationRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationContext _context;

        public ApplicationRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TEntity>> GetCurrentUserAsync()
        {
            try
            {
                string storedProcedureSql = "EXEC SP_CrudGeneric  @Operacion= 'GET', @Tabla='[dbo].[User]'";

                var resultado = _context.Set<TEntity>().FromSqlRaw(storedProcedureSql);

                return resultado.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task InsertAsync(AccionTable accion)
        {
            try
            {
                string storedProcedureSql = $"EXEC SP_CrudGeneric  " +
                                            $"@Operacion= '{accion.Operacion}'" +
                                            $",@Tabla='{accion.Tabla}'," +
                                            $" @Campos='{accion.Campos}'," +
                                            $"@Valores='{accion.Valores}'";

                await _context.Database.ExecuteSqlRawAsync(storedProcedureSql);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task UpdateAsync(AccionTable accion)
        {
            try
            {
                string storedProcedureSql = $"EXEC SP_CrudGeneric" +
                                            $" @Operacion = '{accion.Operacion}'," +
                                            $" @Tabla = '{accion.Tabla}'," +
                                            $" @Campos = '{accion.Campos}'," +
                                            $" @Condicion = '{accion.Condicion}'";

                await _context.Database.ExecuteSqlRawAsync(storedProcedureSql);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteAsync(AccionTable accion)
        {

            try
            {
                string storedProcedureSql = $"EXEC SP_CrudGeneric" +
                                            $" @Operacion = '{accion.Operacion}'," +
                                            $" @Tabla = '{accion.Tabla}'," +
                                            $" @Condicion = '{accion.Condicion}'";

                await _context.Database.ExecuteSqlRawAsync(storedProcedureSql);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }

}