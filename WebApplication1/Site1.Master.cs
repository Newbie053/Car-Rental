﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["role"].Equals(""))
                {
                    LinkButton1.Visible = true;//user login link button
                    LinkButton2.Visible = true;//sign up link button
                    LinkButton3.Visible = false;//logout link button
                    LinkButton7.Visible = false;//hello user link button

                    LinkButton6.Visible = true;//user login link button
                    LinkButton11.Visible = false;//user login link button
                    LinkButton9.Visible = false;//user login link button
                    LinkButton5.Visible = false;//user login link button
                    LinkButton10.Visible = false;//user login link button

                }
                else if (Session["role"].Equals("user"))
                {
                    LinkButton1.Visible = false;//user login link button
                    LinkButton2.Visible = false;//sign up link button
                    LinkButton3.Visible = true;//logout link button
                    LinkButton7.Visible = true;//hello user link button
                    LinkButton7.Text = "Hello " + Session["username"].ToString();


                    LinkButton6.Visible = true;//user login link button
                    LinkButton11.Visible = false;//user login link button
                    LinkButton9.Visible = false;//user login link button
                    LinkButton5.Visible = false;//user login link button
                    LinkButton10.Visible = false;//user login link button

                }

                else if (Session["role"].Equals("admin"))
                {
                    LinkButton1.Visible = false;//user login link button
                    LinkButton2.Visible = false;//sign up link button
                    LinkButton3.Visible = true;//logout link button
                    LinkButton7.Visible = true;//hello user link button
                    LinkButton7.Text = "Hello Admin";


                    LinkButton6.Visible = false;//user login link button
                    LinkButton11.Visible = false;//user login link button
                    LinkButton9.Visible = true;//user login link button
                    LinkButton5.Visible = true;//user login link button
                    LinkButton10.Visible = true;//user login link button

                }
            }
            catch(Exception ex)
            {

            }

        }

        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminlogin.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("userlogin.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("usersignup.aspx");
        }

        protected void LinkButton11_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminCarManagement.aspx");
        }

        protected void LinkButton9_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminBookIssueing.aspx");
        }

        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminCarInventory.aspx");
        }

        protected void LinkButton10_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminMemberManagement.aspx");
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Session["username"] = "";
            Session["fullname"] = "";
            Session["role"] = "";
            Session["status"] = "";
            LinkButton1.Visible = true;//user login link button
            LinkButton2.Visible = true;//sign up link button
            LinkButton3.Visible = false;//logout link button
            LinkButton7.Visible = false;//hello user link button

            LinkButton6.Visible = true;//user login link button
            LinkButton11.Visible = false;//user login link button
            LinkButton9.Visible = false;//user login link button
            LinkButton5.Visible = false;//user login link button
            LinkButton10.Visible = false;//user login link button
        }

        protected void LinkButton7_Click(object sender, EventArgs e)
        {

        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewCars.aspx");
        }
    }
}