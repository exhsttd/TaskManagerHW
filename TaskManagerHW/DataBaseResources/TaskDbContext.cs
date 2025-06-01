using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Threading.Tasks;
using TaskManagerHW.Classes;

namespace TaskManagerHW.DataBaseResources
{
    public class TaskDbContext
    {
        private readonly string _connectionString;

        public TaskDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void InitializeDatabase()
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                using (var command = new SQLiteCommand(connection))
                {
                        command.CommandText = @"
                CREATE TABLE IF NOT EXISTS Tasks (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Title TEXT NOT NULL,
                    Description TEXT,
                    Deadline DATETIME,
                    AssigneeId INTEGER,
                    FOREIGN KEY(AssigneeId) REFERENCES Assignees(Id)
                );";
                        command.ExecuteNonQuery();
                        AddColumnIfNotExists(connection, "Tasks", "Description", "TEXT");
                        AddColumnIfNotExists(connection, "Tasks", "Deadline", "DATETIME");
                        AddColumnIfNotExists(connection, "Tasks", "AssigneeId", "INTEGER");
                        command.CommandText = "PRAGMA foreign_key_list(Tasks);";
                        var hasForeignKey = false;
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                if (reader.GetString(2) == "AssigneeId")
                                {
                                    hasForeignKey = true;
                                    break;
                                }
                            }
                        }

                       
                }
            }
        }


        private void AddColumnIfNotExists(SQLiteConnection connection, string table, string column, string type)
        {
            using (var command = new SQLiteCommand(connection))
            {
                command.CommandText = $"PRAGMA table_info({table});";
                var columnExists = false;

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader.GetString(1) == column)
                        {
                            columnExists = true;
                            break;
                        }
                    }
                }

                if (!columnExists)
                {
                    command.CommandText = $"ALTER TABLE {table} ADD COLUMN {column} {type};";
                    command.ExecuteNonQuery();
                }
            }
        }

        public async Task AddAssigneeAsync(string name)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = new SQLiteCommand(connection))
                {
                    command.CommandText = "INSERT INTO Assignees (Name) VALUES (@Name);";
                    command.Parameters.AddWithValue("@Name", name);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task<List<Assignee>> GetAssigneesAsync()
        {
            var assignees = new List<Assignee>();
            using (var connection = new SQLiteConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = new SQLiteCommand(connection))
                {
                    command.CommandText = "SELECT Id, Name FROM Assignees;";
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            assignees.Add(new Assignee
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1)
                            });
                        }
                    }
                }
            }
            return assignees;
        }

        public async Task AddTaskAsync(string title, string description, DateTime deadline, int assigneeId)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = new SQLiteCommand(connection))
                {
                    command.CommandText = @"
                    INSERT INTO Tasks (Title, Description, Deadline, AssigneeId) 
                    VALUES (@Title, @Description, @Deadline, @AssigneeId);";

                    command.Parameters.AddWithValue("@Title", title);
                    command.Parameters.AddWithValue("@Description", description);
                    command.Parameters.AddWithValue("@Deadline", deadline);
                    command.Parameters.AddWithValue("@AssigneeId", assigneeId);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task<List<TaskItem>> GetTasksAsync()
        {
            var tasks = new List<TaskItem>();
            using (var connection = new SQLiteConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = new SQLiteCommand(connection))
                {
                    command.CommandText = @"
                    SELECT t.Id, t.Title, t.Description, t.Deadline, t.AssigneeId, a.Name 
                    FROM Tasks t
                    LEFT JOIN Assignees a ON t.AssigneeId = a.Id;";

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            tasks.Add(new TaskItem
                            {
                                Id = reader.GetInt32(0),
                                Title = reader.GetString(1),
                                Description = reader.IsDBNull(2) ? null : reader.GetString(2),
                                Deadline = reader.IsDBNull(3) ? DateTime.MinValue : reader.GetDateTime(3),
                                AssigneeId = reader.IsDBNull(4) ? 0 : reader.GetInt32(4),
                                AssigneeName = reader.IsDBNull(5) ? "Не назначено" : reader.GetString(5)
                            });
                        }
                    }
                }
            }
            return tasks;
        }

        public async Task DeleteTaskAsync(int taskId)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = new SQLiteCommand(connection))
                {
                    command.CommandText = "DELETE FROM Tasks WHERE Id = @Id;";
                    command.Parameters.AddWithValue("@Id", taskId);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task UpdateTaskAsync(int taskId, string title, string description, DateTime deadline, int assigneeId)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = new SQLiteCommand(connection))
                {
                    command.CommandText = @"
                        UPDATE Tasks 
                        SET Title = @Title, 
                            Description = @Description, 
                            Deadline = @Deadline, 
                            AssigneeId = @AssigneeId 
                        WHERE Id = @Id;";

                    command.Parameters.AddWithValue("@Title", title);
                    command.Parameters.AddWithValue("@Description", description);
                    command.Parameters.AddWithValue("@Deadline", deadline);
                    command.Parameters.AddWithValue("@AssigneeId", assigneeId);
                    command.Parameters.AddWithValue("@Id", taskId);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }
        
    }
}
