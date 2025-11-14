using Contract.Interfacees;
using Contract.Requests;
using Dapper;
using Microsoft.Data.SqlClient;
using Model;
using Sienra.Exceptions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Contract.Repositorios
{
    public class HeroeRepositorio : IHeroeRepositorio
    {
        private readonly IDbConnection _db;


        public HeroeRepositorio(IDbConnection db)
        {
            _db = db;   
        }

        public Task<bool> ActualizarHereo(HeroeRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> BorrarHeroe(int idHeroe)
        {
            var query = "Delete From Heroe Where IdHeroe = @idHeroe";
            return await _db.ExecuteAsync(query, new { @idHeroe =  idHeroe}) > 0;
        }

        public async Task<bool> CrearHeroe(HeroeRequest request)
        {
            var sql = @"
                        INSERT INTO Heroe (Nombre, IdAlterEgo, Activo)
                        VALUES (@Nombre, @IdAlterEgo, @Activo);
                        ";

            var parameters = new DynamicParameters();
            parameters.Add("@Nombre", request.Nombre);
            parameters.Add("@IdAlterEgo", request.IdAlterEgo);
            parameters.Add("@Activo", request.Activo);

            var result = await _db.ExecuteAsync(sql, parameters);

            return result > 0;
        }

        public async Task<Heroe> ObtenerHeroe(int IdHeroe)
        {
            var query = "SELECT * FROM Heroe WHERE IdHeroe = @IdHeroe And Activo <> 0;";
            var hero = await _db.QueryFirstOrDefaultAsync<Heroe>(query, new { IdHeroe });

            if (hero == null)
                throw new NotFoundException(IdHeroe);

            return hero;
        }

        public async Task<IEnumerable<Heroe>> ObtenerTodosLosHeroes()
        {
            var query = "Select * from Heroe Where Activo <> 0";
            var heroes = _db.Query<Heroe>(query).ToList();
            return heroes;
        }
    }
}
