using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using advancewebtosolution.BO;
namespace advancewebtosolution
{
    public partial class Admin_Groomer_ExportLockUnlock : System.Web.UI.Page
    {
        string ExcelFilePath = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            ExcelFilePath = System.Configuration.ConfigurationManager.AppSettings["ExcelFile"].ToString();
            ExcelFilePath = ExcelFilePath.Substring(0, ExcelFilePath.LastIndexOf('/') + 1);
            if (!IsPostBack)
            {
                BindGrid();
            }
        }
        public void ErrMessage(string Message)
        {
            divError.Visible = true;
            lblError.Attributes.Add("Class", "errorTable");
            lblError.Visible = true;
            lblError.Text = Message;
        }
        public void SuccesfullMessage(string Message)
        {
            divError.Visible = true;
            lblError.Attributes.Add("Class", "successTable");
            lblError.Visible = true;
            lblError.Text = Message;
        }
        public void CheckAll()
        {
            CheckBox chkall;
            chkall = (CheckBox)GrdDownload.HeaderRow.FindControl("chkall");
            chkall.Attributes.Add("onclick", "checkall()");
            string str;
            str = "function checkall()";
            str = str + "{if(document.getElementById('" + chkall.ClientID + "').checked==true)";
            str = str + "{";
            foreach (GridViewRow gvr in GrdDownload.Rows)
            {
                CheckBox checkall;
                checkall = (CheckBox)gvr.FindControl("chkSelect");
                str = str + "document.getElementById('" + checkall.ClientID + "').checked=true;";
            }
            str = str + "}";
            str = str + "else";
            str = str + "{";
            foreach (GridViewRow grv in GrdDownload.Rows)
            {
                CheckBox chk1;
                chk1 = (CheckBox)grv.FindControl("chkSelect");
                str = str + "document.getElementById('" + chk1.ClientID + "').checked=false;";
            }
            str = str + "}}";
            Page.ClientScript.RegisterStartupScript(GetType(), "sss", str, true);
        }
        /* Check function is use to check select at least one row of grid which is register client script */
        protected void check()
        {
            string checkid = "";
            checkid += "function val(id){";
            checkid += "var flg=0;";

            foreach (GridViewRow grv in GrdDownload.Rows)
            {
                CheckBox chk1;
                chk1 = (CheckBox)grv.FindControl("chkSelect");
                checkid += "if(document.getElementById('" + chk1.ClientID + "').checked==true){";
                checkid += "flg=1;}";
            }
            checkid += "if(flg!=1){";
            checkid += "alert('Select at least one File');return false;}";
            checkid += "if(flg==1 && id==1){";
            checkid += "if(!confirm(' 	 Do you want to delete the selected News Item(s) ?')){return false;}}";
            checkid += "if(flg==1 && id==2){";
            checkid += "if(!confirm('Do you want to change the status of the selected File(s) ? ')){return false;}}";
            checkid = checkid + "}";
            Page.ClientScript.RegisterClientScriptBlock(GetType(), "myscript2", checkid, true);
            btnStatus.Attributes.Add("onclick", "return val(2);");

        }
        public void getServerFiles()
        {
            string fpath = "";
            fpath = @"c:\sftp_upload\";
            fpath = Server.MapPath(@ExcelFilePath) + "\\";

            string[] filePaths = Directory.GetFiles(fpath, "*.xls");
            int k = 0;
            int srno = 1;
            DataTable dt = new DataTable();
            DataColumn dcFileName = new DataColumn();
            DataColumn dcSrNo = new DataColumn();
            dcFileName.ColumnName = "dcFileName";
            dcFileName.DataType = Type.GetType("System.String");

            dcSrNo.ColumnName = "dcSrNo";
            dcSrNo.DataType = Type.GetType("System.Int32");

            dt.Columns.Add(dcFileName);
            dt.Columns.Add(dcSrNo);

            foreach (string s1 in filePaths)
            {
                DataRow tble1row = dt.NewRow();
                tble1row["dcFileName"] = Path.GetFileName(s1);
                tble1row["dcSrNo"] = srno;
                dt.Rows.Add(tble1row);
                k = k + 1;
                srno = srno + 1;
            }
        }
        protected void btnStatus_Click(object sender, EventArgs e)
        {
            string FId = Utility.GetCheckedRow(GrdDownload, "chkSelect");
            if (FId != "")
            {
                Groomer objgr = new Groomer();
                objgr.UpdateExcelFileStatus(FId);
                BindGrid();
            }
        }

        /* Page index changing event to manage pagging */
        protected void GrdDownload_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GrdDownload.PageIndex = e.NewPageIndex;
            BindGrid();
        }
        #region GridEvent
        //Event use for pagination
        protected void GrdDownload_DataBound(object sender, EventArgs e)
        {
            GridViewRow gvr = GrdDownload.BottomPagerRow;
            Label lb1 = (Label)gvr.Cells[0].FindControl("CurrentPage");
            lb1.Text = Convert.ToString(GrdDownload.PageIndex + 1);
            int[] page = new int[7];
            page[0] = GrdDownload.PageIndex - 2;
            page[1] = GrdDownload.PageIndex - 1;
            page[2] = GrdDownload.PageIndex;
            page[3] = GrdDownload.PageIndex + 1;
            page[4] = GrdDownload.PageIndex + 2;
            page[5] = GrdDownload.PageIndex + 3;
            page[6] = GrdDownload.PageIndex + 4;
            for (int i = 0; i < 7; i++)
            {
                if (i != 3)
                {
                    if (page[i] < 1 || page[i] > GrdDownload.PageCount)
                    {
                        LinkButton lb = (LinkButton)gvr.Cells[0].FindControl("p" + Convert.ToString(i));
                        lb.Visible = false;
                    }
                    else
                    {
                        LinkButton lb = (LinkButton)gvr.Cells[0].FindControl("p" + Convert.ToString(i));
                        lb.Text = Convert.ToString(page[i]);

                        lb.CommandName = "PageNo";
                        lb.CommandArgument = lb.Text;

                    }
                }
            }
            if (GrdDownload.PageIndex == 0)
            {
                LinkButton lb = (LinkButton)gvr.Cells[0].FindControl("LinkButton1");
                lb.Visible = false;
                lb = (LinkButton)gvr.Cells[0].FindControl("LinkButton2");
                lb.Visible = false;

            }
            if (GrdDownload.PageIndex == GrdDownload.PageCount - 1)
            {
                LinkButton lb = (LinkButton)gvr.Cells[0].FindControl("LinkButton3");
                lb.Visible = false;
                lb = (LinkButton)gvr.Cells[0].FindControl("LinkButton4");
                lb.Visible = false;

            }
            if (GrdDownload.PageIndex > GrdDownload.PageCount - 5)
            {
                Label lbmore = (Label)gvr.Cells[0].FindControl("nmore");
                lbmore.Visible = false;
            }
            if (GrdDownload.PageIndex < 4)
            {
                Label lbmore = (Label)gvr.Cells[0].FindControl("pmore");
                lbmore.Visible = false;
            }
        }
        protected void GrdDownload_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Pager)
            {
                GridViewRow gvr = e.Row;
                LinkButton lb = (LinkButton)gvr.Cells[0].FindControl("p0");
                lb.Command += new CommandEventHandler(lb_Command);
                lb = (LinkButton)gvr.Cells[0].FindControl("p1");
                lb.Command += new CommandEventHandler(lb_Command);
                lb = (LinkButton)gvr.Cells[0].FindControl("p2");
                lb.Command += new CommandEventHandler(lb_Command);
                lb = (LinkButton)gvr.Cells[0].FindControl("p4");
                lb.Command += new CommandEventHandler(lb_Command);
                lb = (LinkButton)gvr.Cells[0].FindControl("p5");
                lb.Command += new CommandEventHandler(lb_Command);
                lb = (LinkButton)gvr.Cells[0].FindControl("p6");
                lb.Command += new CommandEventHandler(lb_Command);
            }
        }

        void lb_Command(object sender, CommandEventArgs e)
        {
            GrdDownload.PageIndex = Convert.ToInt32(e.CommandArgument) - 1;
            //BindGrid();
        }

        #endregion

        public void BindGrid()
        {
            Groomer objgr = new Groomer();
            DataSet ds = new DataSet();
            ds = objgr.GetExcelFileName();
            if (ds.Tables[0].Rows.Count > 0)
            {
                GrdDownload.DataSource = ds.Tables[0];
                GrdDownload.DataBind();
                CheckAll();
                check();
                Utility.Setserial(GrdDownload, "srno");
                btnStatus.Visible = true;
            }
            else
            {
                GrdDownload.Visible = false;
                btnStatus.Visible = false;
                ErrMessage("Sorry, No records found.");
            }
        }
    }
}