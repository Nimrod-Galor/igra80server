using Igra80.Models;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Igra80.Data
{
    public class SqlNotificationRepo : INotificationRepo
    {
        string connectionString = "";
        private readonly IHubContext<Hubs> _context;

        public SqlNotificationRepo(IConfiguration configuration, IHubContext<Hubs> context)
        {
            connectionString = configuration.GetConnectionString("catestConnection");

            _context = context;
        }
        public IEnumerable<Incidence> GetIncidenceNotification()
        {
            var incidences = new List<Incidence>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlDependency.Start(connectionString);
                string commandText = "SELECT CaId, Msg FROM dbo.igra80";
                SqlCommand cmd = new SqlCommand(commandText, conn);
                SqlDependency dependency = new SqlDependency(cmd);
                dependency.OnChange += new OnChangeEventHandler(dbChanghheNotification);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var incidence = new Incidence
                    {
                        CaId = Convert.ToInt32(reader["CaId"]),
                        Msg = reader["Msg"].ToString()
                    };

                    incidences.Add(incidence);
                };
            }
            return incidences;
        }

        private void dbChanghheNotification(object sender, SqlNotificationEventArgs e)
        {
            var notification = e.ToString();
            _context.Clients.All.SendAsync("refreshIncidences", GetIncidenceNotification());
        }
    }
}
