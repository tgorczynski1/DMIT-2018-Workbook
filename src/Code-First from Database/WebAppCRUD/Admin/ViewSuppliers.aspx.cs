using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppCRUD.Admin
{
    public partial class ViewSuppliers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SuppliersListView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void SuppliersListView_ItemInserting(object sender, ListViewInsertEventArgs e)
        {
            //this fires just before the ListView calls 
            //the ObjectDataSource control to do an Insert.
            ;// no-op statement 1st statement that fires during an error insert
        }

        protected void SuppliersListView_ItemInserted(object sender, ListViewInsertedEventArgs e)
        {
            //this event is fired after the ObjectDataSource 
            //has returned from performing an Insert. 4th
            ;
        }

        protected void SuppliersDataSource_Inserting(object sender, ObjectDataSourceMethodEventArgs e)
        {
            ;// Before calling BLL 2nd
        }

        protected void SuppliersDataSource_Inserted(object sender, ObjectDataSourceStatusEventArgs e)
        {
            //this code is used to drill down into the insert exception
            ; // After the call to the BLL 3rd 
            if(e.Exception != null)
            {       //$ = string interpolation, allows for variables to be used directly in the string
                Exception inner = e.Exception;
                while (inner.InnerException != null)
                    inner = inner.InnerException;
                // inner is used for the high-level error, and drills down
                string message = $"Problem Inserting: {inner.GetType().Name}<blockquote>{inner.Message}</blockquote>";

                if(inner is DbEntityValidationException)
                {
                    //Safe type-cast
                    var actual = inner as
                        DbEntityValidationException;
                    message += "<ul>";
                    foreach(var detail in actual.EntityValidationErrors)
                    {
                        message += $"<li>{detail.Entry.Entity.GetType().Name}";
                        message += "<ol>";
                        foreach(var error in detail.ValidationErrors)
                        {
                            message += $"<li>{error.ErrorMessage}</li>";
                        }
                        message += "</ol></li>";
                    }
                }

                MessageLabel.Text = message;
                e.ExceptionHandled = true;
            }
        }
    }
}