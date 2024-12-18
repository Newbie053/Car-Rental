using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.IO;

namespace WebApplication1
{
    public partial class adminCarInventory : System.Web.UI.Page
    {
        private const string S = "<script>alert('Car added successfully.');</script>";
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        static string global_filepath;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        bool checkIfBookExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from car_master_tbl where car_id='" + TextBox1.Text.Trim() + "' OR book_name='" + TextBox2.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }
        }



        void getCarByID()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from car_master_tbl WHERE car_id='" + TextBox1.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {

                    TextBox2.Text = dt.Rows[0]["car_name"].ToString();
                    TextBox9.Text = dt.Rows[0]["edition"].ToString();
                    TextBox10.Text = dt.Rows[0]["rent_cost"].ToString();
                    TextBox11.Text = dt.Rows[0]["capacity"].ToString();
                    TextBox6.Text = dt.Rows[0]["car_description"].ToString();

                    global_filepath = dt.Rows[0]["car_img_link"].ToString();




                }
                else
                {
                    Response.Write("<script>alert('Invalid Car ID');</script>");
                }

            }
            catch (Exception ex)
            {
                
            }
        }




        protected void Button1_Click1(object sender, EventArgs e)
        {
            if (checkIfBookExists())
            {
                Response.Write("<script>alert('Car Already Exists, try some other Car ID');</script>");
            }
            else
            {
                addNewCar();
            }

        }

        void addNewCar()
        {
            try
            {

                string filepath = "~/Car_inventory/rent-car2.png";
                string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                FileUpload1.SaveAs(Server.MapPath("Car_inventory/" + filename));
                filepath = "~/Car_inventory/" + filename;


                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("INSERT INTO car_master_tbl(car_id,car_name,edition,rent_cost,capacity,car_description,car_img_link)values (@car_id,@car_name,@edition,@rent_cost,@capacity,@car_description,@car_img_link)", con);
                cmd.Parameters.AddWithValue("@car_id", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@car_name", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@edition", TextBox9.Text.Trim());
                cmd.Parameters.AddWithValue("@rent_cost", TextBox10.Text.Trim());
                cmd.Parameters.AddWithValue("@capacity", TextBox11.Text.Trim());
                cmd.Parameters.AddWithValue("@car_description", TextBox6.Text.Trim());
                cmd.Parameters.AddWithValue("@car_img_link",filepath);
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write(S);
                GridView1.DataBind();



            }
            catch(Exception ex)
            {
                
            }
 
        }

        protected void Button1_Click2(object sender, EventArgs e)
        {
            if (checkIfBookExists())
            {
                Response.Write("<script>alert('Car Already Exists, try some other Car ID');</script>");
            }
            else
            {
                addNewCar();
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            getCarByID();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            updateCarByID();
        }


        bool checkIfCarExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from car_master_tbl where car_id='" + TextBox1.Text.Trim() + "' OR car_name='" + TextBox2.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }
        }

        void updateCarByID()
        {

            if (checkIfCarExists())
            {
                try
                {



                    string filepath = "~/Car_inventory/rent-car2";
                    string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                    if (filename == "" || filename == null)
                    {
                        filepath = global_filepath;

                    }
                    else
                    {
                        FileUpload1.SaveAs(Server.MapPath("Car_inventory/" + filename));
                        filepath = "~/Car_inventory/" + filename;
                    }





                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand cmd = new SqlCommand("UPDATE car_master_tbl set car_name=@car_name, edition=@edition, rent_cost=@rent_cost, capacity=@capacity, car_description=@car_description, car_img_link=@car_img_link where car_id='" + TextBox1.Text.Trim() + "'", con);

                    cmd.Parameters.AddWithValue("@car_name", TextBox2.Text.Trim());
                 
                   
                
                    
                    
                    cmd.Parameters.AddWithValue("@edition", TextBox9.Text.Trim());
                    cmd.Parameters.AddWithValue("@rent_cost", TextBox10.Text.Trim());
                    cmd.Parameters.AddWithValue("@capacity", TextBox11.Text.Trim());
                    cmd.Parameters.AddWithValue("@car_description", TextBox6.Text.Trim());
                    cmd.Parameters.AddWithValue("@car_img_link", filepath);




                    cmd.ExecuteNonQuery();
                    con.Close();
                    GridView1.DataBind();
                    Response.Write("<script>alert('Car Updated Successfully');</script>");


                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Invalid Car ID');</script>");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            deleteCarByID();
        }

        void deleteCarByID()
        {
            if (checkIfCarExists())
            {
                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    SqlCommand cmd = new SqlCommand("DELETE from car_master_tbl WHERE car_id='" + TextBox1.Text.Trim() + "'", con);

                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Write("<script>alert('Car Deleted Successfully');</script>");

                    GridView1.DataBind();

                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }

            }
            else
            {
                Response.Write("<script>alert('Invalid Car ID');</script>");
            }
        }
    }
}