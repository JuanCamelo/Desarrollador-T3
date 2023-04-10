using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApplicationT3.Domain.Migrations
{
    /// <inheritdoc />
    public partial class storedProcedures : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            CREATE PROCEDURE [dbo].[SP_CrudGeneric]
                @Operacion VARCHAR(10), -- Valores: INSERT, UPDATE, DELETE,GET
                @Tabla VARCHAR(100), -- Nombre de la tabla
                @Campos VARCHAR(MAX)= '', -- Lista de campos separados por comas (para INSERT y UPDATE)
                @Valores VARCHAR(MAX)= '', -- Lista de valores separados por comas (para INSERT y UPDATE)
                @Condicion VARCHAR(MAX) = '' -- Condición para el WHERE (para UPDATE y DELETE)
            AS
            BEGIN
                DECLARE @sql NVARCHAR(MAX)

                SET @sql = CASE @Operacion
                    WHEN 'INSERT' THEN 'INSERT INTO ' + @Tabla + '(' + @Campos + ') VALUES (' + @Valores + ')'
                    WHEN 'UPDATE' THEN 'UPDATE ' + @Tabla + ' SET ' + @Campos + ' WHERE ' + @Condicion
                    WHEN 'DELETE' THEN 'DELETE FROM ' + @Tabla + ' WHERE ' + @Condicion
                    WHEN 'GET' THEN 'SELECT * FROM ' + @Tabla 
                    ELSE ''
                END

                EXEC sp_executesql @sql
            END
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE SP_CrudGenerica");
        }
    }
}
