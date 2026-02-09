using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CoffeeManagementSystem.Models.Enum;

namespace CoffeeManagementSystem.Models.Classes
{
    public class CoffeeManagementSystemManager
    {
        public CoffeeManagementSystemManager() { }

        #region Employee Management
        public List<Employee> GetAllEmployees()
        {
            List<Employee> employees = new List<Employee>();
            DataTable dt = DatabaseHelper.ExecuteQuery("SELECT * FROM Employees");
            foreach (DataRow row in dt.Rows)
            {
                employees.Add(MapRowToEmployee(row));
            }
            return employees;
        }

        public Employee GetEmployeeById(int id)
        {
            DataTable dt = DatabaseHelper.ExecuteQuery("SELECT * FROM Employees WHERE ID = @Id", new[] { new SqlParameter("@Id", id) });
            return dt.Rows.Count > 0 ? MapRowToEmployee(dt.Rows[0]) : null;
        }

        public void AddEmployee(Employee emp)
        {
            // Note: Removed ID from INSERT because it is an IDENTITY column
            string query = "INSERT INTO Employees (Name, Gender, DoB, Phone, Email, Pos, StopWork) " +
                           "VALUES (@Name, @Gender, @DoB, @Phone, @Email, @Pos, @StopWork); SELECT SCOPE_IDENTITY();";

            object result = DatabaseHelper.ExecuteScalar(query, GetEmployeeParameters(emp, includeId: false));
            emp.ID = Convert.ToInt32(result); // Update the C# object with the DB-generated ID
        }

        public void UpdateEmployee(Employee emp)
        {
            string query = "UPDATE Employees SET Name = @Name, Gender = @Gender, DoB = @DoB, Phone = @Phone, Email = @Email, Pos = @Pos, StopWork = @StopWork WHERE ID = @Id";
            DatabaseHelper.ExecuteNonQuery(query, GetEmployeeParameters(emp, includeId: true));
        }

        public void DeleteEmployee(int id)
        {
            DatabaseHelper.ExecuteNonQuery("DELETE FROM Employees WHERE ID = @Id", new[] { new SqlParameter("@Id", id) });
        }

        private Employee MapRowToEmployee(DataRow row)
        {
            return new Employee(
                (int)row["ID"],
                (string)row["Name"],
                (Gender)row["Gender"],
                (DateTime)row["DoB"],
                (string)row["Phone"],
                (string)row["Email"],
                (string)row["Pos"],
                (bool)row["StopWork"]
            );
        }

        private SqlParameter[] GetEmployeeParameters(Employee emp, bool includeId)
        {
            var parameters = new List<SqlParameter> {
                new SqlParameter("@Name", emp.Name),
                new SqlParameter("@Gender", (int)emp.Gender),
                new SqlParameter("@DoB", emp.DoB),
                new SqlParameter("@Phone", emp.Phone),
                new SqlParameter("@Email", emp.Email),
                new SqlParameter("@Pos", emp.Pos),
                new SqlParameter("@StopWork", emp.StopWork)
            };
            if (includeId) parameters.Add(new SqlParameter("@Id", emp.ID));
            return parameters.ToArray();
        }
        #endregion

        #region User Management & Authentication
        public User Login(int empId, string password)
        {
            const string query = "SELECT u.ID AS UserID, u.EmpID, u.Password, u.Salt, u.Role, e.* FROM Users u JOIN Employees e ON u.EmpID = e.ID WHERE u.EmpID = @EmpId";
            DataTable dt = DatabaseHelper.ExecuteQuery(query, new[] { new SqlParameter("@EmpId", empId) });

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                string storedHash = (string)row["Password"];
                string storedSalt = (string)row["Salt"];
                
                if (PasswordHelper.VerifyPassword(password, storedSalt, storedHash)) 
                {
                    return MapRowToUser(row);
                }
            }
            return null;
        }

        public bool VerifyUser(string email, string password, out User user)
        {
            user = null;
            const string query = "SELECT u.ID AS UserID, u.EmpID, u.Password, u.Salt, u.Role, e.* FROM Users u JOIN Employees e ON u.EmpID = e.ID WHERE e.Email = @Email";
            DataTable dt = DatabaseHelper.ExecuteQuery(query, new[] { new SqlParameter("@Email", email) });

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                string storedHash = (string)row["Password"];
                string storedSalt = (string)row["Salt"];

                if (PasswordHelper.VerifyPassword(password, storedSalt, storedHash))
                {
                    user = MapRowToUser(row);
                    return true;
                }
            }
            return false;
        }

        public bool HasAnyUsers()
        {
            DataTable dt = DatabaseHelper.ExecuteQuery("SELECT COUNT(*) FROM Users");
            if (dt.Rows.Count > 0)
            {
                return Convert.ToInt32(dt.Rows[0][0]) > 0;
            }
            return false;
        }

        public void CreateNewUser(string password, Employee employee, string role)
        {
            User newUser = new User
            {
                employee = employee,
                Password = password,
                Role = role
            };
            AddUser(newUser);
        }

        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();
            string query = "SELECT u.ID AS UserID, u.EmpID, u.Password, u.Salt, u.Role, e.* FROM Users u JOIN Employees e ON u.EmpID = e.ID";
            DataTable dt = DatabaseHelper.ExecuteQuery(query);
            foreach (DataRow row in dt.Rows)
            {
                users.Add(MapRowToUser(row));
            }
            return users;
        }

        public void AddUser(User user)
        {
            string hashedPassword = PasswordHelper.HashPassword(user.Password, out string salt);

            string query = "INSERT INTO Users (EmpID, Password, Role, Salt) VALUES (@EmpId, @Pass, @Role, @Salt); SELECT SCOPE_IDENTITY();";
            SqlParameter[] parameters = {
                new SqlParameter("@EmpId", user.employee.ID),
                new SqlParameter("@Pass", hashedPassword),
                new SqlParameter("@Role", user.Role),
                new SqlParameter("@Salt", salt)
            };
            user.ID = Convert.ToInt32(DatabaseHelper.ExecuteScalar(query, parameters));
            user.Password = hashedPassword;
            user.Salt = salt;
        }

        public void UpdateUser(User user, bool passwordChanged = false)
        {
            string query;
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@Role", user.Role),
                new SqlParameter("@Id", user.ID)
            };

            if (passwordChanged)
            {
                string hashedPassword = PasswordHelper.HashPassword(user.Password, out string salt);
                query = "UPDATE Users SET Password = @Pass, Role = @Role, Salt = @Salt WHERE ID = @Id";
                parameters.Add(new SqlParameter("@Pass", hashedPassword));
                parameters.Add(new SqlParameter("@Salt", salt));
                
                user.Password = hashedPassword;
                user.Salt = salt;
            }
            else
            {
                query = "UPDATE Users SET Role = @Role WHERE ID = @Id";
            }

            DatabaseHelper.ExecuteNonQuery(query, parameters.ToArray());
        }

        public void DeleteUser(int id)
        {
            DatabaseHelper.ExecuteNonQuery("DELETE FROM Users WHERE ID = @Id", new[] { new SqlParameter("@Id", id) });
        }

        private User MapRowToUser(DataRow row)
        {
            Employee emp = MapRowToEmployee(row);
            int userId = row.Table.Columns.Contains("UserID") ? (int)row["UserID"] : (int)row["ID"];
            return new User(userId, emp, (string)row["Password"], (string)row["Salt"], (string)row["Role"]);
        }
        #endregion

        #region Inventory Management
        public List<Inventory> GetAllInventory()
        {
            List<Inventory> items = new List<Inventory>();
            DataTable dt = DatabaseHelper.ExecuteQuery("SELECT * FROM Inventory");
            foreach (DataRow row in dt.Rows)
            {
                items.Add(MapRowToInventory(row));
            }
            return items;
        }

        public void AddProduct(Inventory p)
        {
            string query = "INSERT INTO Inventory (Name, Price, AlertQty, StockQty) VALUES (@Name, @Price, @AlertQty, @StockQty); SELECT SCOPE_IDENTITY();";
            SqlParameter[] parameters = {
                new SqlParameter("@Name", p.Name),
                new SqlParameter("@Price", p.Price),
                new SqlParameter("@AlertQty", p.AlertQty),
                new SqlParameter("@StockQty", p.StockQty)
            };
            p.ID = Convert.ToInt32(DatabaseHelper.ExecuteScalar(query, parameters));
        }

        public void UpdateProduct(Inventory p)
        {
            string query = "UPDATE Inventory SET Name = @Name, Price = @Price, AlertQty = @AlertQty, StockQty = @StockQty WHERE ID = @Id";
            SqlParameter[] parameters = {
                new SqlParameter("@Name", p.Name),
                new SqlParameter("@Price", p.Price),
                new SqlParameter("@AlertQty", p.AlertQty),
                new SqlParameter("@StockQty", p.StockQty),
                new SqlParameter("@Id", p.ID)
            };
            DatabaseHelper.ExecuteNonQuery(query, parameters);
        }

        public void DeleteProduct(int id)
        {
            DatabaseHelper.ExecuteNonQuery("DELETE FROM Inventory WHERE ID = @Id", new[] { new SqlParameter("@Id", id) });
        }

        public Inventory GetProductById(int id)
        {
            DataTable dt = DatabaseHelper.ExecuteQuery("SELECT * FROM Inventory WHERE ID = @Id", new[] { new SqlParameter("@Id", id) });
            return dt.Rows.Count > 0 ? MapRowToInventory(dt.Rows[0]) : null;
        }

        public List<Inventory> GetLowStockItems()
        {
            List<Inventory> items = new List<Inventory>();
            DataTable dt = DatabaseHelper.ExecuteQuery("SELECT * FROM Inventory WHERE StockQty <= AlertQty");
            foreach (DataRow row in dt.Rows)
            {
                items.Add(MapRowToInventory(row));
            }
            return items;
        }

        private Inventory MapRowToInventory(DataRow row)
        {
            return new Inventory((int)row["ID"], (string)row["Name"], Convert.ToDouble(row["Price"]), (int)row["AlertQty"], (int)row["StockQty"]);
        }
        #endregion

        #region Reports
        public void AddReport(Report report, List<ReportDetail> details)
        {
            DatabaseHelper.ExecuteTransaction(trans =>
            {
                // 1. Insert Report
                string reportQuery = "INSERT INTO Reports (EmpID, Date, Total, Received, Change) VALUES (@EmpId, @Date, @Total, @Rec, @Chan); SELECT SCOPE_IDENTITY();";
                SqlParameter[] reportParams = {
                    new SqlParameter("@EmpId", report.Emp.ID),
                    new SqlParameter("@Date", report.Date),
                    new SqlParameter("@Total", report.Total),
                    new SqlParameter("@Rec", report.Received),
                    new SqlParameter("@Chan", report.Change)
                };

                // Get the new Report ID to use for details
                using (SqlCommand cmd = new SqlCommand(reportQuery, trans.Connection, trans))
                {
                    cmd.Parameters.AddRange(reportParams);
                    // Get the new Report ID generated by the DB
                    report.ID = Convert.ToInt32(cmd.ExecuteScalar());
                }

                // 2. Insert Details
                foreach (var detail in details)
                {
                    // Insert 'Qty' number of rows for each detail
                    for (int i = 0; i < detail.Qty; i++)
                    {
                        string detailQuery = "INSERT INTO ReportDetails (ReportID, MenuID) VALUES (@Rid, @Mid)";
                        SqlParameter[] detailParams = {
                            new SqlParameter("@Rid", report.ID),
                            new SqlParameter("@Mid", detail.menu.ID)
                        };
                        DatabaseHelper.ExecuteNonQuery(detailQuery, detailParams, trans);
                    }
                }
            });
        }

        public List<Report> GetAllReports()
        {
            List<Report> reports = new List<Report>();
            const string query = "SELECT r.ID AS ReportID, r.EmpID, r.Date, r.Total, r.Received, r.Change, e.* FROM Reports r JOIN Employees e ON r.EmpID = e.ID ORDER BY r.Date DESC";
            DataTable dt = DatabaseHelper.ExecuteQuery(query);
            foreach (DataRow row in dt.Rows)
            {
                reports.Add(MapRowToReport(row));
            }
            return reports;
        }

        public List<Report> GetReportsByDateRange(DateTime start, DateTime end)
        {
            List<Report> reports = new List<Report>();
            const string query = "SELECT r.ID AS ReportID, r.EmpID, r.Date, r.Total, r.Received, r.Change, e.* FROM Reports r JOIN Employees e ON r.EmpID = e.ID WHERE r.Date BETWEEN @Start AND @End ORDER BY r.Date DESC";
            SqlParameter[] parameters = {
                new SqlParameter("@Start", start),
                new SqlParameter("@End", end)
            };
            DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);
            foreach (DataRow row in dt.Rows)
            {
                reports.Add(MapRowToReport(row));
            }
            return reports;
        }

        public List<ReportDetail> GetReportDetails(int reportId)
        {
            List<ReportDetail> items = new List<ReportDetail>();
            // Group by MenuID to calculate Quantity and SubTotal
            const string query = @"
                SELECT 
                    rd.ReportID, 
                    rd.MenuID, 
                    COUNT(rd.MenuID) as Qty, 
                    m.Name, 
                    m.Type, 
                    m.Description, 
                    m.Price, 
                    (COUNT(rd.MenuID) * m.Price) as SubTotal
                FROM ReportDetails rd 
                JOIN Menus m ON rd.MenuID = m.ID 
                WHERE rd.ReportID = @Rid
                GROUP BY rd.ReportID, rd.MenuID, m.Name, m.Type, m.Description, m.Price";

            DataTable dt = DatabaseHelper.ExecuteQuery(query, new[] { new SqlParameter("@Rid", reportId) });
            foreach (DataRow row in dt.Rows)
            {
                items.Add(MapRowToReportDetail(row));
            }
            return items;
        }

        private ReportDetail MapRowToReportDetail(DataRow row)
        {
            Menu menu = new Menu(
                (int)row["MenuID"],
                (string)row["Name"],
                (string)row["Type"],
                row["Description"] == DBNull.Value ? "" : (string)row["Description"],
                Convert.ToDouble(row["Price"])
            );

            // We don't have a unique ID for the grouped detail, so we can use 0 or generate a dummy one if needed.
            // But since we are aggregating multiple rows (which might have individual IDs in DB), 
             // representing them as one object with Qty is cleaner for UI.
            return new ReportDetail(
                0, // ID is not applicable for grouped result
                null, // Report object not fully populated here to avoid recursion/heavy loading, or can be set if needed
                menu,
                (int)row["Qty"],
                (decimal)Convert.ToDouble(row["SubTotal"])
            );
        }

        public void UpdateReport(Report report)
        {
            string query = "UPDATE Reports SET EmpID = @EmpId, Date = @Date, Total = @Total, Received = @Rec, Change = @Chan WHERE ID = @Id";
            SqlParameter[] parameters = {
                new SqlParameter("@EmpId", report.Emp.ID),
                new SqlParameter("@Date", report.Date),
                new SqlParameter("@Total", report.Total),
                new SqlParameter("@Rec", report.Received),
                new SqlParameter("@Chan", report.Change),
                new SqlParameter("@Id", report.ID)
            };
            DatabaseHelper.ExecuteNonQuery(query, parameters);
        }

        public void DeleteReport(int id)
        {
            DatabaseHelper.ExecuteNonQuery("DELETE FROM Reports WHERE ID = @Id", new[] { new SqlParameter("@Id", id) });
        }

        public int GetNextReportId()
        {
            const string query = "SELECT ISNULL(MAX(ID), 0) + 1 FROM Reports";
            return Convert.ToInt32(DatabaseHelper.ExecuteScalar(query));
        }

        private Report MapRowToReport(DataRow row)
        {
            Employee emp = MapRowToEmployee(row);
            int reportId = row.Table.Columns.Contains("ReportID") ? (int)row["ReportID"] : (int)row["ID"];
            return new Report(
                reportId,
                emp,
                (DateTime)row["Date"],
                Convert.ToDouble(row["Total"]),
                Convert.ToDouble(row["Received"]),
                Convert.ToDouble(row["Change"])
            );
        }
        #endregion

        #region Menu Management
        public List<Menu> GetAllMenus()
        {
            List<Menu> menuItems = new List<Menu>();
            DataTable dt = DatabaseHelper.ExecuteQuery("SELECT * FROM Menus"); 
            foreach (DataRow row in dt.Rows)
            {
                menuItems.Add(MapRowToMenu(row));
            }
            return menuItems;
        }

        public void AddMenu(Menu m)
        {
            string query = "INSERT INTO Menus (Name, Type, Description, Price) VALUES (@Name, @Type, @Desc, @Price); SELECT SCOPE_IDENTITY();";
            SqlParameter[] parameters = {
                new SqlParameter("@Name", m.Name),
                new SqlParameter("@Type", m.Type),
                new SqlParameter("@Desc", m.Desc ?? (object)DBNull.Value),
                new SqlParameter("@Price", m.Price)
            };
            m.ID = Convert.ToInt32(DatabaseHelper.ExecuteScalar(query, parameters));
        }

        public void UpdateMenu(Menu m)
        {
            string query = "UPDATE Menus SET Name = @Name, Type = @Type, Description = @Desc, Price = @Price WHERE ID = @Id";
            SqlParameter[] parameters = {
                new SqlParameter("@Name", m.Name),
                new SqlParameter("@Type", m.Type),
                new SqlParameter("@Desc", m.Desc ?? (object)DBNull.Value),
                new SqlParameter("@Price", m.Price),
                new SqlParameter("@Id", m.ID)
            };
            DatabaseHelper.ExecuteNonQuery(query, parameters);
        }

        public void DeleteMenu(int id)
        {
            DatabaseHelper.ExecuteNonQuery("DELETE FROM Menus WHERE ID = @Id", new[] { new SqlParameter("@Id", id) });
        }

        public Menu GetMenuById(int id)
        {
            DataTable dt = DatabaseHelper.ExecuteQuery("SELECT * FROM Menus WHERE ID = @Id", new[] { new SqlParameter("@Id", id) });
            return dt.Rows.Count > 0 ? MapRowToMenu(dt.Rows[0]) : null;
        }

        private Menu MapRowToMenu(DataRow row)
        {
            return new Menu(
                (int)row["ID"],
                (string)row["Name"],
                (string)row["Type"],
                row["Description"] == DBNull.Value ? "" : (string)row["Description"],
                Convert.ToDouble(row["Price"])
            );
        }
        #endregion
    }
}