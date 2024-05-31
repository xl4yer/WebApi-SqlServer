using Microsoft.Extensions.Options;
using System.Data;
using WebApi_SqlServer.Class;
using WebApi_SqlServer.Models;
using System.Data.SqlClient;

namespace WebApi_SqlServer.Services
{

    public class CustomerServices
    {
        private readonly AppDb _constring;
        public IConfiguration _config;
        public CustomerServices(AppDb constring, IConfiguration configuration)
        {
            _constring = constring;
            _config = configuration;
        }

        //View Customer List
        public async Task<List<Customer>> GetCustomer()
        {
            List<Customer> _customer = new();
            using (var con = new SqlConnection(_constring.GetConnection()))
            {
                await con.OpenAsync().ConfigureAwait(false);
                var com = new SqlCommand("GetCustomers", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                var rdr = await com.ExecuteReaderAsync().ConfigureAwait(false);
                while (await rdr.ReadAsync().ConfigureAwait(false))
                {
                    _customer.Add(new Customer
                    {
                        customerID = Convert.ToInt32(rdr["customerID"]),
                        fname = rdr["fname"].ToString(),
                        mname = rdr["mname"].ToString(),
                        lname = rdr["lname"].ToString(),
                        address = rdr["address"].ToString(),
                        contact = rdr["contact"].ToString(),
                    });
                }
            }
            return _customer;
        }

        //Add Customer
        public async Task<int> AddCustomer(Customer _customer)
        {
            using (SqlConnection con = new SqlConnection(_constring.GetConnection()))
            {
                await con.OpenAsync().ConfigureAwait(false);
                using (SqlCommand com = new SqlCommand("AddCustomer", con))
                {
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@customerID", _customer.customerID);
                    com.Parameters.AddWithValue("@fname", _customer.fname);
                    com.Parameters.AddWithValue("@mname", _customer.mname);
                    com.Parameters.AddWithValue("@lname", _customer.lname);
                    com.Parameters.AddWithValue("@address", _customer.address);
                    com.Parameters.AddWithValue("@contact", _customer.contact);
                    return await com.ExecuteNonQueryAsync().ConfigureAwait(false);
                }
            }
        }

        //Update Customer
        public async Task<int> UpdateCustomer(Customer _customer)
        {
            using (SqlConnection con = new SqlConnection(_constring.GetConnection()))
            {
                await con.OpenAsync().ConfigureAwait(false);
                using (SqlCommand com = new SqlCommand("UpdateCustomer", con))
                {
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@customerID", _customer.customerID);
                    com.Parameters.AddWithValue("@fname", _customer.fname);
                    com.Parameters.AddWithValue("@mname", _customer.mname);
                    com.Parameters.AddWithValue("@lname", _customer.lname);
                    com.Parameters.AddWithValue("@address", _customer.address);
                    com.Parameters.AddWithValue("@contact", _customer.contact);
                    return await com.ExecuteNonQueryAsync().ConfigureAwait(false);
                }
            }

        }

        //Delete Customer
        public async Task<int> DeleteCustomer(Customer _customer)
        {
            using (SqlConnection con = new SqlConnection(_constring.GetConnection()))
            {
                await con.OpenAsync().ConfigureAwait(false);
                using (SqlCommand com = new SqlCommand("DeleteCustomer", con))
                {
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@customerID", _customer.customerID);
                    return await com.ExecuteNonQueryAsync().ConfigureAwait(false);
                }
            }
        }
    }
}
