using RenewableEnergyCredits.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace RenewableEnergyCredits
{
    public interface IDatabase
    {
        Task<IEnumerable<University>> GetUniversities();
        Task<University> GetUniversityById(string id);
        Task<IEnumerable<Models.Program>> GetPrograms(string universityId, string degree, string year);
        Task<Models.Program> GetProgramById(string id);
        Task<int> AddUniversity(University university);
        Task<int> AddProgram(Models.Program program);
    }

    public class Database : IDatabase
    {
        private readonly SqlConnection _sqlConnection;

        public Database(SqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }

        public async Task<IEnumerable<University>> GetUniversities()
        {
            var universities = new List<University>();
            await _sqlConnection.OpenAsync();

            string query = "SELECT * FROM University";
            using (var command = new SqlCommand(query, _sqlConnection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        universities.Add(new University
                        {
                            Id = reader.GetString(0),
                            ShortName = reader.GetString(1),
                            LongName = reader.GetString(2)
                        });
                    }
                }
            }

            _sqlConnection.Close();
            return universities;
        }

        public async Task<University> GetUniversityById(string id)
        {
            University university;
            await _sqlConnection.OpenAsync();

            string query = $"SELECT * FROM University WHERE Id = '{id}'";
            using (var command = new SqlCommand(query, _sqlConnection))
            {
                using (var reader = command.ExecuteReader())
                {
                    reader.Read();
                    university = new University
                    {
                        Id = reader.GetString(0),
                        ShortName = reader.GetString(1),
                        LongName = reader.GetString(2)
                    };
                }
            }

            _sqlConnection.Close();
            return university;
        }

        public async Task<IEnumerable<Models.Program>> GetPrograms(string universityId, string degree, string year)
        {
            var programs = new List<Models.Program>();
            await _sqlConnection.OpenAsync();

            string query = $"SELECT * FROM Program";
            if (universityId != null)
            {
                query += $" WHERE UniversityId = '{universityId}'";
            }
            if (degree != null)
            {
                query += query[query.Length - 1] == 'm' ? " WHERE" : " AND";
                query += $" Degree = '{degree}'";
            }
            //if (year != null)
            //{
            //    query += query[query.Length - 1] == 'm' ? " WHERE" : " AND";
            //    query += $" Year = '{year}'";
            //}

            using (var command = new SqlCommand(query, _sqlConnection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        programs.Add(new Models.Program
                        {
                            Id = reader.GetString(0),
                            UniversityId = reader.GetString(1),
                            ShortName = reader.GetString(2),
                            LongName = reader.GetString(3),
                            Degree = reader.GetString(4),
                            //Year = reader.GetString(5)
                        });
                    }
                }
            }

            _sqlConnection.Close();
            return programs;
        }

        public async Task<Models.Program> GetProgramById(string id)
        {
            Models.Program program;
            await _sqlConnection.OpenAsync();

            string query = $"SELECT * FROM Program WHERE Id = '{id}'";
            using (var command = new SqlCommand(query, _sqlConnection))
            {
                using (var reader = command.ExecuteReader())
                {
                    reader.Read();
                    program = new Models.Program
                    {
                        Id = reader.GetString(0),
                        UniversityId = reader.GetString(1),
                        ShortName = reader.GetString(2),
                        LongName = reader.GetString(3),
                        Degree = reader.GetString(4)
                    };
                }
            }

            _sqlConnection.Close();
            return program;
        }

        public async Task<int> AddUniversity(University university)
        {
            await _sqlConnection.OpenAsync();

            string query = $"INSERT INTO University (Id, ShortName, LongName) VALUES ('{university.Id}','{university.ShortName}','{university.LongName}')";
            using (var command = new SqlCommand(query, _sqlConnection))
            {
                var success = await command.ExecuteNonQueryAsync();

                _sqlConnection.Close();
                return success;
            }
        }

        public async Task<int> AddProgram(Models.Program program)
        {
            await _sqlConnection.OpenAsync();

            string query = $"INSERT INTO Program (Id, UniversityId, ShortName, LongName, Degree) VALUES ('{program.Id}','{program.UniversityId}','{program.ShortName}','{program.LongName}','{program.Degree}')";
            using (var command = new SqlCommand(query, _sqlConnection))
            {
                var success = await command.ExecuteNonQueryAsync();

                _sqlConnection.Close();
                return success;
            }
        }
    }
}
