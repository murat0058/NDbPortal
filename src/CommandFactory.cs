﻿using System.Data;

namespace NDbPortal
{
    public class CommandFactory : ICommandFactory
    {
        private readonly IConnectionFactory _connectionFactory;

        public CommandFactory(IConnectionFactory connectionFactory)
        {
            this._connectionFactory = connectionFactory;
        }

        public CommandFactory(string connectionString)
        {
            this._connectionFactory = new ConnectionFactory(connectionString);
        }

        public IDbCommand Create()
        {
            return Create(_connectionFactory.Create());
        }

        public IDbCommand Create(bool isStoredProcedure)
        {
            return Create(_connectionFactory.Create(), isStoredProcedure);
        }


        public IDbCommand Create(IDbConnection connection, bool isStoredProcedure = false)
        {
            var cmd = connection.CreateCommand();
            if (isStoredProcedure)
            {
                cmd.CommandType = CommandType.StoredProcedure;
            }

            return cmd;

        }

    }
}
