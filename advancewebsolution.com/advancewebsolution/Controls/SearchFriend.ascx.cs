using advancewebtosolution.BO;
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class Controls_SearchFriend : System.Web.UI.UserControl
{

    PagedDataSource PageDs_Friend = new PagedDataSource();
    public void BindData()
    {
        StoreFront ObjService = new StoreFront();
        DataSet DS = new DataSet();
        DS = ObjService.GetFriendSearch(Request.QueryString["Key"].ToString());
        try
        {
            if (DS.Tables[0].Rows.Count > 0)
            {
                lblTitleFriend.Text = "Fritzy's Pet Care Pros friends listing :";
                int currpage;
                PageDs_Friend.DataSource = DS.Tables[0].DefaultView;
                PageDs_Friend.AllowPaging = true;
                PageDs_Friend.PageSize = 10;

                if (ViewState["CurrentPage_Friend"] != null)
                {
                    currpage = Convert.ToInt32(ViewState["CurrentPage_Friend"]);
                }
                else
                {
                    currpage = 1;
                }
                ViewState["CurrentPage_Friend"] = currpage;
                PageDs_Friend.CurrentPageIndex  = currpage - 1;

                bool check = false;
                if (PageDs_Friend.IsFirstPage)
                {
                    check = true;
                    lnkFriendNext.Visible = true;

                }
                else if (PageDs_Friend.IsLastPage)
                {
                    check = true;
                    lnkFriendNext.Visible = false;
                }
                if (PageDs_Friend.PageCount == 1)
                {
                    lnkFriendNext.Visible = false;
                    lnkFriendNext.CssClass = "linkDisable";
                }
                else if (PageDs_Friend.PageCount > 1 && check == false)
                {
                    lnkFriendNext.Visible = true;
                }


                if (DS.Tables[0].Rows.Count == 0)
                {
                    dlFriends.Visible = false;
                }
                else
                {
                    Session["PDSAllFriends"] = PageDs_Friend;
                    dlFriends.DataSource = PageDs_Friend;
                    dlFriends.DataBind();
                }
                if (lnkFriendNext.Visible == true)
                {
                    lblFriendLine.Visible = true;
                }
                else
                {
                    lblFriendLine.Visible = false;
                }
            }
            else
            {
                dlFriends.Visible = false;
                prevFriendlink.Visible = false;
                lnkFriendNext.Visible = false;
                lblFriendLine.Visible = false;
                lblTitleFriend.Text = "No record found.";
            }
        }
        catch (IndexOutOfRangeException ex)
        {
            throw ex;
        }

    }

    protected void prevFriendlink_Click(object sender, EventArgs e)
    {
        PageDs_Friend = (PagedDataSource)Session["PDSAllFriends"];
        if(PageDs_Friend!=null)
        if (!PageDs_Friend.IsFirstPage)
        {
            int currPage = (Convert.ToInt32(ViewState["CurrentPage_Friend"])) - 1;
            ViewState["CurrentPage_Friend"] = currPage.ToString();
            BindData();

        }
    }
    protected void lnkFriendNext_Click(object sender, EventArgs e)
    {
        PageDs_Friend = (PagedDataSource)Session["PDSAllFriends"];
        if (PageDs_Friend != null)
            if (!PageDs_Friend.IsLastPage)
        {
            int currPage = (Convert.ToInt32(ViewState["CurrentPage_Friend"])) + 1;
            ViewState["CurrentPage_Friend"] = currPage.ToString();
            BindData();
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            BindData();

        }
    }
}
