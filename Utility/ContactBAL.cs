using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Totalligent.Utility
{
    public class ContactBAL
    {


        public long DMLCCMaster(string JPramValue)
        {
            long RIMAsterID = 0;
            int InsRow = 0;
            SqlCommand sqlCommand = new SqlCommand();
            try
            {
                SqlParameter[] Param = {

                                            new SqlParameter("@JParamVal",SqlDbType.NVarChar),
                                            new SqlParameter("@ReturnRIid",SqlDbType.BigInt)
                                      };

                Param[0].Value = JPramValue;
                Param[1].Direction = ParameterDirection.Output;
                sqlCommand = DMLOperationOutPutParam("pDMLContactInsert", Param, out InsRow);
                RIMAsterID = (long)sqlCommand.Parameters["@ReturnRIid"].Value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return RIMAsterID;
        }
        public SqlCommand DMLOperationOutPutParam(string SPname, SqlParameter[] arrParam, out int ReturnCode)
        {
            SqlConnection objConn = new SqlConnection();
            SqlCommand objCmd;
            ReturnCode = 0;
            try
            {
                string conStr = ConfigurationManager.ConnectionStrings["Totalligent"].ConnectionString.ToString();
                using (objConn = new SqlConnection(conStr))
                {
                    objConn.Open();
                    objCmd = new SqlCommand(SPname, objConn);
                    objCmd.CommandType = CommandType.StoredProcedure;

                    foreach (SqlParameter SPpram in arrParam)
                    {
                        objCmd.Parameters.Add(SPpram);
                    }

                    ReturnCode = objCmd.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

                if (ConnectionState.Open == objConn.State)
                {
                    objConn.Close();
                }
            }

            return objCmd;

        }


    }
}