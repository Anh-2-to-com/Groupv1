﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;

namespace Lib
{
    public class SQLClass
    {
        #region Declare Variables

        private SqlConnection _connection;

        #endregion


        #region Methods

        public void CreateConnection(string pConnectionString)
        {
            _connection = new SqlConnection(pConnectionString);
        }

        public object ExecuteScalar(string pQuery)
        {
            object returnObject = null;

            try
            {
                // Create new command and set query
                SqlCommand command = _connection.CreateCommand();
                command.CommandText = pQuery;

                // Open connect
                if (_connection.State == ConnectionState.Closed)
                {
                    _connection.Open();
                }

                // Excute
                returnObject = command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return returnObject;
        }

        public DataTable ExcuteQuery(string pQuery)
        {
            try
            {
                // Create new datatable
                DataTable dt = new DataTable();

                // Create new data adapter
                SqlDataAdapter adapter = new SqlDataAdapter(pQuery, _connection);

                // Begin load data
                dt.BeginLoadData();

                // Fill data to datatable
                adapter.Fill(dt);

                // End load data
                dt.EndLoadData();

                return dt;
            }
            catch { }

            return null;
        }

        public object ExcuteQuery(string pQuery, out DataTable pDataTable)
        {
            // Create new datatable
            pDataTable = new DataTable();

            try
            {
                // Create new data adapter
                SqlDataAdapter dataAdapter = new SqlDataAdapter(pQuery, _connection);

                // Begin load data
                pDataTable.BeginLoadData();

                // Fill data to datatable
                dataAdapter.Fill(pDataTable);

                // End load data
                pDataTable.EndLoadData();

                return dataAdapter;
            }
            catch { }

            return null;
        }

        public bool Update(object pDataAdapter, DataRow pDataRow)
        {
            try
            {
                SqlDataAdapter dataAdapter = (SqlDataAdapter)pDataAdapter;

                // Create new sqlcommand builder
                SqlCommandBuilder builder = new SqlCommandBuilder(dataAdapter);

                // Set update command for data adapter
                dataAdapter.UpdateCommand = builder.GetUpdateCommand();
                dataAdapter.DeleteCommand = builder.GetDeleteCommand();
                dataAdapter.InsertCommand = builder.GetInsertCommand();

                // Update data
                int i = dataAdapter.Update(new DataRow[] { pDataRow });

                return true;
            }
            catch { return false; }


        }

        public bool Update(object pDataAdapter, DataRow[] pDataRows)
        {
            try
            {
                SqlDataAdapter dataAdapter = (SqlDataAdapter)pDataAdapter;

                // Create new sqlcommand builder
                SqlCommandBuilder builder = new SqlCommandBuilder(dataAdapter);

                // Set update command for data adapter
                dataAdapter.UpdateCommand = builder.GetUpdateCommand();
                dataAdapter.DeleteCommand = builder.GetDeleteCommand();
                dataAdapter.InsertCommand = builder.GetInsertCommand();

                // Update data
                dataAdapter.Update(pDataRows);

                return true;
            }
            catch { return false; }


        }

        public bool Update(object pDataAdapter, DataTable pDataTable)
        {
            try
            {
                SqlDataAdapter dataAdapter = (SqlDataAdapter)pDataAdapter;

                // Create new sqlcommand builder
                SqlCommandBuilder builder = new SqlCommandBuilder(dataAdapter);

                // Set update command for data adapter
                dataAdapter.UpdateCommand = builder.GetUpdateCommand();
                dataAdapter.DeleteCommand = builder.GetDeleteCommand();
                dataAdapter.InsertCommand = builder.GetInsertCommand();

                // Update data
                dataAdapter.Update(pDataTable);



                return true;
            }
            catch
            {
                return false;
            }


        }

        public bool TestConnection()
        {
            try
            {
                _connection.Open();

            }
            catch
            {
                return false;
            }

            return true;
        }

        #endregion


    }
}