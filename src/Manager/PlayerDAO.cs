using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Xml.Serialization;
using System.Xml;
using Dungeon_Crawl.src.Objects.DynamicObjects;

namespace Dungeon_Crawl.src.Manager
{
    public class PlayerDao : IPlayerDao
    {
        private readonly string _connectionString;
        private const string DateFormat = "yyyy-MM-dd";
        public PlayerDao(string connectionString)
        {
            _connectionString = connectionString;
        }

        public string SerializeToXml<T>(T value)
        {
            StringWriter writer = new StringWriter(CultureInfo.InvariantCulture);
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            serializer.Serialize(writer, value);
            return writer.ToString();
        }
        public T XmlDeserializeFromString<T>(string objectData)
        {
            return (T)XmlDeserializeFromString(objectData, typeof(T));
        }

        private static object XmlDeserializeFromString( string objectData, Type type)
        {
            var serializer = new XmlSerializer(type);
            object result;

            using (TextReader reader = new StringReader(objectData))
            {
                result = serializer.Deserialize(reader);
            }

            return result;
        }

        public void ClearTable()
        {
            const string insertCommand = @"DELETE FROM player";

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand(insertCommand, connection);
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    var a =cmd.BeginExecuteNonQuery();
                    cmd.EndExecuteNonQuery(a);
                    connection.Close();
                }
            }
            catch (SqlException e)
            {
                throw e;
            }
        }
        public void Add(Player player)
        {
            ClearTable();
            const string insertCommand = @"INSERT INTO player (stats, position, level, items)
                        VALUES (@stats, @position, @level, @items)
                        SELECT SCOPE_IDENTITY();";

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand(insertCommand, connection);
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    cmd.Parameters.AddWithValue("@stats", SerializeToXml(player.Stats));
                    cmd.Parameters.AddWithValue("@position", SerializeToXml(player.Position));
                    cmd.Parameters.AddWithValue("@level", SerializeToXml(player.Level));
                    cmd.Parameters.AddWithValue("@items", SerializeToXml(player.Inventory.GetItems()));

                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (SqlException e)
            {
                throw e;
            }
        }
        public void Update(Player player)
        {
            throw new NotImplementedException();
        }

        public Player Get(Map map)
        {
            const string cmdText = @"SELECT TOP 1 *
                                     FROM [dungeoun-crawl].[dbo].[player]";
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand(cmdText, connection);
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();

                    var reader = cmd.ExecuteReader();
                    // TODO: extract Author from result set

                    reader.Read();
                    var stats = reader.GetString("stats");
                    var position = reader.GetString("position");
                    var level = reader.GetString("level");
                    var items = reader.GetString("items");

                    connection.Close();
                    var positionObj = XmlDeserializeFromString<Position>(position);
                    var player = new Player(positionObj, new Movement(map), map);
                    player.Level = XmlDeserializeFromString<LevelUp>(level);
                    player.Stats = XmlDeserializeFromString<Stats>(stats);

                    return player;
                }
            }
            catch (SqlException e)
            {
                throw new RuntimeWrappedException(e);
            }
        }
    }
}
